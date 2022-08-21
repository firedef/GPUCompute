using GPUCompute.core;
using GPUCompute.vulkan.instance;
using GPUCompute.vulkan.utils;
using GPUCompute.vulkan.vma;
using shaderc;
using Vulkan;

namespace GPUCompute.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public unsafe void Test1() {
        const string shaderSrc = @"#version 310 es
layout (local_size_x = 256) in;

layout(set = 0, binding = 0) uniform Config{
    mat4 transform;
    int matrixCount;
} opData;

layout(set = 0, binding = 1) readonly buffer  InputBuffer{
    mat4 matrices[];
} sourceData;

layout(set = 0, binding = 2) buffer  OutputBuffer{
    mat4 matrices[];
} outputData;


void main()
{
    //grab global ID
	uint gID = gl_GlobalInvocationID.x;
    //make sure we don't access past the buffer size
    if(gID < 1u)
    {
        // do math
        outputData.matrices[gID] = sourceData.matrices[gID] * opData.transform;
    }
}
";

        using Device device = new();
        using CommandPool commandPool = device.CreatePool();
        using CommandBuffer commandBuffer = commandPool.CreateBuffer();

        using ComputeShader shader = device.CreateShader(shaderSrc);


        Vma.VmaAllocatorCreateInfo createInfo = new();
        createInfo.device = device.logicalDevice.device.Handle;
        createInfo.physicalDevice = device.physicalDevice.device.Handle;
        createInfo.instance = VulkanInstance.instance.Handle;

        Vma.vmaCreateAllocator(ref createInfo, out IntPtr ptr).Check("vma");
        Vma.VmaAllocationCreateInfo allocationCreateInfo = new();
        allocationCreateInfo.usage = Vma.VmaMemoryUsage.VMA_MEMORY_USAGE_GPU_ONLY;

        VkBufferCreateInfo bufferCreateInfo = new();
        bufferCreateInfo.size = 65536;
        bufferCreateInfo.usage = VkBufferUsageFlags.TransferDst | VkBufferUsageFlags.StorageBuffer;

        Vma.vmaCreateBuffer(ptr, (IntPtr)(&bufferCreateInfo), ref allocationCreateInfo, out ulong pBuffer, out IntPtr pAllocation, IntPtr.Zero).Check("create buffer");
        
        Vma.vmaDestroyBuffer(ptr, pBuffer, pAllocation);
        Vma.vmaDestroyAllocator(ptr);
        

        // commandBuffer.Begin();
        // shader.Bind(commandBuffer);
        // commandBuffer.Dispatch(new(16,16,16));
        // commandBuffer.End();
        //
        // commandBuffer.Execute();
        
        device.Wait();
    }
}