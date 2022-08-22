using GPUCompute.core;
using GPUCompute.vulkan.instance;
using GPUCompute.vulkan.utils;
using Vulkan;
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
        
        vmaCreateAllocator(ref createInfo, out handle).Check("Failed to create vulkan memory allocator");
    }

    public VmaAllocation Alloc(VmaMemoryUsage memoryUsage, VmaAllocationCreateFlags flags, VkBufferUsageFlags usage, ulong size, VkMemoryPropertyFlags requiredFlags, VkMemoryPropertyFlags preferredFlags) => 
        new(this, memoryUsage, flags, usage, size, requiredFlags, preferredFlags);

    public VmaBudget[] GetHeapBudgets() {
        VmaBudget[] budgets = new VmaBudget[vkMaxMemoryHeaps];
        vmaGetHeapBudgets(handle, budgets);
        return budgets;
    }

    public void PrintHeapBudgetStats() {
        VmaBudget[] heapBudgets = GetHeapBudgets();

        Console.WriteLine($"Total heaps: {heapBudgets.Length}");
        for (int i = 0; i < heapBudgets.Length; i++)
            Console.WriteLine($"#{i}: {heapBudgets[i].usage}b");

        Console.WriteLine($"Total allocated: {heapBudgets.Sum(v => (double) v.usage)}b");
    }

    public void Dispose() {
        vmaDestroyAllocator(handle);
    }
}