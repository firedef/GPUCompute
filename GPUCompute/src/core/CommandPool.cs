using GPUCompute.vulkan.commands;

namespace GPUCompute.core; 

public class CommandPool : IDisposable {
    public Device device;
    public VulkanCommandPool commandPool;

    public CommandPool(Device device) {
        this.device = device;
        commandPool = new(device.logicalDevice);
    }

    public CommandBuffer CreateBuffer() => new(device, this);
    
    public void Dispose() {
        commandPool.Dispose();
        GC.SuppressFinalize(this);
    }

    ~CommandPool() => commandPool.Dispose();
}