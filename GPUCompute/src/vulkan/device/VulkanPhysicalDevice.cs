using GPUCompute.vulkan.instance;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.device; 

public unsafe struct VulkanPhysicalDevice {
    public VkPhysicalDevice device;

    public VkPhysicalDeviceProperties properties { get { vkGetPhysicalDeviceProperties(device, out VkPhysicalDeviceProperties v); return v; } }
    public VkPhysicalDeviceFeatures features { get { vkGetPhysicalDeviceFeatures(device, out VkPhysicalDeviceFeatures v); return v; } }

    public VkQueueFamilyProperties[] queueFamilyProperties {
        get {
            uint c;
            vkGetPhysicalDeviceQueueFamilyProperties(device, &c, null);
            VkQueueFamilyProperties[] families = new VkQueueFamilyProperties[c];
            fixed(VkQueueFamilyProperties* familiesPtr = families)
                vkGetPhysicalDeviceQueueFamilyProperties(device, &c, familiesPtr);
            return families;
        }
    }

    public VkPhysicalDeviceType deviceType => properties.deviceType;

    public bool isGpu => deviceType != VkPhysicalDeviceType.Cpu;

    public VulkanPhysicalDevice() : this(ChooseDevice(EnumerateDevices()).device) { }

    public VulkanPhysicalDevice(VkPhysicalDevice device) => this.device = device;

    public static unsafe VulkanPhysicalDevice[] EnumerateDevices() {
        uint c;
        
        vkEnumeratePhysicalDevices(VulkanInstance.instance, &c, IntPtr.Zero);
        VkPhysicalDevice[] devices = new VkPhysicalDevice[c];
        
        fixed(VkPhysicalDevice* devicesPtr = devices)
            vkEnumeratePhysicalDevices(VulkanInstance.instance, &c, devicesPtr);

        return devices.Select(v => new VulkanPhysicalDevice(v)).ToArray();
    }

    public static VulkanPhysicalDevice ChooseDevice(VulkanPhysicalDevice[] devices) {
        if (devices.Length == 0) throw new VulkanException("No devices with GPU support found");

        return devices.MaxBy(device => {
            int points = 0;

            VkPhysicalDeviceProperties properties = device.properties;

            if (properties.deviceType == VkPhysicalDeviceType.IntegratedGpu) points += 250;
            if (properties.deviceType == VkPhysicalDeviceType.Other) points += 500;
            if (properties.deviceType == VkPhysicalDeviceType.DiscreteGpu) points += 1000;
            if (properties.deviceType == VkPhysicalDeviceType.VirtualGpu) points += 1000;

            return points;
        });
    }
}