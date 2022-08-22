using GPUCompute.vulkan.buffers;
using Vulkan;
using static GPUCompute.vulkan.vma.Vma;

namespace GPUCompute.core.buffers; 

public class GpuBuffer : IDisposable {
    public VmaAllocator allocator;
    public VmaAllocation? allocation;
    public VmaMemoryUsage memoryUsage = VmaMemoryUsage.VMA_MEMORY_USAGE_GPU_ONLY;
    public VmaAllocationCreateFlags flags;
    public VkBufferUsageFlags usage = VkBufferUsageFlags.StorageBuffer;
    public VkMemoryPropertyFlags requiredFlags = VkMemoryPropertyFlags.HostVisible;
    public ulong size;

    public GpuBuffer(VmaAllocator allocator, ulong size) {
        this.allocator = allocator;
        this.size = size;

        allocation = new(allocator, memoryUsage, flags, usage, size, requiredFlags, requiredFlags);
    }

    public void Reallocate() {
        allocation?.Dispose();
        allocation = new(allocator, memoryUsage, flags, usage, size, requiredFlags, requiredFlags);
    }

    public void Use(DescriptorSet set, uint binding) => allocation!.WriteDescriptorSet(set.set, binding, VkDescriptorType.StorageBuffer);

    public unsafe void CopyToDevice(void* src) => allocation!.CopyToDevice(src);
    public unsafe void CopyToDevice(void* src, ulong dstOffset, ulong bytes) => allocation!.CopyToDevice(src, dstOffset, bytes);
    public unsafe void CopyToDevice<T>(T[] src) where T : unmanaged => CopyToDevice(src, 0, 0, src.Length);
    public unsafe void CopyToDevice<T>(T[] src, int srcOffset, int dstOffset, int count) where T : unmanaged {
        fixed (T* srcPtr = src) CopyToDevice(srcPtr + srcOffset, (ulong)dstOffset, (ulong)(sizeof(T) * count));
    }

    public unsafe void CopyFromDevice(void* dst) => allocation!.CopyFromDevice(dst);
    public unsafe void CopyFromDevice(void* dst, ulong srcOffset, ulong bytes) => allocation!.CopyFromDevice(dst, srcOffset, bytes);
    public unsafe void CopyFromDevice<T>(T[] dst) where T : unmanaged => CopyFromDevice(dst, 0, 0, dst.Length);
    public unsafe void CopyFromDevice<T>(T[] dst, int srcOffset, int dstOffset, int count) where T : unmanaged {
        fixed (T* dstPtr = dst) CopyFromDevice(dstPtr + dstOffset, (ulong)srcOffset, (ulong)(sizeof(T) * count));
    }

    public unsafe T[] CopyFromDevice<T>() where T : unmanaged {
        T[] arr = new T[size / (ulong)sizeof(T)];
        CopyFromDevice(arr);
        return arr;
    }

    public void Dispose() {
        allocation?.Dispose();
        allocation = null;
        GC.SuppressFinalize(this);
    }

    ~GpuBuffer() => allocation?.Dispose();
}