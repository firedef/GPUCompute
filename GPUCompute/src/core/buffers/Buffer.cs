using System.Collections;
using GPUCompute.vulkan.buffers;

namespace GPUCompute.core.buffers;

public abstract class Buffer : IDisposable {
    public readonly BufferMode mode;
    public readonly GpuBuffer gpuBuffer;

    protected Buffer(BufferMode mode, GpuBuffer gpuBuffer) {
        this.mode = mode;
        this.gpuBuffer = gpuBuffer;
    }

    public abstract void BeforeJob();
    public abstract void AfterJob();
    
    public void Use(DescriptorSet set, uint binding) => gpuBuffer.Use(set, binding);

    protected abstract void Dispose(bool disposing);

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

public class Buffer<T> : Buffer, IEnumerable<T> where T : unmanaged {
    public readonly T[] cpuBuffer;

    public unsafe Buffer(VmaAllocator allocator, int size, BufferMode mode) : base(mode, new(allocator, (ulong)(size * sizeof(T)))) {
        cpuBuffer = mode == BufferMode.gpuOnly ? Array.Empty<T>() : new T[size];
    }

    public override void BeforeJob() {
        if ((mode & BufferMode.write) != 0) gpuBuffer.CopyToDevice(cpuBuffer);
    }
    
    public override void AfterJob() {
        if ((mode & BufferMode.read) != 0) gpuBuffer.CopyFromDevice(cpuBuffer);
    }
    
    public T this[int i] {
        get => cpuBuffer[i];
        set => cpuBuffer[i] = value;
    }

    protected override void Dispose(bool disposing) => gpuBuffer.Dispose();
    ~Buffer() => Dispose();

    public IEnumerator<T> GetEnumerator() => new Enumerator(this, 0);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    private class Enumerator : IEnumerator<T> {
        private Buffer<T> _buffer;
        private int _position;

        public Enumerator(Buffer<T> buffer, int position) {
            _buffer = buffer;
            _position = position;
        }
        public bool MoveNext() => _position++ < _buffer.cpuBuffer.Length;
        public void Reset() => _position = 0;
        public T Current => _buffer[_position];
        object IEnumerator.Current => Current;
        public void Dispose() { }
    }
}