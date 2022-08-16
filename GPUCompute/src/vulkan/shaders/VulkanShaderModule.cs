using System.Text;
using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.shaders; 

public unsafe struct VulkanShaderModule : IDisposable {
    public readonly VulkanLogicalDevice logicalDevice;
    public VkShaderModule shaderModule;

    public VulkanShaderModule(VulkanLogicalDevice logicalDevice, void* source, int sourceLength) {
        this.logicalDevice = logicalDevice;
        
        VkShaderModuleCreateInfo createInfo = new() {
            sType = VkStructureType.ShaderModuleCreateInfo,
            codeSize = (UIntPtr)sourceLength,
            pCode = (uint*)source
        };

        vkCreateShaderModule(logicalDevice.device, &createInfo, IntPtr.Zero, out shaderModule).Check("Failed to create shader module");
    }

    public void Dispose() => vkDestroyShaderModule(logicalDevice.device, shaderModule, IntPtr.Zero);
}