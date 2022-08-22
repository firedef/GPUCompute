using System.Runtime.InteropServices;
using GPUCompute.core;
using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.descriptors;
using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.shaders; 

public unsafe struct VulkanComputePipeline : IDisposable {
    public VulkanLogicalDevice logicalDevice;
    public VkPipeline pipeline;
    public VkPipelineLayout layout;

    public VulkanComputePipeline(VulkanLogicalDevice logicalDevice, VulkanShaderModule shaderModule, VkDescriptorSetLayout[] descriptorSetLayouts) {
        this.logicalDevice = logicalDevice;
        VkComputePipelineCreateInfo createInfo = CreateCreateInfo();
        createInfo.stage.module = shaderModule.shaderModule;
        createInfo.layout = layout = CreatePipelineLayout(logicalDevice, descriptorSetLayouts);
        
        vkCreateComputePipelines(logicalDevice.device, VkPipelineCache.Null, 1, &createInfo, IntPtr.Zero, out pipeline).Check("Failed to create vulkan compute pipeline");
    }

    private static VkComputePipelineCreateInfo CreateCreateInfo() {
        VkPipelineShaderStageCreateInfo shaderStageCreateInfo = new() {
            sType = VkStructureType.PipelineShaderStageCreateInfo,
            stage = VkShaderStageFlags.Compute,
            pName = (byte*)Marshal.StringToHGlobalAnsi("main")
        };

        VkComputePipelineCreateInfo pipelineCreateInfo = new() {
            sType = VkStructureType.ComputePipelineCreateInfo,
            stage = shaderStageCreateInfo
        };

        return pipelineCreateInfo;
    }

    private static VkPipelineLayout CreatePipelineLayout(VulkanLogicalDevice logicalDevice, VkDescriptorSetLayout[] descriptorSetLayouts) {
        VkPipelineLayout pipelineLayout;
        
        fixed (VkDescriptorSetLayout* descriptorSetLayoutsPtr = descriptorSetLayouts) {
            VkPipelineLayoutCreateInfo layoutCreateInfo = new() {
                sType = VkStructureType.PipelineLayoutCreateInfo,
                setLayoutCount = (uint)descriptorSetLayouts.Length,
                pSetLayouts = descriptorSetLayoutsPtr,
            };
            vkCreatePipelineLayout(logicalDevice.device, &layoutCreateInfo, IntPtr.Zero, out pipelineLayout).Check("Failed to create vulkan pipeline layout");
        }
        return pipelineLayout;
    }

    public static VulkanComputePipeline[] CreatePipelines(VulkanLogicalDevice logicalDevice, VulkanShaderModule[] shaderModules, VkDescriptorSetLayout[][] descriptorSetLayouts) {
        VkComputePipelineCreateInfo pipelineCreateInfo = CreateCreateInfo();

        int c = shaderModules.Length;
        VulkanComputePipeline[] pipelines = new VulkanComputePipeline[c];

        for (int i = 0; i < c; i++) {
            pipelineCreateInfo.layout = CreatePipelineLayout(logicalDevice, descriptorSetLayouts[i]);
            pipelineCreateInfo.stage.module = shaderModules[i].shaderModule;
            
            vkCreateComputePipelines(logicalDevice.device, VkPipelineCache.Null, 1, &pipelineCreateInfo, IntPtr.Zero, out VkPipeline pipeline).Check("Failed to create vulkan compute pipeline");

            pipelines[i] = new() {
                logicalDevice = logicalDevice,
                layout = pipelineCreateInfo.layout,
                pipeline = pipeline
            };
        }

        return pipelines;
    }

    public void Dispose() {
        vkDestroyPipeline(logicalDevice.device, pipeline, IntPtr.Zero);
        vkDestroyPipelineLayout(logicalDevice.device, layout, IntPtr.Zero);
    }

    public void Bind(VulkanCommandBuffer commandBuffer) => vkCmdBindPipeline(commandBuffer.commandBuffer, VkPipelineBindPoint.Compute, pipeline);
    
    public void BindDescriptorSets(VulkanCommandBuffer commandBuffer, uint firstSet, uint count, VkDescriptorSet[] sets) {
        fixed (VkDescriptorSet* setsPtr = sets)
            vkCmdBindDescriptorSets(commandBuffer.commandBuffer, VkPipelineBindPoint.Compute, layout, firstSet, count, setsPtr, 0, IntPtr.Zero);
    }

    public void BindDescriptorSets(VulkanCommandBuffer commandBuffer, params DescriptorSet[] sets) =>
        BindDescriptorSets(commandBuffer, 0, (uint)sets.Length, sets.Select(v => v.set.set).ToArray());
}