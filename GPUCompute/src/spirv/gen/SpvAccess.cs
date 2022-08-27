namespace GPUCompute.spirv.gen; 

public interface ISpvAccess {
    public Id ptr { get; }
    public SpvFunction fun { get; }
    public SpvType type { get; }

    public Id Load();
    public void Store(Id val);
}

public struct SpvAccess : ISpvAccess, ISpvId {
    public Id ptr { get; }
    public SpvFunction fun { get; }
    public SpvType type { get; }
    public uint id => ptr;

    public SpvAccess(Id ptr, SpvFunction fun, SpvType type) {
        this.ptr = ptr;
        this.fun = fun;
        this.type = type;
    }

    public Id Load() => fun.instructions.Load(type, ptr);
    public void Store(Id val) => fun.instructions.Store(ptr, val);
}