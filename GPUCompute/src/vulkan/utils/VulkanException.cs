using System.Runtime.Serialization;
using Vulkan;

namespace GPUCompute.vulkan.utils;

[Serializable]
public class VulkanException : Exception {
    public VulkanException() : base() { }
    public VulkanException(string msg) : base(msg) { }
    public VulkanException(VkResult result) : base($"Vulkan error {(VulkanResult)result}") { }
    public VulkanException(VkResult result, string message) : base($"Vulkan error {(VulkanResult)result}: {message}") { }
    public VulkanException(VkResult result, string message, Exception inner) : base($"Vulkan error {(VulkanResult)result}: {message}", inner) { }

    protected VulkanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}