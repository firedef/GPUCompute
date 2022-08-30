using System.Reflection;
using GPUCompute.attributes;
using GPUCompute.core.buffers;
using GPUCompute.spirv.cs;
using GPUCompute.spirv.cs.info;
using GPUCompute.spirv.gen;

namespace GPUCompute.core; 

public class Environment : IDisposable {
    public readonly Device device;
    public readonly CommandPool commandPool;
    public readonly CommandBuffer commandBuffer;

    public Environment(Device device) {
        this.device = device;
        commandPool = new(device);
        commandBuffer = new(device, commandPool);
    }

    public void Dispose() {
        commandPool.Dispose();
        commandBuffer.Dispose();
        GC.SuppressFinalize(this);
    }

    ~Environment() {
        commandPool.Dispose();
        commandBuffer.Dispose();
    }
    
    public unsafe GpuCompiledMethod Compile<T>(T fun) where T : Delegate {
        SpirVCodeGenerator code = new(new(256, 1, 1));
        IlConverter converter = new(code, fun.Method, true);
        converter.Generate();
        code.Generate();
        code.PrintByteCode();

        GpuCompiledMethod compiled = new(this);
        compiled.CreateDescriptors(converter.buffers);
        compiled.CreateShader(converter.code.code.GetByteCode());

        return compiled;
    }
}