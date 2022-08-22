using GPUCompute.core;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.descriptors; 

public struct VulkanDescriptorSetLayout : IDisposable {
    public Device device; 
    public VkDescriptorSetLayout layout;
    
    public unsafe VulkanDescriptorSetLayout(Device device, VkDescriptorSetLayoutBinding[] bindings) {
        this.device = device;
        fixed (VkDescriptorSetLayoutBinding* bindingsPtr = bindings) {
            VkDescriptorSetLayoutCreateInfo layoutCreateInfo = new() {
                sType = VkStructureType.DescriptorSetLayoutCreateInfo,
                bindingCount = (uint)bindings.Length,
                pBindings = bindingsPtr
            };

            vkCreateDescriptorSetLayout(device.logicalDevice.device, &layoutCreateInfo, IntPtr.Zero, out layout).Check("Failed to create vulkan descriptor set layout");
        }
    }

    public void Dispose() => vkDestroyDescriptorSetLayout(device.logicalDevice.device, layout, IntPtr.Zero);
}