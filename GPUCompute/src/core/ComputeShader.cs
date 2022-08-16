using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.shaders;

namespace GPUCompute.core; 

public class ComputeShader : IDisposable {
    public VulkanComputePipeline pipeline;

    public ComputeShader(Device device, VulkanShaderModule shaderModule) {
        pipeline = new(device.logicalDevice, shaderModule);
        shaderModule.Dispose();
    }

    public void Bind(CommandBuffer commandBuffer) => pipeline.Bind(commandBuffer.commandBuffer);

    public void Dispose() {
        pipeline.Dispose();
        GC.SuppressFinalize(this);
    }

    ~ComputeShader() => pipeline.Dispose();
}