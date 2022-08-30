using GPUCompute.spirv.gen.types;

namespace GPUCompute.spirv.gen.stack; 

public interface ISpvStackItem {
    
}

public readonly record struct SpvStackId(Id id) : ISpvStackItem, ISpvId {
    public readonly Id id = id;
    uint ISpvId.id => id;
    
    public static implicit operator uint(SpvStackId v) => v.id;
    public static implicit operator SpvStackId(uint v) => new(v);
    public static implicit operator Id(SpvStackId v) => v.id;
    public static implicit operator SpvStackId(Id v) => new(v);
}

public readonly record struct SpvStackType(SpvType type) : ISpvStackItem {
    public readonly SpvType type = type;
    
    public static implicit operator SpvType(SpvStackType v) => v.type;
    public static implicit operator SpvStackType(SpvType v) => new(v);
}

public readonly record struct SpvStackLiteral(params uint[] values) : ISpvStackItem {
    public readonly uint[] values = values;
    
    public static implicit operator uint[](SpvStackLiteral v) => v.values;
    public static implicit operator SpvStackLiteral(uint[] v) => new(v);
}

public readonly record struct SpvStackValue(uint value) : ISpvStackItem {
    public readonly uint value = value;
    
    public static implicit operator uint(SpvStackValue v) => v.value;
    public static implicit operator SpvStackValue(uint v) => new(v);
}