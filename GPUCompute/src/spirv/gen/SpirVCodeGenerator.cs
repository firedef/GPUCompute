using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen.instructions;
using MathStuff.vectors;
using static GPUCompute.spirv.gen.instructions.SpvOp.Unified;
using id = System.UInt32;
// ReSharper disable BuiltInTypeReferenceStyle

namespace GPUCompute.spirv.gen; 

public class SpirVCodeGenerator {
    public SpirVEmitter code;
    private readonly int3 _localSize;
    private id _maxId = 2;

    private const id _extInstructions = 1;
    private HashSet<SpvCapability> _capabilities = new() { SpvCapability.CapabilityShader };
    private Dictionary<string, SpvFunction> _functions = new();
    private List<SpvDecorationData> _decorations = new();
    private List<SpvMemberDecorationData> _memberDecorations = new();
    private Dictionary<SpvType, id> _types = new();
    private List<SpvVariable> _variables = new();
    private List<ISpvConst> _constants = new();

    public SpirVCodeGenerator(int3 localSize) {
        _localSize = localSize;

        // globalInvocation id
        id @uint = AddType(new SpvTypeInt(32, false));
        id @ptr_uint = AddType(new SpvTypePointer(SpvStorageClass.StorageClassInput, @uint));
        id @v3_uint = AddType(new SpvTypeVector(@uint, 3));
        id @ptr_v3_uint = AddType(new SpvTypePointer(SpvStorageClass.StorageClassInput, @v3_uint));
        id @gl_GlobalInvocationID = AddVariable(0, @ptr_v3_uint, SpvStorageClass.StorageClassInput);
        _decorations.Add(new(@gl_GlobalInvocationID, SpvDecoration.DecorationBuiltIn, (uint) SpvBuiltIn.BuiltInGlobalInvocationId));
        
        // workgroup
        id @uint_1 = AddConstant(@uint, 1);
        id @uint_256 = AddConstant(@uint, 256);
        id @gl_WorkGroupSize = AddConstantComposite(@v3_uint, @uint_256, @uint_1, @uint_1);
        _decorations.Add(new(@gl_WorkGroupSize, SpvDecoration.DecorationBuiltIn, (uint) SpvBuiltIn.BuiltInWorkgroupSize));

        // in/out buffer
        id @float = AddType(new SpvTypeFloat(32));
        id @runtime_arr_float = AddType(new SpvTypeRuntimeArray(@float));
        _decorations.Add(new(@runtime_arr_float, SpvDecoration.DecorationArrayStride, 4));
        
        // input buffer
        id @input_buffer_struct = AddType(new SpvTypeStruct(@runtime_arr_float));
        _decorations.Add(new(@input_buffer_struct, SpvDecoration.DecorationBufferBlock));
        _memberDecorations.Add(new(@input_buffer_struct, 0, SpvDecoration.DecorationNonWritable));
        _memberDecorations.Add(new(@input_buffer_struct, 0, SpvDecoration.DecorationOffset, 0));
        id @ptr_uniform_input_buffer_struct = AddType(new SpvTypePointer(SpvStorageClass.StorageClassUniform, @input_buffer_struct));
        id @input_data = AddVariable(0, @ptr_uniform_input_buffer_struct, SpvStorageClass.StorageClassUniform);
        _decorations.Add(new(@input_data, SpvDecoration.DecorationDescriptorSet, 0));
        _decorations.Add(new(@input_data, SpvDecoration.DecorationBinding, 0));
        
        // output buffer
        id @output_buffer_struct = AddType(new SpvTypeStruct(@runtime_arr_float));
        _decorations.Add(new(@output_buffer_struct, SpvDecoration.DecorationBufferBlock));
        _memberDecorations.Add(new(@output_buffer_struct, 0, SpvDecoration.DecorationOffset, 0));
        id @ptr_uniform_output_buffer_struct = AddType(new SpvTypePointer(SpvStorageClass.StorageClassUniform, @output_buffer_struct));
        id @output_data = AddVariable(0, @ptr_uniform_output_buffer_struct, SpvStorageClass.StorageClassUniform);
        _decorations.Add(new(@output_data, SpvDecoration.DecorationDescriptorSet, 1));
        _decorations.Add(new(@output_data, SpvDecoration.DecorationBinding, 0));
        
        // main function
        id @void = AddType(new SpvTypeVoid());
        id @voidFunc = AddType(new SpvTypeFunction(@void));
        SpvFunction main = new() {
            id = GetNextId(),
            control = SpvFunctionControlMask.FunctionControlMaskNone,
            parameters = Array.Empty<(uint type, uint id)>(),
            functionType = @voidFunc,
            returnType = @void,
            nextBlock = new() {
                blockId = GetNextId(),
                next = new() {
                    blockId = GetNextId()
                }
            }
        };
        
        id @uint_0 = AddConstant(@uint, 0);
        id @gl_GlobalInvocationID_x_ptr = GetNextId();
        id @gl_GlobalInvocationID_x = GetNextId();
        main.nextBlock.instructions.Add(new OpAccessChain(@ptr_uint, @gl_GlobalInvocationID_x_ptr, @gl_GlobalInvocationID, @uint_0));
        main.nextBlock.instructions.Add(new OpLoad(@uint, @gl_GlobalInvocationID_x, @gl_GlobalInvocationID_x_ptr));

        id @ptr_float = AddType(new SpvTypePointer(SpvStorageClass.StorageClassUniform, @float));
        id @input_v_ptr = GetNextId();
        id @input_v = GetNextId();
        id @int = AddType(new SpvTypeInt(32, true));
        id @int_0 = AddConstant(@int, 0);
        main.nextBlock.instructions.Add(new OpAccessChain(@ptr_float, @input_v_ptr, @input_data, @int_0, @gl_GlobalInvocationID_x));
        main.nextBlock.instructions.Add(new OpLoad(@float, @input_v, @input_v_ptr));

        id @float_10 = AddConstant(@float, 10f);
        id @input_v_add_2 = GetNextId();
        main.nextBlock.instructions.Add(new OpFMul(@float, @input_v_add_2, @input_v, @float_10));
        
        id @output_v_ptr = GetNextId();
        main.nextBlock.instructions.Add(new OpAccessChain(@ptr_float, @output_v_ptr, @output_data, @int_0, @gl_GlobalInvocationID_x));
        main.nextBlock.instructions.Add(new OpStore(@output_v_ptr, @input_v_add_2));

        _functions.Add("main", main);
    }

    private id GetNextId() => _maxId++;

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

        foreach (SpvDecorationData decoration in _decorations) 
            code.EmitOpDecorate(decoration.id, decoration.name, decoration.args);
        
        foreach (SpvMemberDecorationData decoration in _memberDecorations) 
            code.EmitOpMemberDecorate(decoration.id, decoration.member, decoration.name, decoration.args);

        foreach (KeyValuePair<SpvType,uint> type in _types)
            type.Key.Emit(code, type.Value);

        foreach (ISpvConst constant in _constants) 
            constant.Emit(code);

        foreach (SpvVariable variable in _variables.Where(v => v.storageClass != SpvStorageClass.StorageClassFunction)) 
            code.EmitOpVariable(variable.type, variable.id, variable.storageClass);

        foreach (KeyValuePair<string,SpvFunction> fun in _functions) 
            GenerateFunction(fun.Value);
    }

    private void GenerateFunction(SpvFunction fun) {
        code.EmitOpFunction(fun.returnType, fun.id, fun.control, fun.functionType);
        
        foreach ((uint type, uint id) in fun.parameters) 
            code.EmitOpFunctionParameter(type, id);
        
        code.EmitOpLabel(fun.nextBlock.blockId);
        foreach (SpvVariable variable in _variables.Where(v => v.storageClass == SpvStorageClass.StorageClassFunction && v.owner == fun.id)) 
            code.EmitOpVariable(variable.type, variable.id, variable.storageClass);
        
        fun.nextBlock.Emit(code, false);
        
        code.EmitOpReturn();
        code.EmitOpFunctionEnd();
    }

    public id AddType(SpvType type) {
        if (_types.TryGetValue(type, out id id)) return id;
        id = GetNextId();
        _types.Add(type, id);
        return id;
    }
    
    public id AddVariable(id owner, id type, SpvStorageClass storageClass) {
        id id = GetNextId();
        _variables.Add(new() {id = id, owner = owner, type = type, storageClass = storageClass});
        return id;
    }

    public id AddConstant<T>(id type, T v) where T : unmanaged {
        uint[] ints = SpirVEmitter.GetInts(v);
        
        foreach (ISpvConst c in _constants)
            if (c is SpvConst c1 && c1.type == type && c1.value == ints)
                return c1.id;
        
        id id = GetNextId();
        _constants.Add(new SpvConst(type, id, ints));
        return id;
    }
    
    public id AddConstantComposite(id type, params uint[] constituents) {
        foreach (ISpvConst c in _constants)
            if (c is SpvConstComposite c1 && c1.type == type && c1.constituents == constituents)
                return c1.id;
        
        id id = GetNextId();
        _constants.Add(new SpvConstComposite(type, id, constituents));
        return id;
    }
}