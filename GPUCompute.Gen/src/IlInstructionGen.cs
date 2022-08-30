using System.Text;
using GPUCompute.spirv.cs;

namespace GPUCompute.Gen; 

public static class IlInstructionGen {
    public static string GenerateOpCodes() {
        string[] names = Enum.GetNames(typeof(IlOpCodeValues));
        ushort[] values = Enum.GetValues<IlOpCodeValues>().Select(v => (ushort)v).ToArray();
        
        StringBuilder sb = new();
        for (int i = 0; i < names.Length; i++) {
            string target = (values[i] & 0xFF00) == 0 ? "oneByteOps" : "twoByteOps";
            sb.AppendLine($"{target}[{values[i] & 0x00FF}] = OpCodes.{names[i]};");
        }
        return sb.ToString();
    }
}