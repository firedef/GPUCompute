using GPUCompute.vulkan.commands;
using MathStuff.vectors;

namespace GPUCompute.core; 

public class CommandBuffer : IDisposable {
    public VulkanCommandBuffer commandBuffer;

    public CommandBuffer(Device device, CommandPool pool) {
        commandBuffer = new(pool.commandPool, device.logicalDevice);
    }

    public void Begin() => commandBuffer.Begin();
    public void End() => commandBuffer.End();
    public void Reset() => commandBuffer.Reset();
    
    public void Dispatch(int3 dimensions) => commandBuffer.Dispatch(dimensions);

    public void Execute() => commandBuffer.logicalDevice.SubmitAllAndWait(commandBuffer);
    
    public void Dispose() {
        commandBuffer.Dispose();
        GC.SuppressFinalize(this);
    }

    ~CommandBuffer() => commandBuffer.Dispose();
}