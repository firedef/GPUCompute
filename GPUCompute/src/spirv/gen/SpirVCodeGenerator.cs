using System.Reflection;
using System.Text;
using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen.instructions;
using GPUCompute.spirv.gen.stack;
using GPUCompute.spirv.gen.types;
using MathStuff.vectors;
using static GPUCompute.spirv.gen.types.SpvTypes;

namespace GPUCompute.spirv.gen; 

public class SpirVCodeGenerator {
    public SpirVEmitter code;
    private readonly int3 _localSize;
    private Id _maxId = 2;

    private readonly Id _extInstructions = 1;
    private HashSet<SpvCapability> _capabilities = new() { SpvCapability.CapabilityShader };
    public Dictionary<string, SpvFunction> _functions = new();
    public readonly List<SpvDecorationData> decorations = new();
    public readonly List<SpvMemberDecorationData> memberDecorations = new();
    private Dictionary<SpvType, Id> _types = new();
    private Queue<(SpvType, Id)> _typesStack = new();
    private List<SpvVariable> _variables = new();
    private List<ISpvConst> _constants = new();

    public Id globalInvocationId;

    public SpirVCodeGenerator(int3 localSize) {
        _localSize = localSize;
        
        globalInvocationId = GlobalInvocationId();
        Id gl_WorkGroupSize = WorkgroupSize(localSize);

        // globalInvocation Id
//         Id globalInvocationId = GlobalInvocationId();
//         
//         // workgroup
//         Id gl_WorkGroupSize = WorkgroupSize(localSize);
//
//         // in/out buffer
//         SpvType runtimeArrFloat = RuntimeArray(spvF32)
//             .Decorate(SpvDecoration.DecorationArrayStride, 4);
//         
//         // input buffer
//         SpvStorageBuffer input_data = StorageBuffer(Struct(runtimeArrFloat).ReadOnly(0), spvF32).Bind(this, 0, 0);
//         SpvStorageBuffer input2_data = StorageBuffer(Struct(runtimeArrFloat).ReadOnly(0), spvF32).Bind(this, 1, 0);
//         
//         // output buffer
//         SpvStorageBuffer output_data = StorageBuffer(Struct(runtimeArrFloat), spvF32).Bind(this, 2, 0);
//
//         /*
//         
//         main.PushConst(spvF32, 10f);
//         
//         main.PushConst(spvU32, 0);
//         main.PushValue(1u);
//         main.PushId(globalInvocationId);
//         main.PushType(Pointer(spvU32, SpvStorageClass.StorageClassInput));
//         main.PushType(spvU32);
//         main.stack.AccessAndLoad();
//         main.Dup();
//         main.Store(0);
//         
//         main.PushConst(spvI32, 0);
//         main.PushFunc(main);
//         input_data.Load();
//         
//         main.Load(0);
//         main.PushConst(spvI32, 0);
//         main.PushFunc(main);
//         input_data2.Load();
//         
//         main.PushType(spvF32);
//         main.stack.FAdd();
//         
//         main.PushType(spvF32);
//         main.stack.FMul();
//         main.Store(1);
//         
//         main.Load(0);
//         main.PushConst(spvI32, 0);
//         main.Load(1);
//         main.PushFunc(main);
//         output_data.Store();
//          */
//         
//         // [0] = globalInvocationId_x
//         // [1] = spvI32 0
//         // [2] = input_v_add_2
//
//         // main.Push(spvU32.Const(this, 0));
//         // main.Push(globalInvocationId);
//         // main.instructions.AccessAndLoad(spvU32, Pointer(spvU32, SpvStorageClass.StorageClassInput), 1u);
//         // main.Dup();
//         // main.Store(0);
//         //
//         // main.PushConst(spvI32, 0);
//         // main.Dup();
//         // main.Store(1);
//         //
//         // main.Push(input_data.Load(main, main.Pop(),  main.Pop()));
//         //
//         // main.Load(0);
//         // main.Load(1);
//         // main.Push(input2_data.Load(main, main.Pop(),  main.Pop()));
//         //
//         // main.Push(main.instructions.FAdd(spvF32, main.Pop(), main.Pop()));
//         // main.PushConst(spvF32, 10f);
//         // main.Swap();
//         //
//         // main.PushAsVar(spvF32, main.instructions.FMul(spvF32, main.Pop(), main.Pop()));
//         // main.Store(2);
//         //
//         // main.Load(0);
//         // main.Load(1);
//         // main.Load(2);
//         // output_data.Store(main, main.Pop(), main.Pop(), main.Pop());
//         
//         /*
//         (
//             float32[] bufferOut,
//             float32[] buffer1,
//             float32[] buffer2,
//             int32 i
//         )
//         
//         .maxstack 4
//         .locals init (
//             [0] float32 d
//         )
//
//         // [31 75 - 31 76]
//         IL_0000: nop
//
//         // [32 5 - 32 26]
//         IL_0001: ldarg.1      // buffer1
//         IL_0002: ldarg.3      // i
//         IL_0003: ldelem.r4
//         IL_0004: stloc.0      // d
//
//         // [33 5 - 33 19]
//         IL_0005: ldloc.0      // d
//         IL_0006: ldloc.0      // d
//         IL_0007: ldc.r4       0.9
//         IL_000c: add
//         IL_000d: mul
//         IL_000e: stloc.0      // d
//
//         // [34 5 - 34 35]
//         IL_000f: ldarg.0      // bufferOut
//         IL_0010: ldarg.3      // i
//         IL_0011: ldarg.1      // buffer1
//         IL_0012: ldarg.3      // i
//         IL_0013: ldelem.r4
//         IL_0014: ldloc.0      // d
//         IL_0015: div
//         IL_0016: stelem.r4
//
//         // [35 1 - 35 2]
//         IL_0017: ret
//          */
//
//         MethodInfo methodInfo = GetType().GetMethod(nameof(TestFunc))!;
//         ParameterInfo[] args = methodInfo.GetParameters();
//         int argCount = args.Length;
//         int localsCount = 1;
//         
//         // main function
//         SpvFunction main = new(this, argCount, localsCount) {
//             functionType = Function(spvVoid).GetId(this),
//             returnType = spvVoid.GetId(this)
//         };
//         _functions.Add("main", main);
//         
//
//         // init args
//         main.Push(output_data.id);
//         main.StoreArg(0); // bufferOut
//         
//         main.Push(input_data.id);
//         main.StoreArg(1); // buffer1
//         
//         main.Push(input2_data.id);
//         main.StoreArg(2); // buffer2
//         
//         main.Push(spvU32.Const(this, 0));
//         main.Push(globalInvocationId);
//         main.instructions.AccessAndLoad(spvU32, Pointer(spvU32, SpvStorageClass.StorageClassInput), 1u);
//         main.StoreArg(3); // i
//         
//         
//         // init locals
//         main.InitLocal(0, spvF32);
//
//         
//         // [32 5 - 32 26]
//         main.LoadArg(1); // ldarg.1 (buffer1)
//         main.LoadArg(3); // ldarg.3 (i)
//         
//         main.Swap(); // ldelem.r4
//         main.Push(main.instructions.AccessAndLoad(spvF32, Pointer(spvF32, SpvStorageClass.StorageClassUniform), main.Pop(), spvU32.Const(this, 0), main.Pop()));
//         
//         main.StoreLocal(0); // stloc.0 (d)
//         
//         
//         // [33 5 - 33 19]
//         main.LoadLocal(0); // ldloc.0 (d)
//         main.LoadLocal(0); // ldloc.0 (d)
//         main.PushConst(spvF32, 0.9f); // ldc.r4 0.9
//         main.Push(main.instructions.FAdd(spvF32, main.Pop(), main.Pop())); // add
//         main.Push(main.instructions.FMul(spvF32, main.Pop(), main.Pop())); // mul
//         main.StoreLocal(0); // stloc.0 (d)
//
//         // [34 5 - 34 35]
//         main.LoadArg(0); // bufferOut
//         main.LoadArg(3); // i
//         main.LoadArg(1); // buffer1
//         main.LoadArg(3); // i
//         
//         main.Swap(); // ldelem.r4
//         main.Push(main.instructions.AccessAndLoad(spvF32, Pointer(spvF32, SpvStorageClass.StorageClassUniform), main.Pop(), spvU32.Const(this, 0), main.Pop()));
//         
//         main.LoadLocal(0); // bufferOut
//         
//         main.Swap();
//         main.Push(main.instructions.FDiv(spvF32, main.Pop(), main.Pop())); // div
//
//         Id temp = main.Pop();
//         main.Swap();
//         main.Push(temp);
//         main.instructions.AccessAndStore(main.Pop(), Pointer(spvF32, SpvStorageClass.StorageClassUniform), main.Pop(), spvU32.Const(this, 0), main.Pop());
    }
    
    public unsafe void PrintByteCode() {
        uint[] bytecode = code.GetByteCode();
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
                default:
                    str += " " + string.Join(", ", args.Select(v => v.ToString()));
                    break;
            }
            Console.WriteLine(str);
        
            pos += length;
        }
    }
    
    public static void TestFunc(float[] bufferOut, float[] buffer1, float[] buffer2, int i) {
        float d = buffer1[i];
        d *= d + 0.9f;
        bufferOut[i] = buffer1[i] / d;
    }

    public Id GetNextId() => _maxId++;

    public void Generate() {
        code = new(_maxId);

        foreach (SpvCapability capability in _capabilities) 
            code.EmitOpCapability(capability);
        
        code.EmitOpExtInstImport(_extInstructions, "GLSL.std.450");
        code.EmitOpMemoryModel(SpvAddressingModel.AddressingModelLogical, _extInstructions);
        code.EmitOpEntryPoint(SpvExecutionModel.ExecutionModelGLCompute, _functions["main"].id, "main", 
            _variables
                .Where(v => v.storageClass == SpvStorageClass.StorageClassInput | v.storageClass == SpvStorageClass.StorageClassOutput)
                .Select(v => v.id.v)
                .ToArray());
        
        code.EmitOpExecutionMode(_functions["main"].id, SpvExecutionMode.ExecutionModeLocalSize, (uint)_localSize.x, (uint)_localSize.y, (uint)_localSize.z);
        code.EmitOpSource(SpvSourceLanguage.SourceLanguageESSL, 310);
        code.EmitOpSourceExtension("GL_GOOGLE_cpp_style_line_directive");
        code.EmitOpSourceExtension("GL_GOOGLE_include_directive");

        foreach (SpvVariable variable in _variables) AddType(variable.type);
        
        foreach (SpvDecorationData decoration in decorations) 
            code.EmitOpDecorate(decoration.id, decoration.name, decoration.args);

        foreach (SpvMemberDecorationData decoration in memberDecorations) 
            code.EmitOpMemberDecorate(decoration.id, decoration.member, decoration.name, decoration.args);

        foreach (KeyValuePair<SpvType, Id> type in _types)
            type.Key.Emit(this, type.Value);
        
        foreach (ISpvConst constant in _constants) 
            constant.Emit(code);

        foreach (SpvVariable variable in _variables.Where(v => v.storageClass != SpvStorageClass.StorageClassFunction)) 
            code.EmitOpVariable(variable.type.GetId(this), variable.id, variable.storageClass);

        foreach (KeyValuePair<string,SpvFunction> fun in _functions) 
            GenerateFunction(fun.Value);
    }

    private void GenerateFunction(SpvFunction fun) {
        code.EmitOpFunction(fun.returnType, fun.id, fun.control, fun.functionType);
        
        foreach ((uint type, uint Id) in fun.parameters) 
            code.EmitOpFunctionParameter(type, Id);
        
        for (int i = 0; i < fun.blocks.Count; i++) {
            code.EmitOpLabel(fun.blocks[i].blockId);

            if (i == 0) {
                foreach (SpvVariable variable in _variables.Where(v => v.storageClass == SpvStorageClass.StorageClassFunction && v.owner == fun.id)) 
                    code.EmitOpVariable(variable.type.GetId(this), variable.id, variable.storageClass);
            }

            foreach (ISpvInstruction instruction in fun.blocks[i].instructions) 
                instruction.Emit(code);
            
            if (fun.blocks.Count > i+1) code.EmitOpBranch(fun.blocks[i+1].blockId);
        }
        
        code.EmitOpReturn();
        code.EmitOpFunctionEnd();
    }

    public Id AddType(SpvType type) {
        if (_types.TryGetValue(type, out Id id)) return id;
        id = GetNextId();
        type.AddRequiredData(this, id);
        _types.Add(type, id);
        _typesStack.Enqueue((type, id));
        return id;
    }

    public Id GetType(SpvType type) => _types[type];
    
    public SpvFuncVariable FuncVariable(SpvFunction function, SpvType type) {
        Id id = GetNextId();
        SpvFuncVariable v = new() { id = id, owner = function.id, type = type, storageClass = SpvStorageClass.StorageClassFunction, function = function};
        AddType(v.type);
        _variables.Add(v);
        return v;
    }
    
    public SpvVariable Variable(Id owner, SpvType type, SpvStorageClass storageClass) {
        Id id = GetNextId();
        SpvVariable v = new() { id = id, owner = owner, type = type, storageClass = storageClass };
        AddType(v.type);
        _variables.Add(v);
        return v;
    }

    public SpvStorageBuffer StorageBuffer(SpvType type, SpvType elementType) {
        Id id = GetNextId();
        SpvStorageBuffer v = new(elementType, Pointer(type, SpvStorageClass.StorageClassStorageBuffer), id);
        AddType(v.elementType);
        AddType(v.type);
        _variables.Add(v);
        return v;
    }

    public Id WorkgroupSize(int3 size) => 
        ConstantComposite(spvU32x3.GetId(this), spvU32.Const(this, size.x), spvU32.Const(this, size.y), spvU32.Const(this, size.z))
            .DecorateBuiltIn(this, SpvBuiltIn.BuiltInWorkgroupSize);
    
    public Id GlobalInvocationId() =>
        Variable(0, Pointer(spvU32x3, SpvStorageClass.StorageClassInput), SpvStorageClass.StorageClassInput)
            .DecorateBuiltIn(this, SpvBuiltIn.BuiltInGlobalInvocationId);

    public Id Constant<T>(Id type, T v) where T : unmanaged {
        uint[] ints = SpirVEmitter.GetInts(v);
        
        foreach (ISpvConst c in _constants)
            if (c is SpvConst c1 && c1.type == type.v && c1.value.Length == ints.Length) {
                for (int i = 0; i < ints.Length; i++) 
                    if (ints[i] != c1.value[i]) goto NEXT;
                return c1.id;
            NEXT: ;
            }
        
        Id id = GetNextId();
        _constants.Add(new SpvConst(type, id, ints));
        return id;
    }
    
    public Id ConstantComposite(Id type, params uint[] constituents) {
        foreach (ISpvConst c in _constants)
            if (c is SpvConstComposite c1 && c1.type == type && c1.constituents == constituents)
                return c1.id;
        
        Id id = GetNextId();
        _constants.Add(new SpvConstComposite(type, id, constituents));
        return id;
    }

    public Id GetGlsl() => _extInstructions;
    public Id GetOpenCl() => _extInstructions;
}