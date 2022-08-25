using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public struct SpvVariable {
    public SpvStorageClass storageClass;
    public uint owner;
    public uint type;
    public uint id;
}