namespace GPUCompute.vulkan; 

public class Vulkan : IDisposable {
    public Vulkan() {
        Init();
    }
    
    private void Init() {
        
    }

    private void Cleanup() {
        
    }

    public void Dispose() {
        Cleanup();
        GC.SuppressFinalize(this);
    }

    ~Vulkan() => Cleanup();
}