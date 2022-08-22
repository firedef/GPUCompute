using GPUCompute.core;
using GPUCompute.core.buffers;
using GPUCompute.vulkan.buffers;
using GPUCompute.vulkan.descriptors;
using Vulkan;
using Buffer = GPUCompute.core.buffers.Buffer;
using Environment = GPUCompute.core.Environment;

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

layout(set = 0, binding = 0) readonly buffer InputBuffer {
    float floats[];
} sourceData;

layout(set = 1, binding = 0) buffer OutputBuffer {
    float floats[];
} outputData;


void main() {
	uint i = gl_GlobalInvocationID.x;
    outputData.floats[i] = sourceData.floats[i] * 3.0;
    for (float a = 0.0; a < 100000.0; a++) {
        outputData.floats[i] += sin(outputData.floats[i]);
    }
}
";
        
        using Device device = new();
        using Environment env = new(device);

        const int c = 2_500_000;
        Buffer<float> input = new(device.allocator, c, BufferMode.write);
        Buffer<float> output = new(device.allocator, c, BufferMode.read);
        
        input[0] = 69;
        input[10] = 42;
        
        using Job job = new(env, shaderSrc, 2);
        job.Execute(c / 256, input, output);

        Console.WriteLine(input[0] + " " + input[10]);
        Console.WriteLine(output[0] + " " + output[10]);

        device.Wait();
    }
}