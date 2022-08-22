using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.shaders;
using Vulkan;

namespace GPUCompute.core; 

public class ComputeShader : IDisposable {
    public VulkanComputePipeline pipeline;

    public ComputeShader(Device device, VulkanShaderModule shaderModule, DescriptorSet[] descriptorSetLayouts) {
        pipeline = new(device.logicalDevice, shaderModule, descriptorSetLayouts.Select(v => v.layout.layout).ToArray());
        shaderModule.Dispose();
    }

    public void Bind(CommandBuffer commandBuffer) => pipeline.Bind(commandBuffer.commandBuffer);

    public void Dispose() {
        pipeline.Dispose();
        GC.SuppressFinalize(this);
    }

    ~ComputeShader() => pipeline.Dispose();
}