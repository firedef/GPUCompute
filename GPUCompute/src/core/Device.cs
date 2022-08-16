using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using shaderc;

namespace GPUCompute.core; 

public class Device : IDisposable {
    public readonly VulkanPhysicalDevice physicalDevice;
    public readonly VulkanLogicalDevice logicalDevice;

    public Device() : this(new()) { }

    public Device(VulkanPhysicalDevice physicalDevice) {
        this.physicalDevice = physicalDevice;
        logicalDevice = new(physicalDevice);
    }

    public void Wait() => logicalDevice.Wait();

    public CommandPool CreatePool() => new(this);
    
    public unsafe ComputeShader CreateShader(string str) {
        using Compiler compiler = new();
        using Result result = compiler.Compile(str, "shader", ShaderKind.GlslComputeShader);
        if (result.Status != Status.Success) throw new ShaderException(result.ErrorMessage);
        
        return CreateShader((void*)result.CodePointer, (int)result.CodeLength);
    }

    public unsafe ComputeShader CreateShader(void* ptr, int length) => new(this, new(logicalDevice, ptr, length));

    public void Dispose() {
        logicalDevice.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Device() => logicalDevice.Dispose();
}