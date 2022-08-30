using System.Reflection.Emit;
using GPUCompute.utils;

namespace GPUCompute.spirv.cs; 

public readonly struct IlInstruction {
    public readonly OpCode opCode;
    public readonly ulong operand;

    public IlInstruction(OpCode opCode, ulong operand) {
        this.opCode = opCode;
        this.operand = operand;
    }

    public static IlInstruction Parse(byte[] raw, ref int pos) {
        OpCode opCode = IlOpCodes.ParseOpCode(raw, ref pos);
        ulong operand = ParseOperand(opCode, raw, ref pos);
        
        return new(opCode, operand);
    }

    public override string ToString() => opCode + " " + operand;

    private static ulong ParseOperand(OpCode opCode, byte[] raw, ref int pos) => opCode.OperandType switch {
        OperandType.InlineBrTarget => raw.ReadU32(ref pos),
        OperandType.InlineField => raw.ReadU32(ref pos),
        OperandType.InlineI => raw.ReadU32(ref pos),
        OperandType.InlineI8 => raw.ReadU64(ref pos),
        OperandType.InlineMethod => raw.ReadU32(ref pos),
        OperandType.InlineNone => 0,
        OperandType.InlinePhi => 0,
        OperandType.InlineR => raw.ReadU64(ref pos),
        OperandType.InlineSig => raw.ReadU32(ref pos),
        OperandType.InlineString => raw.ReadU32(ref pos),
        OperandType.InlineSwitch => raw.ReadU32(ref pos),
        OperandType.InlineTok => raw.ReadU32(ref pos), //! check FieldRef, MethodRef and TypeRef size
        OperandType.InlineType => raw.ReadU32(ref pos),
        OperandType.InlineVar => raw.ReadU16(ref pos),
        OperandType.ShortInlineBrTarget => raw.ReadU8(ref pos),
        OperandType.ShortInlineI => raw.ReadU8(ref pos),
        OperandType.ShortInlineR => raw.ReadU32(ref pos),
        OperandType.ShortInlineVar => raw.ReadU8(ref pos),
        _ => throw new ArgumentOutOfRangeException()
    };
}