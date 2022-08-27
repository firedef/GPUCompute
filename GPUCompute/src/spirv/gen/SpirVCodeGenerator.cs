using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen.instructions;
using MathStuff.vectors;
using static GPUCompute.spirv.gen.SpvTypes;

namespace GPUCompute.spirv.gen; 

public class SpirVCodeGenerator {
    public SpirVEmitter code;
    private readonly int3 _localSize;
    private Id _maxId = 2;

    private readonly Id _extInstructions = 1;
    private HashSet<SpvCapability> _capabilities = new() { SpvCapability.CapabilityShader };
    private Dictionary<string, SpvFunction> _functions = new();
    public readonly List<SpvDecorationData> decorations = new();
    public readonly List<SpvMemberDecorationData> memberDecorations = new();
    private Dictionary<SpvType, Id> _types = new();
    private Queue<(SpvType, Id)> _typesStack = new();
    private List<SpvVariable> _variables = new();
    private List<ISpvConst> _constants = new();

    public SpirVCodeGenerator(int3 localSize) {
        _localSize = localSize;

        // globalInvocation Id
        Id globalInvocationId = GlobalInvocationId();
        
        // workgroup
        Id gl_WorkGroupSize = WorkgroupSize(localSize);

        // in/out buffer
        SpvType runtimeArrFloat = RuntimeArray(spvF32)
            .Decorate(SpvDecoration.DecorationArrayStride, 4);
        
        // input buffer
        Id input_data = StorageBuffer(Struct(runtimeArrFloat).ReadOnly(0)).Bind(this, 0, 0);
        Id input2_data = StorageBuffer(Struct(runtimeArrFloat).ReadOnly(0)).Bind(this, 1, 0);
        
        // output buffer
        Id output_data = StorageBuffer(Struct(runtimeArrFloat)).Bind(this, 2, 0);
        
        // main function
        SpvFunction main = new(this) {
            functionType = Function(spvVoid).GetId(this),
            returnType = spvVoid.GetId(this)
        };
        _functions.Add("main", main);

        Id globalInvocationId_x = main.instructions.AccessAndLoad(spvU32, Pointer(spvU32, SpvStorageClass.StorageClassInput), globalInvocationId, spvU32.Const(this, 0));
        
        Id input_v = main.instructions.AccessAndLoad(spvF32, Pointer(Struct(runtimeArrFloat), SpvStorageClass.StorageClassUniform), input_data, spvI32.Const(this, 0), globalInvocationId_x);
        Id input2_v = main.instructions.AccessAndLoad(spvF32, Pointer(Struct(runtimeArrFloat), SpvStorageClass.StorageClassUniform), input2_data, spvI32.Const(this, 0), globalInvocationId_x);
        Id input_v_add_2 = main.instructions.FMul(spvF32, main.instructions.FAdd(spvF32, input_v, input2_v), spvF32.Const(this, 10f));
        SpvFuncVariable temp = main.Variable(spvF32);
        temp.value = input_v_add_2;
        main.instructions.AccessAndStore(temp.value, Pointer(spvF32, SpvStorageClass.StorageClassUniform), output_data, spvI32.Const(this, 0), globalInvocationId_x);
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
                .Select(v => v.id)
                .ToArray());
        
        code.EmitOpExecutionMode(_functions["main"].id, SpvExecutionMode.ExecutionModeLocalSize, (uint)_localSize.x, (uint)_localSize.y, (uint)_localSize.z);
        code.EmitOpSource(SpvSourceLanguage.SourceLanguageESSL, 310);
        code.EmitOpSourceExtension("GL_GOOGLE_cpp_style_line_directive");
        code.EmitOpSourceExtension("GL_GOOGLE_include_directive");

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
        _variables.Add(v);
        return v;
    }
    
    public SpvVariable Variable(Id owner, SpvType type, SpvStorageClass storageClass) {
        Id id = GetNextId();
        SpvVariable v = new() { id = id, owner = owner, type = type, storageClass = storageClass };
        _variables.Add(v);
        return v;
    }

    public Id StorageBuffer(SpvType type) => Variable(0, Pointer(type, SpvStorageClass.StorageClassStorageBuffer), SpvStorageClass.StorageClassStorageBuffer);
    
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