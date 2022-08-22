using GPUCompute.core;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.descriptors; 

public struct VulkanDescriptorPool : IDisposable {
    public Device device;
    public VkDescriptorPool pool;

    public unsafe VulkanDescriptorPool(Device device, uint maxCount = 8) {
        this.device = device;

        VkDescriptorPoolSize poolSize = new() {
            type = VkDescriptorType.StorageBuffer,
            descriptorCount = maxCount
        };

        VkDescriptorPoolCreateInfo poolCreateInfo = new() {
            sType = VkStructureType.DescriptorPoolCreateInfo,
            poolSizeCount = 1,
            pPoolSizes = &poolSize,
            maxSets = maxCount
        };

        vkCreateDescriptorPool(device.logicalDevice.device, &poolCreateInfo, IntPtr.Zero, out pool).Check("Failed to create vulkan descriptor pool");
    }

    public readonly void Dispose() => vkDestroyDescriptorPool(device.logicalDevice.device, pool, IntPtr.Zero);
}