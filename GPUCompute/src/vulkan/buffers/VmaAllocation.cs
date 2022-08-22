using GPUCompute.vulkan.descriptors;
using GPUCompute.vulkan.utils;
using Vulkan;
using static GPUCompute.vulkan.vma.Vma;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.buffers; 

public class VmaAllocation : IDisposable {
    public VmaAllocator allocator;
    public VkBuffer buffer;
    public IntPtr vmaAllocation;
    public VkDescriptorBufferInfo bufferInfo;
    public readonly ulong size;

    public unsafe VmaAllocation(VmaAllocator allocator, VmaMemoryUsage memoryUsage, VmaAllocationCreateFlags flags, VkBufferUsageFlags usage, ulong size, VkMemoryPropertyFlags requiredFlags, VkMemoryPropertyFlags preferredFlags) {
        this.size = size;
        this.allocator = allocator;
        
        VkBufferCreateInfo createInfo = new() {
            sType = VkStructureType.BufferCreateInfo,
            size = size,
            sharingMode = VkSharingMode.Exclusive,
            usage = usage
        };

        VmaAllocationCreateInfo allocationCreateInfo = new() {
            usage = memoryUsage,
            flags = flags,
            requiredFlags = (int) requiredFlags,
            preferredFlags = (int) preferredFlags
        };
        
        vmaCreateBuffer(allocator.handle, (IntPtr)(&createInfo), ref allocationCreateInfo, out ulong bufferPtr, out vmaAllocation, IntPtr.Zero).Check("Failed to create vma buffer");
        buffer = new(bufferPtr);

        bufferInfo = new() {
            buffer = buffer,
            range = size
        };
    }

    public unsafe void WriteDescriptorSet(VulkanDescriptorSet set, uint binding, VkDescriptorType type) {
        fixed (VkDescriptorBufferInfo* bufferInfoPtr = &bufferInfo) {
            VkWriteDescriptorSet writeDescriptorSet = new() {
                sType = VkStructureType.WriteDescriptorSet,
                dstSet = set.set,
                dstBinding = binding,
                dstArrayElement = 0,
                descriptorType = type,
                descriptorCount = 1,
                pBufferInfo = bufferInfoPtr
            };

            vkUpdateDescriptorSets(allocator.device.logicalDevice.device, 1, &writeDescriptorSet, 0, IntPtr.Zero);
        }
    }

    public unsafe void* MapMemory() {
        vmaMapMemory(allocator.handle, vmaAllocation, out void* data).Check("Failed to map vma memory");
        return data;
    }

    public void UnmapMemory() => vmaUnmapMemory(allocator.handle, vmaAllocation);

    public unsafe void CopyToDevice(void* src) {
        Buffer.MemoryCopy(src, MapMemory(), size, size);
        UnmapMemory();
    }
    
    public unsafe void CopyToDevice(void* src, ulong dstOffset, ulong dstBytes) {
        Buffer.MemoryCopy(src, (byte*) MapMemory() + dstOffset, dstBytes, dstBytes);
        UnmapMemory();
    }

    public unsafe void CopyFromDevice(void* dest) {
        Buffer.MemoryCopy(MapMemory(), dest, size, size);
        UnmapMemory();
    }
    
    public unsafe void CopyFromDevice(void* dest, ulong srcOffset, ulong srcBytes) {
        Buffer.MemoryCopy((byte*) MapMemory() + srcOffset, dest, srcBytes, srcBytes);
        UnmapMemory();
    }

    public void Dispose() => vmaDestroyBuffer(allocator.handle, buffer.Handle, vmaAllocation);
}