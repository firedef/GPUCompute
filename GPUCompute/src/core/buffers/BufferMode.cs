namespace GPUCompute.core.buffers; 

[Flags]
public enum BufferMode {
    cpuOnly = 0b000,
    read = 0b001,
    write = 0b010,
    readWrite = 0b011,
    gpuOnly = 0b100,
}