using GPUCompute.vulkan.commands;
using GPUCompute.vulkan.utils;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.device; 

public unsafe class VulkanLogicalDevice : IDisposable {
    public VulkanPhysicalDevice physicalDevice;
    public VkDevice device;
    public VulkanQueue computeQueue;
    public VulkanQueue transferQueue;

    public VulkanLogicalDevice(VulkanPhysicalDevice physicalDevice) {
        this.physicalDevice = physicalDevice;

        VkPhysicalDeviceFeatures deviceFeatures = physicalDevice.features;

        (uint compute, uint transfer) queueIndices = FindQueues();
        VkDeviceQueueCreateInfo[] queueCreateInfo = CreateQueueCreateInfo(queueIndices);

        VkDeviceCreateInfo createInfo;
        fixed (VkDeviceQueueCreateInfo* queueCreateInfoPtr = queueCreateInfo)
            createInfo = new() {
                sType = VkStructureType.DeviceCreateInfo,
                queueCreateInfoCount = 1,
                pQueueCreateInfos = queueCreateInfoPtr,
                pEnabledFeatures = &deviceFeatures
            };

        fixed (VkDevice* devicePtr = &device)
            vkCreateDevice(physicalDevice.device, &createInfo, null, devicePtr).Check("Failed to create vulkan logical device");

        computeQueue = new(this, queueIndices.compute);
        transferQueue = new(this, queueIndices.transfer);
    }

    private (uint compute, uint transfer) FindQueues() {
        uint computeFamilyIndex = 0;
        uint transferFamilyIndex = 0;
        
        VkQueueFamilyProperties[] queueFamilies = physicalDevice.queueFamilyProperties;
        for (uint i = 0; i < queueFamilies.Length; i++) {
            if ((queueFamilies[i].queueFlags & VkQueueFlags.Compute) != 0) computeFamilyIndex = i;
            if ((queueFamilies[i].queueFlags & VkQueueFlags.Transfer) != 0) transferFamilyIndex = i;
        }
        return (computeFamilyIndex, transferFamilyIndex);
    }

    private VkDeviceQueueCreateInfo[] CreateQueueCreateInfo((uint compute, uint transfer) queueIndices) {
        HashSet<uint> uniqueQueues = new() { queueIndices.compute, queueIndices.transfer };
        float priority = 1;
        float* priorityPtr = &priority;
        
        return uniqueQueues.Select(index => new VkDeviceQueueCreateInfo() {
            sType = VkStructureType.DeviceQueueCreateInfo,
            queueFamilyIndex = index,
            queueCount = 1,
            pQueuePriorities = priorityPtr
        }).ToArray();
    }

    public void Wait() => vkDeviceWaitIdle(device);

    public void Dispose() {
        vkDestroyDevice(device, IntPtr.Zero);
    }

    public void Submit(VkSemaphore? waitSemaphore, VkSemaphore? signalSemaphore, VkFence? submitFence, VulkanCommandBuffer commandBuffer, VulkanQueue queue) {
        VkCommandBuffer buffer = commandBuffer.commandBuffer;
        
        VkSubmitInfo submitInfo = new() {
            sType = VkStructureType.SubmitInfo,
            commandBufferCount = 1,
            pCommandBuffers = &buffer
        };

        if (waitSemaphore != null) {
            VkSemaphore semaphore = waitSemaphore.Value;
            
            submitInfo.waitSemaphoreCount = 1;
            VkPipelineStageFlags waitStages = VkPipelineStageFlags.Transfer;
            submitInfo.pWaitDstStageMask = &waitStages;
            submitInfo.pWaitSemaphores = &semaphore;
        }
        
        if (signalSemaphore != null) {
            VkSemaphore semaphore = signalSemaphore.Value;
            
            submitInfo.signalSemaphoreCount = 1;
            submitInfo.pSignalSemaphores = &semaphore;
        }

        submitFence ??= VkFence.Null;
        
        vkQueueSubmit(queue.queue, 1, &submitInfo, submitFence.Value).Check("Failed to submit vulkan queue");
    }

    public void SubmitWrite(VulkanCommandBuffer commandBuffer) => Submit(null, null, null, commandBuffer, transferQueue);
    public void SubmitRead(VulkanCommandBuffer commandBuffer, VkFence? submitFence) => Submit(null, null, submitFence, commandBuffer, transferQueue);
    public void SubmitCompute(VulkanCommandBuffer commandBuffer, VkSemaphore? wait, VkSemaphore? signal, VkFence? submitFence) => Submit(wait, signal, submitFence, commandBuffer, computeQueue);

    public void SubmitAll(VulkanCommandBuffer? write, VulkanCommandBuffer compute, VulkanCommandBuffer? read) {
        if (write != null) SubmitWrite(write.Value);
        SubmitCompute(compute, write?.semaphore, read?.semaphore, read != null ? VkFence.Null : compute.fence);
        if (read != null) SubmitRead(read.Value, read.Value.fence);
    }

    public void SubmitAllAndWait(VulkanCommandBuffer? write, VulkanCommandBuffer compute, VulkanCommandBuffer? read) {
        SubmitAll(write, compute, read);

        VkFence fence = read?.fence ?? compute.fence;
        vkWaitForFences(device, 1, &fence, true, ulong.MaxValue);
    }
    
    public void SubmitAllAndWait(VulkanCommandBuffer compute) {
        SubmitAll(null, compute, null);

        VkFence fence = compute.fence;
        vkWaitForFences(device, 1, &fence, true, ulong.MaxValue);
    }
}