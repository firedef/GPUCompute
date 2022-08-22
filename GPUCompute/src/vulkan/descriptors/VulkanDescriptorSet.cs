using GPUCompute.core;
using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.shaders;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.descriptors; 

public struct VulkanDescriptorSet {
    public Device device;
    public VkDescriptorSet set;

    public unsafe VulkanDescriptorSet(Device device, VulkanDescriptorPool pool, VkDescriptorSetLayout[] setLayouts) {
        this.device = device;

        fixed (VkDescriptorSetLayout* setLayoutsPtr = setLayouts) {
            VkDescriptorSetAllocateInfo allocateInfo = new() {
                sType = VkStructureType.DescriptorSetAllocateInfo,
                descriptorPool = pool.pool,
                descriptorSetCount = 1,
                pSetLayouts = setLayoutsPtr
            };

            vkAllocateDescriptorSets(device.logicalDevice.device, &allocateInfo, out set).Check("Failed to create vulkan descriptor set");
        }
    }
}