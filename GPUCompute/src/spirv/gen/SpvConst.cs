using GPUCompute.spirv.emit;

namespace GPUCompute.spirv.gen;

public interface ISpvConst {
    public void Emit(SpirVEmitter code);
}

public readonly record struct SpvConst(uint type, uint id, uint[] value) : ISpvConst {
    public readonly uint type = type;
    public readonly uint id = id;
    public readonly uint[] value = value;

    public void Emit(SpirVEmitter code) => code.EmitOpConstant(type, id, value);
}

public readonly record struct SpvConstComposite(uint type, uint id, uint[] constituents) : ISpvConst {
    public readonly uint type = type;
    public readonly uint id = id;
    public readonly uint[] constituents = constituents;

    public void Emit(SpirVEmitter code) => code.EmitOpConstantComposite(type, id, constituents);
}