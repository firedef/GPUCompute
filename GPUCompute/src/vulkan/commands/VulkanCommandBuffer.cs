using GPUCompute.vulkan.device;
using GPUCompute.vulkan.utils;
using MathStuff.vectors;
using Vulkan;
using static Vulkan.VulkanNative;

namespace GPUCompute.vulkan.commands; 

public unsafe struct VulkanCommandBuffer : IDisposable {
    public VulkanLogicalDevice logicalDevice;
    public VkCommandBuffer commandBuffer;
    public VkFence fence;
    public VkSemaphore semaphore;

    public VulkanCommandBuffer(VulkanCommandPool pool, VulkanLogicalDevice logicalDevice) : this() {
        this.logicalDevice = logicalDevice;
        
        CreateCommandBuffer(pool);
        CreateFence();
        CreateSemaphore();
    }

    private void CreateCommandBuffer(VulkanCommandPool pool) {
        VkCommandBufferAllocateInfo allocateInfo = new() {
            sType = VkStructureType.CommandBufferAllocateInfo,
            commandPool = pool.commandPool,
            level = VkCommandBufferLevel.Primary,
            commandBufferCount = 1
        };

        fixed (VkCommandBuffer* commandBufferPtr = &commandBuffer)
            vkAllocateCommandBuffers(logicalDevice.device, &allocateInfo, commandBufferPtr).Check("Failed to create vulkan command buffer");
    }

    private void CreateFence() {
        VkFenceCreateInfo createInfo = new() {
            sType = VkStructureType.FenceCreateInfo,
            flags = VkFenceCreateFlags.Signaled
        };
        fixed (VkFence* fencePtr = &fence)
            vkCreateFence(logicalDevice.device, &createInfo, null, fencePtr).Check("Failed to create vulkan command buffer fence");
    }

    private void CreateSemaphore() {
        VkSemaphoreCreateInfo createInfo = new() {
            sType = VkStructureType.SemaphoreCreateInfo
        };
        fixed (VkSemaphore* semaphorePtr = &semaphore)
            vkCreateSemaphore(logicalDevice.device, &createInfo, null, semaphorePtr).Check("Failed to create vulkan command buffer semaphore");
    }

    public void Reset() => vkResetCommandBuffer(commandBuffer, VkCommandBufferResetFlags.None);

    public void Begin() {
        VkCommandBufferBeginInfo beginInfo = new() {
            sType = VkStructureType.CommandBufferBeginInfo
        };
        vkBeginCommandBuffer(commandBuffer, &beginInfo).Check("Failed to begin vulkan command buffer");
    }

    public void End() => vkEndCommandBuffer(commandBuffer).Check("Failed to end vulkan command buffer");

    public void Dispatch(int3 dimensions) => vkCmdDispatch(commandBuffer, (uint)dimensions.x, (uint)dimensions.y, (uint)dimensions.z);

    public void Dispose() {
        vkDestroySemaphore(logicalDevice.device, semaphore, IntPtr.Zero);
        vkDestroyFence(logicalDevice.device, fence, IntPtr.Zero);
    }
}