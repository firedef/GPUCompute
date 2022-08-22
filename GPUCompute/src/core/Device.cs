using GPUCompute.vulkan.buffers;
using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using shaderc;
using Vulkan;

namespace GPUCompute.core; 

public class Device : IDisposable {
    public readonly VulkanPhysicalDevice physicalDevice;
    public readonly VulkanLogicalDevice logicalDevice;
    public readonly VmaAllocator allocator;

    public Device() : this(new()) { }

    public Device(VulkanPhysicalDevice physicalDevice) {
        this.physicalDevice = physicalDevice;
        logicalDevice = new(physicalDevice);
        allocator = CreateAllocator();
    }

    public void Wait() => logicalDevice.Wait();

    public CommandPool CreateCmdPool() => new(this);
    
    public unsafe ComputeShader CreateShader(string str, params DescriptorSet[] descriptorSetLayouts) {
        using Compiler compiler = new();
        using Result result = compiler.Compile(str, "shader", ShaderKind.GlslComputeShader);
        if (result.Status != Status.Success) throw new ShaderException(result.ErrorMessage);
        
        return CreateShader((void*)result.CodePointer, (int)result.CodeLength, descriptorSetLayouts);
    }

    public unsafe ComputeShader CreateShader(void* ptr, int length, params DescriptorSet[] descriptorSetLayouts) => new(this, new(logicalDevice, ptr, length), descriptorSetLayouts);

    public VmaAllocator CreateAllocator() => new(this);

    public void Dispose() {
        logicalDevice.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Device() => logicalDevice.Dispose();
}