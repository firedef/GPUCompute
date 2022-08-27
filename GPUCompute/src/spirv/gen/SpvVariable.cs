using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public class SpvVariable : ISpvId {
    public SpvStorageClass storageClass;
    public uint owner;
    public SpvType type;
    public uint id;
    uint ISpvId.id => id;

    public static implicit operator Id(SpvVariable v) => v.id;
    public static implicit operator uint(SpvVariable v) => v.id;
}

public class SpvFuncVariable : SpvVariable {
    public SpvFunction function;

    public Id value {
        get => Load();
        set => Store(value);
    }

    public void Store(Id value) => function.instructions.Store(id, value);
    public Id Load() => function.instructions.Load(type, id);
}