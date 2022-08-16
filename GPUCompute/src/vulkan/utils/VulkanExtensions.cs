using Vulkan;

namespace GPUCompute.vulkan.utils; 

public static class VulkanExtensions {
    public static void Check(this VkResult result) {
        if (result != VkResult.Success) throw new VulkanException(result);
    }
    
    public static void Check(this VkResult result, string msg) {
        if (result != VkResult.Success) throw new VulkanException(result, msg);
    }
}