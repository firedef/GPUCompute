using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public struct SpvFunction {
    public uint returnType;
    public uint id;
    public SpvFunctionControlMask control;
    public uint functionType;
    public (uint type, uint id)[] parameters;

    public SpvFunctionBlock nextBlock;
}