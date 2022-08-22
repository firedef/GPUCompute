namespace GPUCompute.core; 

public class Environment : IDisposable {
    public readonly Device device;
    public readonly CommandPool commandPool;
    public readonly CommandBuffer commandBuffer;

    public Environment(Device device) {
        this.device = device;
        commandPool = new(device);
        commandBuffer = new(device, commandPool);
    }

    public void Dispose() {
        commandPool.Dispose();
        commandBuffer.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Environment() {
        commandPool.Dispose();
        commandBuffer.Dispose();
    }
}