using GPUCompute.core;
using GPUCompute.vulkan.instance;
using GPUCompute.vulkan.utils;
using GPUCompute.vulkan.vma;
using Vulkan;
using static Vulkan.VulkanNative;
using static GPUCompute.vulkan.vma.Vma;

namespace GPUCompute.vulkan.buffers;

public struct VmaAllocator : IDisposable {
    public Device device;
    public IntPtr handle;

    public VmaAllocator(Device device) {
        this.device = device;
        
        VmaAllocatorCreateInfo createInfo = new() {
            device = device.logicalDevice.device.Handle,
            physicalDevice = device.physicalDevice.device.Handle,
            instance = VulkanInstance.instance.Handle
        };
        
        vmaCreateAllocator(ref createInfo, out handle).Check("vma");
    }

    public void Dispose() {
        vmaDestroyAllocator(handle);
    }
}