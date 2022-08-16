using System.Runtime.InteropServices;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.instance; 

public static unsafe class VulkanInstance{
    public static VkInstance instance;

    static VulkanInstance() {
        VkApplicationInfo appInfo = new() {
            sType = VkStructureType.ApplicationInfo,
            pApplicationName = (byte*)Marshal.StringToHGlobalAnsi("GPU Compute")
        };

        VkInstanceCreateInfo createInfo = new() {
            sType = VkStructureType.InstanceCreateInfo,
            pApplicationInfo = &appInfo
        };

        fixed(VkInstance* instancePtr = &instance)
            vkCreateInstance(&createInfo, IntPtr.Zero, instancePtr).Check("Failed to create vulkan instance");
    }

    public static void Dispose() {
        vkDestroyInstance(instance, IntPtr.Zero);
    }
}