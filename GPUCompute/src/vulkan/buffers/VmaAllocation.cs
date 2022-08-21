using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using Vulkan;
using static GPUCompute.vulkan.vma.Vma;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.buffers; 

public struct VmaAllocation : IDisposable {
    public VmaAllocator allocator;
    public VkBuffer buffer;
    public IntPtr allocation;

    public unsafe VmaAllocation(VmaAllocator allocator, VmaMemoryUsage memoryUsage, VmaAllocationCreateFlags flags, VkBufferUsageFlags usage, ulong size) {
        this.allocator = allocator;
        
        VkBufferCreateInfo createInfo = new() {
            sType = VkStructureType.BufferCreateInfo,
            size = size,
            sharingMode = VkSharingMode.Exclusive,
            usage = usage
        };

        VmaAllocationCreateInfo allocationCreateInfo = new() {
            usage = memoryUsage,
            flags = flags
        };

        vmaCreateBuffer(allocator.handle, (IntPtr)(&createInfo), ref allocationCreateInfo, out ulong bufferPtr, out allocation, IntPtr.Zero).Check("Failed to create vma buffer");
        buffer = new(bufferPtr);
    }

    public void Dispose() {
        vmaDestroyBuffer(allocator.handle, buffer.Handle, allocation);
    }
}