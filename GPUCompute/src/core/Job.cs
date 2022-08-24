using GPUCompute.core.buffers;
using GPUCompute.vulkan.descriptors;
using MathStuff.vectors;
using Vulkan;
using Buffer = GPUCompute.core.buffers.Buffer;

namespace GPUCompute.core; 

public readonly struct Job : IDisposable {
    public readonly Environment environment;
    public readonly VulkanDescriptorPool descriptorPool;
    public readonly DescriptorSet[] descriptorSets;
    public readonly ComputeShader shader;

    public Job(Environment environment, string shaderSrc, int bufferCount) : this() {
        this.environment = environment;
        descriptorPool = new(environment.device, (uint)bufferCount);
        descriptorSets = new DescriptorSet[bufferCount];
        Init(bufferCount);
        
        shader = environment.device.CreateShader(shaderSrc, descriptorSets);
    }
    
    public unsafe Job(Environment environment, void* shaderSrc, int shaderSrcLength, int bufferCount) : this() {
        this.environment = environment;
        descriptorPool = new(environment.device, (uint)bufferCount);
        descriptorSets = new DescriptorSet[bufferCount];
        Init(bufferCount);
        
        shader = environment.device.CreateShader(shaderSrc, shaderSrcLength, descriptorSets);
    }
    
    public unsafe Job(Environment environment, uint[] shaderSrc, int bufferCount) : this() {
        this.environment = environment;
        descriptorPool = new(environment.device, (uint)bufferCount);
        descriptorSets = new DescriptorSet[bufferCount];
        Init(bufferCount);
        
        fixed (uint* shaderSrcPtr = shaderSrc)
            shader = environment.device.CreateShader(shaderSrcPtr, shaderSrc.Length * sizeof(uint), descriptorSets);
    }

    private void Init(int bufferCount) {
        for (int i = 0; i < bufferCount; i++)
            descriptorSets[i] = new(descriptorPool, VkDescriptorType.StorageBuffer);
    }

    public void Execute(int workgroupCountX, params Buffer[] buffers) => Execute3(new(workgroupCountX, 1, 1), buffers);
    public void Execute2(int workgroupCountX, int workgroupCountY, params Buffer[] buffers) => Execute3(new(workgroupCountX, workgroupCountY, 1), buffers);
    public void Execute3(int workgroupCountX, int workgroupCountY, int workgroupCountZ, params Buffer[] buffers) => Execute3(new(workgroupCountX, workgroupCountY, workgroupCountZ), buffers);
    
    public void Execute3(int3 workgroupCount, params Buffer[] buffers) {
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

    public void Dispose() {
        descriptorPool.Dispose();
        shader.Dispose();
    }
}