using System.Text;
using GPUCompute.core;
using GPUCompute.core.buffers;
using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen;
using GPUCompute.vulkan.buffers;
using GPUCompute.vulkan.descriptors;
using Vulkan;
using Buffer = GPUCompute.core.buffers.Buffer;
using Environment = GPUCompute.core.Environment;

namespace GPUCompute.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public unsafe void Test1() {
        const string shaderSrc = @"#version 310 es
layout (local_size_x = 256) in;

layout(set = 0, binding = 0) readonly buffer InputBuffer {
    float floats[];
} sourceData;

layout(set = 1, binding = 0) buffer OutputBuffer {
    float floats[];
} outputData;


void main() {
	uint i = gl_GlobalInvocationID.x;
    outputData.floats[i] = sourceData.floats[i] * 3.0;
    for (float a = 0.0; a < 100000.0; a++) {
        outputData.floats[i] += sin(outputData.floats[i]);
    }
}
";
        
        uint[] shaderRaw = {
            0x07230203,0x00010000,0x000d000a,0x0000003e,
            0x00000000,0x00020011,0x00000001,0x0006000b,
            0x00000001,0x4c534c47,0x6474732e,0x3035342e,
            0x00000000,0x0003000e,0x00000000,0x00000001,
            0x0006000f,0x00000005,0x00000004,0x6e69616d,
            0x00000000,0x0000000b,0x00060010,0x00000004,
            0x00000011,0x00000100,0x00000001,0x00000001,
            0x00030003,0x00000001,0x00000136,0x000a0004,
            0x475f4c47,0x4c474f4f,0x70635f45,0x74735f70,
            0x5f656c79,0x656e696c,0x7269645f,0x69746365,
            0x00006576,0x00080004,0x475f4c47,0x4c474f4f,
            0x6e695f45,0x64756c63,0x69645f65,0x74636572,
            0x00657669,0x00040005,0x00000004,0x6e69616d,
            0x00000000,0x00030005,0x00000008,0x00000069,
            0x00080005,0x0000000b,0x475f6c67,0x61626f6c,
            0x766e496c,0x7461636f,0x496e6f69,0x00000044,
            0x00060005,0x00000012,0x7074754f,0x75427475,
            0x72656666,0x00000000,0x00050006,0x00000012,
            0x00000000,0x616f6c66,0x00007374,0x00050005,
            0x00000014,0x7074756f,0x61447475,0x00006174,
            0x00050005,0x00000019,0x75706e49,0x66754274,
            0x00726566,0x00050006,0x00000019,0x00000000,
            0x616f6c66,0x00007374,0x00050005,0x0000001b,
            0x72756f73,0x61446563,0x00006174,0x00030005,
            0x00000024,0x00000061,0x00040047,0x0000000b,
            0x0000000b,0x0000001c,0x00040047,0x00000011,
            0x00000006,0x00000004,0x00050048,0x00000012,
            0x00000000,0x00000023,0x00000000,0x00030047,
            0x00000012,0x00000003,0x00040047,0x00000014,
            0x00000022,0x00000001,0x00040047,0x00000014,
            0x00000021,0x00000000,0x00040047,0x00000018,
            0x00000006,0x00000004,0x00040048,0x00000019,
            0x00000000,0x00000018,0x00050048,0x00000019,
            0x00000000,0x00000023,0x00000000,0x00030047,
            0x00000019,0x00000003,0x00040047,0x0000001b,
            0x00000022,0x00000000,0x00040047,0x0000001b,
            0x00000021,0x00000000,0x00040047,0x0000003d,
            0x0000000b,0x00000019,0x00020013,0x00000002,
            0x00030021,0x00000003,0x00000002,0x00040015,
            0x00000006,0x00000020,0x00000000,0x00040020,
            0x00000007,0x00000007,0x00000006,0x00040017,
            0x00000009,0x00000006,0x00000003,0x00040020,
            0x0000000a,0x00000001,0x00000009,0x0004003b,
            0x0000000a,0x0000000b,0x00000001,0x0004002b,
            0x00000006,0x0000000c,0x00000000,0x00040020,
            0x0000000d,0x00000001,0x00000006,0x00030016,
            0x00000010,0x00000020,0x0003001d,0x00000011,
            0x00000010,0x0003001e,0x00000012,0x00000011,
            0x00040020,0x00000013,0x00000002,0x00000012,
            0x0004003b,0x00000013,0x00000014,0x00000002,
            0x00040015,0x00000015,0x00000020,0x00000001,
            0x0004002b,0x00000015,0x00000016,0x00000000,
            0x0003001d,0x00000018,0x00000010,0x0003001e,
            0x00000019,0x00000018,0x00040020,0x0000001a,
            0x00000002,0x00000019,0x0004003b,0x0000001a,
            0x0000001b,0x00000002,0x00040020,0x0000001d,
            0x00000002,0x00000010,0x0004002b,0x00000010,
            0x00000020,0x40400000,0x00040020,0x00000023,
            0x00000007,0x00000010,0x0004002b,0x00000010,
            0x00000025,0x00000000,0x0004002b,0x00000010,
            0x0000002c,0x47c35000,0x00020014,0x0000002d,
            0x0004002b,0x00000010,0x00000039,0x3f800000,
            0x0004002b,0x00000006,0x0000003b,0x00000100,
            0x0004002b,0x00000006,0x0000003c,0x00000001,
            0x0006002c,0x00000009,0x0000003d,0x0000003b,
            0x0000003c,0x0000003c,0x00050036,0x00000002,
            0x00000004,0x00000000,0x00000003,0x000200f8,
            0x00000005,0x0004003b,0x00000007,0x00000008,
            0x00000007,0x0004003b,0x00000023,0x00000024,
            0x00000007,0x00050041,0x0000000d,0x0000000e,
            0x0000000b,0x0000000c,0x0004003d,0x00000006,
            0x0000000f,0x0000000e,0x0003003e,0x00000008,
            0x0000000f,0x0004003d,0x00000006,0x00000017,
            0x00000008,0x0004003d,0x00000006,0x0000001c,
            0x00000008,0x00060041,0x0000001d,0x0000001e,
            0x0000001b,0x00000016,0x0000001c,0x0004003d,
            0x00000010,0x0000001f,0x0000001e,0x00050085,
            0x00000010,0x00000021,0x0000001f,0x00000020,
            0x00060041,0x0000001d,0x00000022,0x00000014,
            0x00000016,0x00000017,0x0003003e,0x00000022,
            0x00000021,0x0003003e,0x00000024,0x00000025,
            0x000200f9,0x00000026,0x000200f8,0x00000026,
            0x000400f6,0x00000028,0x00000029,0x00000000,
            0x000200f9,0x0000002a,0x000200f8,0x0000002a,
            0x0004003d,0x00000010,0x0000002b,0x00000024,
            0x000500b8,0x0000002d,0x0000002e,0x0000002b,
            0x0000002c,0x000400fa,0x0000002e,0x00000027,
            0x00000028,0x000200f8,0x00000027,0x0004003d,
            0x00000006,0x0000002f,0x00000008,0x0004003d,
            0x00000006,0x00000030,0x00000008,0x00060041,
            0x0000001d,0x00000031,0x00000014,0x00000016,
            0x00000030,0x0004003d,0x00000010,0x00000032,
            0x00000031,0x0006000c,0x00000010,0x00000033,
            0x00000001,0x0000000d,0x00000032,0x00060041,
            0x0000001d,0x00000034,0x00000014,0x00000016,
            0x0000002f,0x0004003d,0x00000010,0x00000035,
            0x00000034,0x00050081,0x00000010,0x00000036,
            0x00000035,0x00000033,0x00060041,0x0000001d,
            0x00000037,0x00000014,0x00000016,0x0000002f,
            0x0003003e,0x00000037,0x00000036,0x000200f9,
            0x00000029,0x000200f8,0x00000029,0x0004003d,
            0x00000010,0x00000038,0x00000024,0x00050081,
            0x00000010,0x0000003a,0x00000038,0x00000039,
            0x0003003e,0x00000024,0x0000003a,0x000200f9,
            0x00000026,0x000200f8,0x00000028,0x000100fd,
            0x00010038

        };

        SpirVEmitter code = new();
        code.EmitOpCapability(SpvCapability.CapabilityShader);
        code.EmitOpExtInstImport(1, "GLSL.std.450");
        code.EmitOpMemoryModel(SpvAddressingModel.AddressingModelLogical, 1);
        code.EmitOpEntryPoint(SpvExecutionModel.ExecutionModelGLCompute, 4, "main", 11);
        code.EmitOpExecutionMode(4, SpvExecutionMode.ExecutionModeLocalSize, 256, 1, 1);
        code.EmitOpSource(SpvSourceLanguage.SourceLanguageESSL, 310);
        code.EmitOpSourceExtension("GL_GOOGLE_cpp_style_line_directive");
        code.EmitOpSourceExtension("GL_GOOGLE_include_directive");
        
        code.EmitOpDecorateBuiltIn(11, SpvBuiltIn.BuiltInGlobalInvocationId);
        code.EmitOpDecorate(17, SpvDecoration.DecorationArrayStride, 4);
        // code.EmitOpMemberDecorate(18, 0, SpvDecoration.DecorationOffset, 0);
        // code.EmitOpDecorate(18, SpvDecoration.DecorationBufferBlock);
        // code.EmitOpDecorate(20, SpvDecoration.DecorationDescriptorSet, 1);
        // code.EmitOpDecorate(20, SpvDecoration.DecorationBinding, 0);
        // code.EmitOpDecorate(24, SpvDecoration.DecorationArrayStride, 4);
        // code.EmitOpMemberDecorate(25, 0, SpvDecoration.DecorationNonWritable);
        // code.EmitOpMemberDecorate(25, 0, SpvDecoration.DecorationOffset, 0);
        // code.EmitOpDecorate(25, SpvDecoration.DecorationBufferBlock);
        // code.EmitOpDecorate(27, SpvDecoration.DecorationDescriptorSet, 0);
        // code.EmitOpDecorate(27, SpvDecoration.DecorationBinding, 0);
        code.EmitOpDecorateBuiltIn(61, SpvBuiltIn.BuiltInWorkgroupSize);
        
        code.EmitOpTypeVoid(2);
        code.EmitOpTypeFunction(3, 2);
        code.EmitOpTypeInt(6, 32, 0); // uint
        code.EmitOpTypePointer(7, 7, 6);
        code.EmitOpTypeVector(9, 6, 3); // uint3
        code.EmitOpTypePointer(10, 1, 9); // uint3*
        
        code.EmitOpVariable(10, 11, SpvStorageClass.StorageClassInput); // globalInvocationId
        code.EmitOpConstant(6, 12, 0); // uint 0
        
        code.EmitOpTypePointer(13, 1, 6); // uint*
        code.EmitOpTypeFloat(16, 32); // float
        code.EmitOpTypeRuntimeArray(17, 16);
        code.EmitOpTypeStruct(18, 17);
        code.EmitOpTypePointer(19, 2, 18);
        
        code.EmitOpVariable(19, 20, SpvStorageClass.StorageClassUniform);
        
        code.EmitOpTypeInt(21, 32, 1);
        
        code.EmitOpConstant(21, 22, 0); // int 0
        
        // code.EmitOpTypeRuntimeArray(24, 16);
        // code.EmitOpTypeStruct(25, 24);
        // code.EmitOpTypePointer(26, 2, 25);
        
        code.EmitOpVariable(26, 27, SpvStorageClass.StorageClassUniform); // Input*
        code.EmitOpTypePointer(29, 2, 16); // float*
        
        // code.EmitOpConstant(16, 32, 3f);
        
        // code.EmitOpTypePointer(35, 7, 16);
        
        // code.EmitOpConstant(16, 37, 0);
        // code.EmitOpConstant(16, 44, 100_000f);
        
        // code.EmitOpTypeBool(45);
        
        // code.EmitOpConstant(16, 57, 1f);
        code.EmitOpConstant(6, 59, 256);
        code.EmitOpConstant(6, 60, 1);
        code.EmitOpConstantComposite(9, 61, 59, 60, 60);
        
        
        
        
        code.EmitOpFunction(2, 4, SpvFunctionControlMask.FunctionControlMaskNone, 3);
        code.EmitOpLabel(5);
        
        code.EmitOpVariable(7, 8, SpvStorageClass.StorageClassFunction);
        // code.EmitOpVariable(35, 36, SpvStorageClass.StorageClassFunction);
        code.EmitOpAccessChain(13, 14, 11, 12); // [uint*, 14, globalInvocationId, (uint) 0]
        //
        code.EmitOpLoad(6, 15, 14); // [uint, 15, globalInvocationId.x]
        code.EmitOpStore(8, 15);
        code.EmitOpLoad(6, 23, 8);
        code.EmitOpLoad(6, 28, 8);
        code.EmitOpAccessChain(29, 30, 27, 22, 28); // [float*, 30, Input*, (int) 0, globalInvocationId.x]
        code.EmitOpLoad(16, 31, 30);
        //
        // code.EmitOpFMul(16, 33, 31, 32);
        //
        code.EmitOpAccessChain(29, 34, 20, 22, 23); // [float*. 34, Output*, (int) 0, globalInvocationId.x]
        code.EmitOpStore(34, 33);
        // code.EmitOpStore(36, 37);
        //
        // code.EmitOpBranch(38);
        // code.EmitOpLabel(38);
        // code.EmitOpLoopMerge(40, 41, 0);
        // code.EmitOpBranch(42);
        // code.EmitOpLabel(42);
        //
        // code.EmitOpLoad(16, 43, 36);
        // code.EmitOpFOrdLessThan(45, 46, 43, 44);
        // code.EmitOpBranchConditional(46, 39, 40);
        // code.EmitOpLabel(39);
        // code.EmitOpLoad(6, 47, 8);
        // code.EmitOpLoad(6, 48, 8);
        // code.EmitOpAccessChain(29, 49, 20, 22, 48);
        // code.EmitOpLoad(16, 50, 49);
        // code.EmitOpExtInst(16, 51, 1, SpvExtInst.Sin, 50);
        // code.EmitOpAccessChain(29, 52, 20, 22, 47);
        // code.EmitOpLoad(16, 53, 52);
        // code.EmitOpFAdd(16, 54, 53, 51);
        // code.EmitOpAccessChain(29, 55, 20, 22, 47);
        // code.EmitOpStore(55, 54);
        //
        // code.EmitOpBranch(41);
        // code.EmitOpLabel(41);
        // code.EmitOpLoad(16, 56, 36);
        // code.EmitOpFAdd(16, 58, 56, 57);
        // code.EmitOpStore(36, 58);
        // code.EmitOpBranch(38);
        // code.EmitOpLabel(40);
        code.EmitOpReturn();
        code.EmitOpFunctionEnd();

        // SpirVCodeGenerator generator = new(new(256,1,1));
        // generator.Generate();
        // uint[] byteCode = generator.code.GetByteCode();
        // //Console.WriteLine(byteCode.Length);
        PrintByteCode(code.GetByteCode());
        // for (int i = 0; i < byteCode.Length; i++) {
        //     if (i % 4 == 0) Console.WriteLine();
        //     Console.Write($"0x{byteCode[i]:x8},");
        // }
        //
        
        using Device device = new();
        using Environment env = new(device);
        
        const int c = 2_500_000;
        Buffer<float> input = new(device.allocator, c, BufferMode.write);
        Buffer<float> output = new(device.allocator, c, BufferMode.read);
        
        input[0] = 69;
        input[10] = 42;
        
        using Job job = new(env, code.GetByteCode(), 2);
        job.Execute(c / 256, input, output);
        
        Console.WriteLine(input[0] + " " + input[10]);
        Console.WriteLine(output[0] + " " + output[10]);
        
        device.Wait();
    }

    private static unsafe void PrintByteCode(uint[] bytecode) {
        int pos = 5;
        for (; pos < bytecode.Length;) {
            ushort length = (ushort)(bytecode[pos] >> 16);
            SpvOpCode opCode = (SpvOpCode)(bytecode[pos] & 0xFFFF);
        
            uint[] args = bytecode[(pos + 1)..(pos + length)];
            string str = $"[x{length:00}] {opCode}";
            switch (opCode) {
                case SpvOpCode.OpSourceExtension:
                    fixed (uint* argsPtr = args)
                        str += $" {Encoding.ASCII.GetString((byte*)argsPtr, args.Length * 4).TrimEnd('\0')}";
                    break;
                case SpvOpCode.OpName:
                    fixed (uint* argsPtr = args)
                        str += $" {args[0]} {Encoding.ASCII.GetString((byte*)(argsPtr + 1), (args.Length - 1) * 4).TrimEnd('\0')}";
                    break;
                case SpvOpCode.OpMemberName:
                    fixed (uint* argsPtr = args)
                        str += $" {args[0]} {args[1]} {Encoding.ASCII.GetString((byte*)(argsPtr + 2), (args.Length - 2) * 4).TrimEnd('\0')}";
                    break;
                case SpvOpCode.OpSource:
                    str += $" {(SpvSourceLanguage)args[0]}";
                    break;
                case SpvOpCode.OpDecorate:
                    str += $" {args[0]} {(SpvDecoration)args[1]} {string.Join(", ", args.Skip(2).Select(v => v.ToString()))}";
                    break;
                // case SpvOpCode.OpEntryPoint:
                //     fixed (uint* argsPtr = args)
                //         str += $" {(SpvExecutionModel)args[0]} {args[1]} {Encoding.ASCII.GetString((byte*)(argsPtr + 2), (args.Length - 3) * 4).TrimEnd('\0')} {args[^1]}";
                //     break;
                default:
                    str += " " + string.Join(", ", args.Select(v => v.ToString()));
                    break;
            }
            Console.WriteLine(str);
            
            pos += length;
        }
    }
}