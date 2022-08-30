using System.Reflection;

namespace GPUCompute.spirv.cs; 

public readonly struct IlCode {
    public readonly IlInstruction[] instructions;

    public IlCode(IlInstruction[] instructions) => this.instructions = instructions;

    public IlCode(byte[] raw) => instructions = Parse(raw);

    private static IlInstruction[] Parse(byte[] raw) {
        int pos = 0;
        List<IlInstruction> instructions = new();
        while (pos < raw.Length) instructions.Add(IlInstruction.Parse(raw, ref pos));
        return instructions.ToArray();
    }
}