using System.Text;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.emit.enums.extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;
using StringBuilder = System.Text.StringBuilder;

namespace GPUCompute.Gen; 

public static class InstructionGen {
    public static string Generate() {
        string path = @"/mnt/sdb/projects/cs/GPUCompute/GPUCompute/src/spirv/emit/SpirVEmitter.cs";
        using FileStream fs = new(path, FileMode.Open);
        
        SourceText src = SourceText.From(fs);
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(src, CSharpParseOptions.Default);

        SyntaxNode root = syntaxTree.GetRoot();

        StringBuilder sb = new();
        foreach (MethodDeclarationSyntax decl in root.DescendantNodes().OfType<MethodDeclarationSyntax>().Where(v => v.Identifier.ToString().StartsWith("EmitOp"))) {
            string opName = decl.Identifier.ToString().Replace("Emit", "");
            if (opName is "OpCode" or "Op" or "Operand") continue;

            sb.AppendLine($"public record {opName}({decl.ParameterList.Parameters}) : SpvInstruction {{");

            foreach (ParameterSyntax parameter in decl.ParameterList.Parameters)
                sb.AppendLine($"  public readonly {parameter} = {parameter.Identifier};");

            string args = string.Join(", ", decl.ParameterList.Parameters.Select(v => v.Identifier));
            sb.AppendLine($"public override void Emit(SpirVEmitter code) => code.Emit{opName}({args});");
            
            sb.AppendLine("}");
        }

        return sb.ToString();
    }

    private static readonly ExtInst[] _extInstructions = new ExtInst[] {
        new(SpvExtInstGlslStd.Round, "x"),
        new(SpvExtInstGlslStd.RoundEven, "x"),
        new(SpvExtInstGlslStd.Trunc, "x"),
        new(SpvExtInstGlslStd.FAbs, "x"),
        new(SpvExtInstGlslStd.SAbs, "x"),
        new(SpvExtInstGlslStd.FSign, "x"),
        new(SpvExtInstGlslStd.SSign, "x"),
        new(SpvExtInstGlslStd.Floor, "x"),
        new(SpvExtInstGlslStd.Ceil, "x"),
        new(SpvExtInstGlslStd.Fract, "x"),
        new(SpvExtInstGlslStd.Radians, "degrees"),
        new(SpvExtInstGlslStd.Degrees, "radians"),
        new(SpvExtInstGlslStd.Sin, "x"),
        new(SpvExtInstGlslStd.Cos, "x"),
        new(SpvExtInstGlslStd.Tan, "x"),
        new(SpvExtInstGlslStd.Asin, "x"),
        new(SpvExtInstGlslStd.Acos, "x"),
        new(SpvExtInstGlslStd.Atan, "x"),
        new(SpvExtInstGlslStd.Sinh, "x"),
        new(SpvExtInstGlslStd.Cosh, "x"),
        new(SpvExtInstGlslStd.Tanh, "x"),
        new(SpvExtInstGlslStd.Asinh, "x"),
        new(SpvExtInstGlslStd.Acosh, "x"),
        new(SpvExtInstGlslStd.Atanh, "x"),
        new(SpvExtInstGlslStd.Atan2, "y", "x"),
        new(SpvExtInstGlslStd.Pow, "x", "y"),
        new(SpvExtInstGlslStd.Exp, "x"),
        new(SpvExtInstGlslStd.Log, "x"),
        new(SpvExtInstGlslStd.Exp2, "x"),
        new(SpvExtInstGlslStd.Log2, "x"),
        new(SpvExtInstGlslStd.Sqrt, "x"),
        new(SpvExtInstGlslStd.InverseSqrt, "x"),
        new(SpvExtInstGlslStd.Determinant, "x"),
        new(SpvExtInstGlslStd.MatrixInverse, "x"),
        new(SpvExtInstGlslStd.Modf, "x", "i"),
        new(SpvExtInstGlslStd.ModfStruct, "x"),
        new(SpvExtInstGlslStd.FMin, "x", "y"),
        new(SpvExtInstGlslStd.UMin, "x", "y"),
        new(SpvExtInstGlslStd.SMin, "x", "y"),
        new(SpvExtInstGlslStd.FMax, "x", "y"),
        new(SpvExtInstGlslStd.UMax, "x", "y"),
        new(SpvExtInstGlslStd.SMax, "x", "y"),
        new(SpvExtInstGlslStd.FClamp, "x", "min", "max"),
        new(SpvExtInstGlslStd.UClamp, "x", "min", "max"),
        new(SpvExtInstGlslStd.SClamp, "x", "min", "max"),
        new(SpvExtInstGlslStd.FMix, "a", "b", "time"),
        new(SpvExtInstGlslStd.Step, "edge", "x"),
        new(SpvExtInstGlslStd.SmoothStep, "edge0", "edge1", "x"),
        new(SpvExtInstGlslStd.Fma, "a", "b", "c"),
        new(SpvExtInstGlslStd.Frexp, "x", "exp"),
        new(SpvExtInstGlslStd.FrexpStruct, "x"),
        new(SpvExtInstGlslStd.Ldexp, "x", "exp"),
        new(SpvExtInstGlslStd.PackSnorm4x8, "v"),
        new(SpvExtInstGlslStd.PackUnorm4x8, "v"),
        new(SpvExtInstGlslStd.PackSnorm2x16, "v"),
        new(SpvExtInstGlslStd.PackUnorm2x16, "v"),
        new(SpvExtInstGlslStd.PackHalf2x16, "v"),
        new(SpvExtInstGlslStd.PackDouble2x32, "v"),
        new(SpvExtInstGlslStd.UnpackSnorm2x16, "p"),
        new(SpvExtInstGlslStd.UnpackUnorm2x16, "p"),
        new(SpvExtInstGlslStd.UnpackHalf2x16, "v"),
        new(SpvExtInstGlslStd.UnpackSnorm4x8, "p"),
        new(SpvExtInstGlslStd.UnpackUnorm4x8, "p"),
        new(SpvExtInstGlslStd.UnpackDouble2x32, "v"),
        new(SpvExtInstGlslStd.Length, "x"),
        new(SpvExtInstGlslStd.Distance, "p0", "p1"),
        new(SpvExtInstGlslStd.Cross, "x", "y"),
        new(SpvExtInstGlslStd.Normalize, "x"),
        new(SpvExtInstGlslStd.FaceForward, "n", "i", "nRef"),
        new(SpvExtInstGlslStd.Reflect, "i", "n"),
        new(SpvExtInstGlslStd.Refract, "i", "n", "eta"),
        new(SpvExtInstGlslStd.FindILsb, "value"),
        new(SpvExtInstGlslStd.FindSMsb, "value"),
        new(SpvExtInstGlslStd.FindUMsb, "value"),
        new(SpvExtInstGlslStd.InterpolateAtCentroid, "interpolant"),
        new(SpvExtInstGlslStd.InterpolateAtSample, "interpolant", "sample"),
        new(SpvExtInstGlslStd.InterpolateAtOffset, "interpolant", "offset"),
        new(SpvExtInstGlslStd.NMin, "x", "y"),
        new(SpvExtInstGlslStd.NMax, "x", "y"),
        new(SpvExtInstGlslStd.NClamp, "x", "min", "max"),
    };

    public static string GenerateExtGlsl() {
        StringBuilder sb = new();

        foreach (ExtInst instruction in _extInstructions) {
            string argsWithType = string.Join(", ", instruction.operands.Select(v => $"id {v}"));
            string args = string.Join(", ", instruction.operands);
            
            sb.AppendLine($"public readonly record struct ExtOp{instruction.name}(id resultType, id result, id instructionSet, {argsWithType}) : ISpvInstruction {{");

            sb.AppendLine("  public readonly id resultType = resultType;");
            sb.AppendLine("  public readonly id result = result;");
            sb.AppendLine("  public readonly id instructionSet = instructionSet;");
            foreach (string operand in instruction.operands)
                sb.AppendLine($"  public readonly id {operand} = {operand};");
            
            sb.AppendLine($"  public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.{instruction.name}, {args});");
            sb.AppendLine("}");
        }

        return sb.ToString();
    }

    public static string GenerateOpenCl() {
        const string path = @"data/OpenClStdInstructions.json";
        ExtInstJson json = JsonConvert.DeserializeObject<ExtInstJson>(File.ReadAllText(path))!;
        
        StringBuilder sb = new();

        foreach (ExtInstJson.Instruction instruction in json.instructions) {
            string argsWithType = string.Join(", ", instruction.operands.Select(v => v.quantifier is "*" ? $"params id[] {FixString(v.name)}" : $"id {FixString(v.name)}"));
            string args = string.Join(", ", instruction.operands.Select(v => FixString(v.name)));
            
            sb.AppendLine($"public readonly record struct Op{char.ToUpper(instruction.opname[0]) + instruction.opname[1..]}(id resultType, id result, id instructionSet, {argsWithType}) : ISpvInstruction {{");
            
            sb.AppendLine("  public readonly id resultType = resultType;");
            sb.AppendLine("  public readonly id result = result;");
            sb.AppendLine("  public readonly id instructionSet = instructionSet;");
            foreach (ExtInstJson.Instruction.Operand operand in instruction.operands)
                sb.AppendLine($"  public readonly id{(operand.quantifier is "*" ? "[]" : "")} {FixString(operand.name)} = {FixString(operand.name)};");

            if (instruction.operands.Any(v => v.quantifier is "*")) {
                sb.AppendLine("  public void Emit(SpirVEmitter code) {");
                sb.AppendLine($"    int pLen = {FixString(instruction.operands[^1].name)}.Length;");
                sb.AppendLine($"    uint[] args = new uint[{instruction.operands.Length - 1} + pLen];");
                for (int i = 0; i < instruction.operands.Length - 1; i++)
                    sb.AppendLine($"    args[{i}] = {FixString(instruction.operands[i].name)};");
                sb.AppendLine($"    for (int i = 0; i < pLen; i++) args[i + {instruction.operands.Length - 1}] = {FixString(instruction.operands[^1].name)}[i];");
                sb.AppendLine();
                sb.AppendLine($"    code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.{char.ToUpper(instruction.opname[0]) + instruction.opname[1..]}, args);");
                sb.AppendLine("  }");
            }
            else 
                sb.AppendLine($"  public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.{char.ToUpper(instruction.opname[0]) + instruction.opname[1..]}, {args});");
            sb.AppendLine("}");
        }

        return sb.ToString();
    }
    
    public static string GenerateOpenClEnum() {
        const string path = @"data/OpenClStdInstructions.json";
        ExtInstJson json = JsonConvert.DeserializeObject<ExtInstJson>(File.ReadAllText(path))!;
        
        StringBuilder sb = new();

        foreach (ExtInstJson.Instruction instruction in json.instructions)
            sb.AppendLine($"Op{char.ToUpper(instruction.opname[0]) + instruction.opname[1..]} = {instruction.opcode},");

        return sb.ToString();
    }

    public class ExtInstJson {
        public Instruction[] instructions;

        public class Instruction {
            public string opname;
            public int opcode;

            public Operand[] operands;
            
            public class Operand {
                public string kind;
                public string name;
                public string? quantifier;
            }
        }
    }

    public static string FixString(string s) => string.Join("", s.Trim('\'').Split(' ').Select((v, i) => i == 0 ? v : char.ToUpper(v[0]) + v[1..]));
}

public record ExtInst(SpvExtInstGlslStd name, params string[] operands) {
    public SpvExtInstGlslStd name = name;
    public string[] operands = operands;
}