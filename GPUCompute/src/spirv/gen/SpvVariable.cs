using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public class SpvVariable : ISpvId {
    public SpvStorageClass storageClass;
    public uint owner;
    public SpvType type;
    public Id id;
    uint ISpvId.id => id;

    public static implicit operator Id(SpvVariable v) => v.id;
    public static implicit operator uint(SpvVariable v) => v.id;
}

public class SpvFuncVariable : SpvVariable, ISpvAccess {
    public SpvFunction function;
    Id ISpvAccess.ptr => id;
    SpvFunction ISpvAccess.fun => function;
    SpvType ISpvAccess.type => type;

    public Id value {
        get => Load();
        set => Store(value);
    }

    public void Store(Id value) => function.instructions.Store(id, value);
    public Id Load() => function.instructions.Load(type, id);
}

public class SpvStorageBuffer : SpvVariable {
    public SpvType elementType;

    public SpvStorageBuffer(SpvType elementType, SpvType type, Id id) {
        this.elementType = elementType;
        this.type = type;
        this.id = id;
        storageClass = SpvStorageClass.StorageClassStorageBuffer;
    }

    public SpvAccess Access(SpvFunction fun, params Id[] indexes) =>
        new(fun.instructions.AccessChain(SpvTypes.Pointer(elementType, SpvStorageClass.StorageClassUniform), id, indexes), fun, elementType);

    public Id Load(SpvFunction fun, params Id[] indexes) => Access(fun, indexes).Load();
    public void Store(SpvFunction fun, Id val, params Id[] indexes) => Access(fun, indexes).Store(val);
}