using System.Runtime.InteropServices;
using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.device;
using GPUCompute.vulkan.instance;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.shaders; 

public unsafe struct VulkanComputePipeline : IDisposable {
    public VulkanLogicalDevice logicalDevice;
    public VkPipeline pipeline;
    public VkPipelineLayout layout;

    public VulkanComputePipeline(VulkanLogicalDevice logicalDevice, VulkanShaderModule shaderModule) {
        this.logicalDevice = logicalDevice;
        VkComputePipelineCreateInfo createInfo = CreateCreateInfo(logicalDevice);
        createInfo.stage.module = shaderModule.shaderModule;
        createInfo.layout = layout = CreatePipelineLayout(logicalDevice);
        
        vkCreateComputePipelines(logicalDevice.device, VkPipelineCache.Null, 1, &createInfo, IntPtr.Zero, out pipeline).Check("Failed to create vulkan compute pipeline");
    }

    private static VkComputePipelineCreateInfo CreateCreateInfo(VulkanLogicalDevice logicalDevice) {
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

    private static VkPipelineLayout CreatePipelineLayout(VulkanLogicalDevice logicalDevice) {
        VkPipelineLayoutCreateInfo layoutCreateInfo = new() {
            sType = VkStructureType.PipelineLayoutCreateInfo
        };
        vkCreatePipelineLayout(logicalDevice.device, &layoutCreateInfo, IntPtr.Zero, out VkPipelineLayout pipelineLayout).Check("Failed to create vulkan pipeline layout");
        return pipelineLayout;
    }

    public static VulkanComputePipeline[] CreatePipelines(VulkanLogicalDevice logicalDevice, VulkanShaderModule[] shaderModules) {
        VkComputePipelineCreateInfo pipelineCreateInfo = CreateCreateInfo(logicalDevice);

        int c = shaderModules.Length;
        VulkanComputePipeline[] pipelines = new VulkanComputePipeline[c];

        for (int i = 0; i < c; i++) {
            pipelineCreateInfo.layout = CreatePipelineLayout(logicalDevice);
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
}