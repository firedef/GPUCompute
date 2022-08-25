﻿using System.Text;
using GPUCompute.core;
using GPUCompute.core.buffers;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen;
using Environment = GPUCompute.core.Environment;

SpirVCodeGenerator generator = new(new(256,1,1));
generator.Generate();
uint[] byteCode = generator.code.GetByteCode();
PrintByteCode(byteCode);


using Device device = new();
using Environment env = new(device);
const int c = 2_500_000;
Buffer<float> input = new(device.allocator, c, BufferMode.write);
Buffer<float> output = new(device.allocator, c, BufferMode.read);
input[0] = 69;
input[10] = 42;
using Job job = new(env, generator.code.GetByteCode(), 2);
job.Execute(c / 256, input, output);
Console.WriteLine(input[0] + " " + input[10]);
Console.WriteLine(output[0] + " " + output[10]);
device.Wait();


unsafe void PrintByteCode(uint[] bytecode) {
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