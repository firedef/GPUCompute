using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using GPUCompute.attributes;
using GPUCompute.spirv.cs.info;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen;
using GPUCompute.spirv.gen.types;
using GPUCompute.utils;
using MathStuff.vectors;
using static GPUCompute.spirv.gen.types.SpvTypes;
using InAttribute = GPUCompute.attributes.InAttribute;
using OutAttribute = GPUCompute.attributes.OutAttribute;

namespace GPUCompute.spirv.cs; 

public class IlConverter {
    public SpirVCodeGenerator code;
    public Type[] locals;
    public List<BufferInfo> buffers;
    public List<SpvStorageBuffer> storageBuffers;
    public IndexInfo index;
    public MethodInfo method;
    public IlCode ilCode;
    public SpvFunction function;
    public string funcName;

    public IlConverter(SpirVCodeGenerator code, MethodInfo method, bool isMain) {
        this.method = method;
        this.code = code;
        
        buffers = new();
        storageBuffers = new();

        ParameterInfo[] args = method.GetParameters();
        for (int i = 0; i < args.Length; i++) {
            ParameterInfo arg = args[i];
            bool isIn = arg.CustomAttributes.Any(v => v.AttributeType == typeof(InAttribute));
            bool isOut = arg.CustomAttributes.Any(v => v.AttributeType == typeof(OutAttribute));
            bool isIndex = arg.CustomAttributes.Any(v => v.AttributeType == typeof(IndexAttribute));
            bool isUniform = arg.CustomAttributes.Any(v => v.AttributeType == typeof(UniformAttribute));

            if (!isIndex) {
                Type elementType = arg.ParameterType.GetElementType()!;
                buffers.Add(new(i, isIn, isOut, isUniform, arg.Name ?? $"unnamed{i}", elementType));
                SpvType bufferType = Struct(RuntimeArray(Convert(elementType)).Decorate(SpvDecoration.DecorationArrayStride, (uint)Marshal.SizeOf(elementType)));
                // if (isIn && !isOut) bufferType.ReadOnly(0);
                // if (isOut && !isIn) bufferType.WriteOnly(0);
                SpvStorageBuffer storageBuffer = code.StorageBuffer(bufferType, Convert(elementType));
                storageBuffer.Bind(code, buffers.Count - 1, 0);
                storageBuffers.Add(storageBuffer);
            }
            else index = new(i, arg.ParameterType);
        }

        MethodBody body = method.GetMethodBody()!;
        locals = body.LocalVariables.Select(v => v.LocalType).ToArray();

        ilCode = new(body.GetILAsByteArray()!);

        funcName = isMain ? "main" : method.Name;
        function = new(code, args.Length, locals.Length);
        function.returnType = Convert(method.ReturnType).GetId(code);

        if (!isMain) {
            foreach (ParameterInfo p in args) function.Parameter(Convert(p.ParameterType).GetId(code), code.GetNextId());
        }
        
        function.functionType = Function(Convert(method.ReturnType), function.parameters.Select(v => (Id) v.type).ToArray()).GetId(code);
        
        code._functions.Add(funcName, function);
        
        InitArgs();
        InitLocals();
        ParseIlCode();
    }

    private void InitArgs() {
        ParameterInfo[] args = method.GetParameters();
        int bufferIndex = 0;
        for (int i = 0; i < args.Length; i++) {
            ParameterInfo arg = args[i];
            bool isIn = arg.CustomAttributes.Any(v => v.AttributeType == typeof(InAttribute));
            bool isOut = arg.CustomAttributes.Any(v => v.AttributeType == typeof(OutAttribute));
            bool isIndex = arg.CustomAttributes.Any(v => v.AttributeType == typeof(IndexAttribute));
            bool isUniform = arg.CustomAttributes.Any(v => v.AttributeType == typeof(UniformAttribute));

            if (isIndex) {
                function.Push(function.instructions.AccessAndLoad(spvU32, Pointer(spvU32, SpvStorageClass.StorageClassInput), code.globalInvocationId, spvU32.Const(code, 0)));
                function.StoreArg(i);
                continue;
            }

            if (isUniform) {
                continue;
            }

            {
                function.Push(storageBuffers[bufferIndex++]);
                function.StoreArg(i);
            }
        }
    }

    private void InitLocals() {
        for (int i = 0; i < locals.Length; i++) function.InitLocal(i, Convert(locals[i]));
    }

    private void ParseIlCode() {
        foreach (IlInstruction instruction in ilCode.instructions) {
            if (instruction.opCode == OpCodes.Ldarg_0) function.LoadArg(0);
            if (instruction.opCode == OpCodes.Ldarg_1) function.LoadArg(1);
            if (instruction.opCode == OpCodes.Ldarg_2) function.LoadArg(2);
            if (instruction.opCode == OpCodes.Ldarg_3) function.LoadArg(3);
            if (instruction.opCode == OpCodes.Ldarg) function.LoadArg((int) instruction.operand);
                
            if (instruction.opCode == OpCodes.Ldloc_0) function.LoadLocal(0);
            if (instruction.opCode == OpCodes.Ldloc_1) function.LoadLocal(1);
            if (instruction.opCode == OpCodes.Ldloc_2) function.LoadLocal(2);
            if (instruction.opCode == OpCodes.Ldloc_3) function.LoadLocal(3);
            if (instruction.opCode == OpCodes.Ldloc) function.LoadLocal((int) instruction.operand);
            
            if (instruction.opCode == OpCodes.Ldc_I4) function.PushConst(spvI32, (int) instruction.operand);
            if (instruction.opCode == OpCodes.Ldc_I4_0) function.PushConst(spvI32, 0);
            if (instruction.opCode == OpCodes.Ldc_I4_1) function.PushConst(spvI32, 1);
            if (instruction.opCode == OpCodes.Ldc_I4_2) function.PushConst(spvI32, 2);
            if (instruction.opCode == OpCodes.Ldc_I4_3) function.PushConst(spvI32, 3);
            if (instruction.opCode == OpCodes.Ldc_I4_4) function.PushConst(spvI32, 4);
            if (instruction.opCode == OpCodes.Ldc_I4_5) function.PushConst(spvI32, 5);
            if (instruction.opCode == OpCodes.Ldc_I4_6) function.PushConst(spvI32, 6);
            if (instruction.opCode == OpCodes.Ldc_I4_7) function.PushConst(spvI32, 7);
            if (instruction.opCode == OpCodes.Ldc_I4_8) function.PushConst(spvI32, 8);
            if (instruction.opCode == OpCodes.Ldc_I4_M1) function.PushConst(spvI32, -1);
            if (instruction.opCode == OpCodes.Ldc_I8) function.PushConst(spvI64, (long) instruction.operand);
            if (instruction.opCode == OpCodes.Ldc_R4) function.PushConst(spvF32, 10f);
            if (instruction.opCode == OpCodes.Ldc_R8) function.PushConst(spvF64, instruction.operand.As<double, ulong>());

            if (instruction.opCode == OpCodes.Ldelem_R4) {
                function.Swap();
                function.Push(function.instructions.AccessAndLoad(spvF32, Pointer(spvF32, SpvStorageClass.StorageClassUniform), function.Pop(), spvU32.Const(code, 0), function.Pop()));
            }
            
            if (instruction.opCode == OpCodes.Stelem_R4) {
                Id temp = function.Pop();
                function.Swap();
                function.Push(temp);
                function.instructions.AccessAndStore(function.Pop(), Pointer(spvF32, SpvStorageClass.StorageClassUniform), function.Pop(), spvU32.Const(code, 0), function.Pop());
            }
            
            if (instruction.opCode == OpCodes.Stloc_0) function.StoreLocal(0);
            if (instruction.opCode == OpCodes.Stloc_1) function.StoreLocal(1);
            if (instruction.opCode == OpCodes.Stloc_2) function.StoreLocal(2);
            if (instruction.opCode == OpCodes.Stloc_3) function.StoreLocal(3);
            if (instruction.opCode == OpCodes.Stloc) function.StoreLocal((int) instruction.operand);
            
            if (instruction.opCode == OpCodes.Add) function.Push(function.instructions.FAdd(spvF32, function.Pop(), function.Pop()));
            if (instruction.opCode == OpCodes.Mul) function.Push(function.instructions.FMul(spvF32, function.Pop(), function.Pop()));
            if (instruction.opCode == OpCodes.Div) {
                function.Swap();
                function.Push(function.instructions.FDiv(spvF32, function.Pop(), function.Pop()));
            }
        }
    }

    public void Generate() {
        
    }
}