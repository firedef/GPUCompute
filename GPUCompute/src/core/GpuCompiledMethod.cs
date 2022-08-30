using GPUCompute.core.buffers;
using GPUCompute.spirv.cs.info;
using GPUCompute.vulkan.descriptors;
using MathStuff.vectors;
using Vulkan;
using Buffer = GPUCompute.core.buffers.Buffer;

namespace GPUCompute.core; 

public class GpuCompiledMethod {
    public readonly Environment environment;
    public VulkanDescriptorPool descriptorPool;
    public DescriptorSet[]? descriptorSets;
    public ComputeShader? shader;
    
    public GpuCompiledMethod(Environment environment) {
        this.environment = environment;
    }

    public unsafe void CreateShader(uint[] shaderSrc) {
        fixed (uint* shaderSrcPtr = shaderSrc)
            shader = environment.device.CreateShader(shaderSrcPtr, shaderSrc.Length * sizeof(uint), descriptorSets!);
    }

    public void CreateDescriptors(List<BufferInfo> buffers) {
        descriptorPool = new(environment.device, (uint)buffers.Count);
        descriptorSets = new DescriptorSet[buffers.Count];
        
        for (int i = 0; i < buffers.Count; i++)
            descriptorSets[i] = new(descriptorPool, buffers[i].isUniform ? VkDescriptorType.UniformBuffer : VkDescriptorType.StorageBuffer);
    }
    
    public void Execute(int workgroupCountX, params Buffer[] buffers) => Execute3(new(workgroupCountX, 1, 1), buffers);
    public void Execute2(int workgroupCountX, int workgroupCountY, params Buffer[] buffers) => Execute3(new(workgroupCountX, workgroupCountY, 1), buffers);
    public void Execute3(int workgroupCountX, int workgroupCountY, int workgroupCountZ, params Buffer[] buffers) => Execute3(new(workgroupCountX, workgroupCountY, workgroupCountZ), buffers);
    
    public void Execute3(int3 workgroupCount, params Buffer[] buffers) {
        if (descriptorSets == null)
            throw new("Descriptors not initialized");
        
        if (shader == null)
            throw new("Shader not initialized");
        
        for (int i = 0; i < buffers.Length; i++) {
            buffers[i].BeforeJob();
            buffers[i].Use(descriptorSets[i], 0);
        }
        
        environment.commandBuffer.Begin();
        shader.Bind(environment.commandBuffer);
        shader.pipeline.BindDescriptorSets(environment.commandBuffer.commandBuffer, descriptorSets);
        
        environment.commandBuffer.Dispatch(workgroupCount);
        environment.commandBuffer.End();
        environment.commandBuffer.Execute();
        environment.device.Wait();
        
        foreach (Buffer b in buffers) b.AfterJob();
    }
}