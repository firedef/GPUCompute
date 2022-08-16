using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.device; 

public struct VulkanQueue {
    public VkQueue queue;
    public uint index;

    public VulkanQueue(VulkanLogicalDevice logicalDevice, uint index) {
        this.index = index;
        vkGetDeviceQueue(logicalDevice.device, index, 0, out queue);
    }
}