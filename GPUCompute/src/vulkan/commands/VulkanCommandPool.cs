using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.commands; 

public unsafe struct VulkanCommandPool : IDisposable {
    public VulkanLogicalDevice logicalDevice;
    public VkCommandPool commandPool;

    public VulkanCommandPool(VulkanLogicalDevice logicalDevice) {
        this.logicalDevice = logicalDevice;
        
        VkCommandPoolCreateInfo poolCreateInfo = new() {
            sType = VkStructureType.CommandPoolCreateInfo,
            flags = VkCommandPoolCreateFlags.ResetCommandBuffer,
            queueFamilyIndex = logicalDevice.computeQueue.index
        };

        fixed (VkCommandPool* commandPoolPtr = &commandPool)
            vkCreateCommandPool(logicalDevice.device, &poolCreateInfo, null, commandPoolPtr).Check("Failed to create vulkan command pool");
    }

    public VulkanCommandBuffer CreateBuffer() => new(this, logicalDevice);

    public void Dispose() {
        vkDestroyCommandPool(logicalDevice.device, commandPool, IntPtr.Zero);
    }
}