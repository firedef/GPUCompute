using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.emit.enums.extensions;
using GPUCompute.spirv.gen.types;

namespace GPUCompute.spirv.gen.instructions;

public partial class SpvFunctionInstructions {
    public void Nop() {
        _function.Instruction(new SpvOp.Unified.OpNop());
    }

    public Id Undef(SpvType type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUndef(type.GetId(_code), result));
        return result;
    }

    public void Source(SpvSourceLanguage lang, uint version) {
        _function.Instruction(new SpvOp.Unified.OpSource(lang, version));
    }

    public void SourceExtension(string ext) {
        _function.Instruction(new SpvOp.Unified.OpSourceExtension(ext));
    }

    public void Name(Id id, string name) {
        _function.Instruction(new SpvOp.Unified.OpName(id, name));
    }

    public void MemberName(Id id, Id member, string name) {
        _function.Instruction(new SpvOp.Unified.OpMemberName(id, member, name));
    }

    public void Decorate(Id target, SpvDecoration decoration, uint[] literals) {
        _function.Instruction(new SpvOp.Unified.OpDecorate(target, decoration, literals));
    }

    public void DecorateBuiltIn(Id target, SpvBuiltIn builtIn) {
        _function.Instruction(new SpvOp.Unified.OpDecorateBuiltIn(target, builtIn));
    }

    public void MemberDecorate(Id structureType, Id member, SpvDecoration decoration, uint[] literals) {
        _function.Instruction(new SpvOp.Unified.OpMemberDecorate(structureType, member, decoration, literals));
    }

    public Id DecorationGroup() {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDecorationGroup(result));
        return result;
    }

    public void GroupDecorate(Id group, params Id[] targets) {
        _function.Instruction(new SpvOp.Unified.OpGroupDecorate(group, targets.Select(v => v.v).ToArray()));
    }

    public void GroupMemberDecorate(Id group, (Id id, uint literal)[] args) {
        _function.Instruction(new SpvOp.Unified.OpGroupMemberDecorate(group, args.Select(v => (v.id.v, v.literal)).ToArray()));
    }

    public void Extension(Id id, string ext) {
        _function.Instruction(new SpvOp.Unified.OpExtension(id, ext));
    }

    public void ExtInstImport(Id id, string ext) {
        _function.Instruction(new SpvOp.Unified.OpExtInstImport(id, ext));
    }

    public void MemoryModel(SpvAddressingModel model, Id id) {
        _function.Instruction(new SpvOp.Unified.OpMemoryModel(model, id));
    }

    public void EntryPoint(SpvExecutionModel executionModel, Id entryPoint, string name, params Id[] interfaces) {
        _function.Instruction(new SpvOp.Unified.OpEntryPoint(executionModel, entryPoint, name, interfaces.Select(v => v.v).ToArray()));
    }

    public void ExecutionMode(Id id, SpvExecutionMode mode, uint x, uint y, uint z) {
        _function.Instruction(new SpvOp.Unified.OpExecutionMode(id, mode, x, y, z));
    }

    public void Capability(SpvCapability capability) {
        _function.Instruction(new SpvOp.Unified.OpCapability(capability));
    }

    public Id Type(SpvOpCode type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpType(type, result));
        return result;
    }

    public Id TypeVoid() {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeVoid(result));
        return result;
    }

    public Id TypeBool() {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeBool(result));
        return result;
    }

    public Id TypeFloat(uint width) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeFloat(result, width));
        return result;
    }

    public Id TypeInt(uint width, uint signedness) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeInt(result, width, signedness));
        return result;
    }

    public Id TypeVector(Id componentType, uint length) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeVector(result, componentType, length));
        return result;
    }

    public Id TypeMatrix(Id columnType, uint columnCount) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeMatrix(result, columnType, columnCount));
        return result;
    }

    public Id TypeImage(Id sampledType, SpvDimension dim, uint depth, uint arrayed, uint multisample, uint sampled, SpvImageFormat format) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeImage(result, sampledType, dim, depth, arrayed, multisample, sampled, format));
        return result;
    }

    public Id TypeSampler() {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeSampler(result));
        return result;
    }

    public Id TypeSampledImage(Id imageType) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeSampledImage(result, imageType));
        return result;
    }

    public Id TypeArray(Id elementType, uint length) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeArray(result, elementType, length));
        return result;
    }

    public Id TypeRuntimeArray(Id elementType) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTypeRuntimeArray(result, elementType));
        return result;
    }

    public void TypeStruct(Id id, params Id[] memberTypes) {
        _function.Instruction(new SpvOp.Unified.OpTypeStruct(id, memberTypes.Select(v => v.v).ToArray()));
    }

    public void TypePointer(Id id, Id storageClass, Id type) {
        _function.Instruction(new SpvOp.Unified.OpTypePointer(id, storageClass, type));
    }

    public void TypeFunction(Id id, Id returnType, params Id[] parameters) {
        _function.Instruction(new SpvOp.Unified.OpTypeFunction(id, returnType, parameters.Select(v => v.v).ToArray()));
    }

    public void TypeEvent(Id id) {
        _function.Instruction(new SpvOp.Unified.OpTypeEvent(id));
    }

    public void TypeDeviceEvent(Id id) {
        _function.Instruction(new SpvOp.Unified.OpTypeDeviceEvent(id));
    }

    public void TypeReserveId(Id id) {
        _function.Instruction(new SpvOp.Unified.OpTypeReserveId(id));
    }

    public void TypeQueue(Id id) {
        _function.Instruction(new SpvOp.Unified.OpTypeQueue(id));
    }

    public void TypePipe(Id id, SpvAccessQualifier access) {
        _function.Instruction(new SpvOp.Unified.OpTypePipe(id, access));
    }

    public void TypeForwardPointer(uint id, uint storageClass) {
        _function.Instruction(new SpvOp.Unified.OpTypeForwardPointer(id, storageClass));
    }

    public Id ConstantTrue(SpvType type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConstantTrue(type.GetId(_code), result));
        return result;
    }

    public Id ConstantFalse(SpvType type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConstantFalse(type.GetId(_code), result));
        return result;
    }

    public Id ConstantNull(SpvType type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConstantNull(type.GetId(_code), result));
        return result;
    }

    public void Constant<T>(Id type, Id id, T v) where T : unmanaged {
        _function.Instruction(new SpvOp.Unified.OpConstant<T>(type, id, v));
    }

    public void Constant(Id type, Id id, params uint[] v) {
        _function.Instruction(new SpvOp.Unified.OpConstant2(type, id, v));
    }

    public Id ConstantComposite(SpvType type, params Id[] constituents) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConstantComposite(type.GetId(_code), result, constituents.Select(v => v.v).ToArray()));
        return result;
    }

    public void Branch(Id target) {
        _function.Instruction(new SpvOp.Unified.OpBranch(target));
    }

    public void BranchConditional(Id condition, Id ifTrue, Id ifFalse) {
        _function.Instruction(new SpvOp.Unified.OpBranchConditional(condition, ifTrue, ifFalse));
    }

    public void BranchConditional(Id condition, Id ifTrue, Id ifFalse, uint weightTrue, uint weightFalse) {
        _function.Instruction(new SpvOp.Unified.OpBranchConditional2(condition, ifTrue, ifFalse, weightTrue, weightFalse));
    }

    public void Switch(Id selector, Id ifDefault, (uint literal, Id label)[] elements) {
        _function.Instruction(new SpvOp.Unified.OpSwitch(selector, ifDefault, elements.Select(v => (v.literal, v.label.v)).ToArray()));
    }

    public void Label(Id id) {
        _function.Instruction(new SpvOp.Unified.OpLabel(id));
    }

    public void Return() {
        _function.Instruction(new SpvOp.Unified.OpReturn());
    }

    public void ReturnValue(Id value) {
        _function.Instruction(new SpvOp.Unified.OpReturnValue(value));
    }

    public Id ExtInst(SpvType type, Id instructionSet, SpvExtInstGlslStd instruction, params Id[] operands) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpExtInst(type.GetId(_code), result, instructionSet, (uint)instruction, operands.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ExtInst(SpvType type, Id instructionSet, SpvExtInstOpenClStd instruction, params Id[] operands) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpExtInst(type.GetId(_code), result, instructionSet, (uint)instruction, operands.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ExtInst(SpvType type, Id instructionSet, uint instruction, params Id[] operands) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpExtInst(type.GetId(_code), result, instructionSet, instruction, operands.Select(v => v.v).ToArray()));
        return result;
    }

    public Id Variable(SpvType type, SpvStorageClass storageClass) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVariable(type.GetId(_code), result, storageClass));
        return result;
    }

    public Id Variable(SpvType type, Id storageClass, Id access) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVariable2(type.GetId(_code), result, storageClass, access));
        return result;
    }

    public Id ImageTexelPointer(SpvType type, Id img, Id coordinate, Id sample) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageTexelPointer(type.GetId(_code), result, img, coordinate, sample));
        return result;
    }

    public Id Load(SpvType type, Id pointer) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLoad(type.GetId(_code), result, pointer));
        return result;
    }

    public Id Load(SpvType type, Id pointer, Id access) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLoad2(type.GetId(_code), result, pointer, access));
        return result;
    }

    public void Store(Id pointer, Id obj) {
        _function.Instruction(new SpvOp.Unified.OpStore(pointer, obj));
    }

    public void Store(Id pointer, Id obj, Id access) {
        _function.Instruction(new SpvOp.Unified.OpStore2(pointer, obj, access));
    }

    public void CopyMemory(Id target, Id src) {
        _function.Instruction(new SpvOp.Unified.OpCopyMemory(target, src));
    }

    public void CopyMemory(Id target, Id src, SpvMemoryAccessMask access) {
        _function.Instruction(new SpvOp.Unified.OpCopyMemory2(target, src, access));
    }

    public void CopyMemorySized(Id target, Id src, Id size) {
        _function.Instruction(new SpvOp.Unified.OpCopyMemorySized(target, src, size));
    }

    public void CopyMemorySized(Id target, Id src, Id size, SpvMemoryAccessMask access) {
        _function.Instruction(new SpvOp.Unified.OpCopyMemorySized2(target, src, size, access));
    }

    public Id AccessChain(SpvType type, Id baseid, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAccessChain(type.GetId(_code), result, baseid, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id InBoundsAccessChain(SpvType type, Id baseid, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpInBoundsAccessChain(type.GetId(_code), result, baseid, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id PtrAccessChain(SpvType type, Id baseid, Id element, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpPtrAccessChain(type.GetId(_code), result, baseid, element, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ArrayLength(SpvType type, Id structure, uint arrayMem) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpArrayLength(type.GetId(_code), result, structure, arrayMem));
        return result;
    }

    public Id GenericPtrMemSemantics(SpvType type, Id ptr) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGenericPtrMemSemantics(type.GetId(_code), result, ptr));
        return result;
    }

    public Id InBoundsPtrAccessChain(SpvType type, Id baseid, Id element, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpInBoundsPtrAccessChain(type.GetId(_code), result, baseid, element, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id Function(SpvType type, SpvFunctionControlMask control, Id functionType) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFunction(type.GetId(_code), result, control, functionType));
        return result;
    }

    public Id FunctionParameter(SpvType type) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFunctionParameter(type.GetId(_code), result));
        return result;
    }

    public void FunctionEnd() {
        _function.Instruction(new SpvOp.Unified.OpFunctionEnd());
    }

    public Id FunctionCall(SpvType type, Id func, params Id[] args) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFunctionCall(type.GetId(_code), result, func, args.Select(v => v.v).ToArray()));
        return result;
    }

    public Id SampledImage(SpvType type, Id img, Id sampler) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSampledImage(type.GetId(_code), result, img, sampler));
        return result;
    }

    public Id ImageSampleImplicitLod(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleImplicitLod(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageSampleImplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleImplicitLod2(type.GetId(_code), result, img, coordinate, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleExplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, Id id) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleExplicitLod(type.GetId(_code), result, img, coordinate, operands, id));
        return result;
    }

    public Id ImageSampleExplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, Id id, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleExplicitLod2(type.GetId(_code), result, img, coordinate, operands, id, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleDrefImplicitLod(SpvType type, Id img, Id coordinate, Id dref) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleDrefImplicitLod(type.GetId(_code), result, img, coordinate, dref));
        return result;
    }

    public Id ImageSampleDrefImplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleDrefImplicitLod2(type.GetId(_code), result, img, coordinate, dref, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleDrefExplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, Id id) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleDrefExplicitLod(type.GetId(_code), result, img, coordinate, dref, operands, id));
        return result;
    }

    public Id ImageSampleDrefExplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, Id id, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleDrefExplicitLod2(type.GetId(_code), result, img, coordinate, dref, operands, id, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleProjImplicitLod(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjImplicitLod(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageSampleProjImplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjImplicitLod2(type.GetId(_code), result, img, coordinate, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleProjExplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, Id id) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjExplicitLod(type.GetId(_code), result, img, coordinate, operands, id));
        return result;
    }

    public Id ImageSampleProjExplicitLod(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, Id id, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjExplicitLod2(type.GetId(_code), result, img, coordinate, operands, id, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleProjDrefImplicitLod(SpvType type, Id img, Id coordinate, Id dref) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjDrefImplicitLod(type.GetId(_code), result, img, coordinate, dref));
        return result;
    }

    public Id ImageSampleProjDrefImplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjDrefImplicitLod2(type.GetId(_code), result, img, coordinate, dref, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageSampleProjDrefExplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, Id id) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjDrefExplicitLod(type.GetId(_code), result, img, coordinate, dref, operands, id));
        return result;
    }

    public Id ImageSampleProjDrefExplicitLod(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, Id id, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSampleProjDrefExplicitLod2(type.GetId(_code), result, img, coordinate, dref, operands, id, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageFetch(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageFetch(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageFetch(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageFetch2(type.GetId(_code), result, img, coordinate, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageGather(SpvType type, Id img, Id coordinate, Id component) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageGather(type.GetId(_code), result, img, coordinate, component));
        return result;
    }

    public Id ImageGather(SpvType type, Id img, Id coordinate, Id component, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageGather2(type.GetId(_code), result, img, coordinate, component, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageDrefGather(SpvType type, Id img, Id coordinate, Id dref) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageDrefGather(type.GetId(_code), result, img, coordinate, dref));
        return result;
    }

    public Id ImageDrefGather(SpvType type, Id img, Id coordinate, Id dref, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageDrefGather2(type.GetId(_code), result, img, coordinate, dref, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageRead(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageRead(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageRead(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageRead2(type.GetId(_code), result, img, coordinate, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id ImageWrite(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageWrite(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageWrite(SpvType type, Id img, SpvImageOperandsMask operands, params Id[] ids) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageWrite2(type.GetId(_code), result, img, operands, ids.Select(v => v.v).ToArray()));
        return result;
    }

    public Id Image(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImage(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageQueryFormat(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQueryFormat(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageQueryOrder(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQueryOrder(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageQuerySizeLod(SpvType type, Id img, Id lod) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQuerySizeLod(type.GetId(_code), result, img, lod));
        return result;
    }

    public Id ImageQuerySize(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQuerySize(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageQueryLod(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQueryLod(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageQueryLevels(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQueryLevels(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageQuerySamples(SpvType type, Id img) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageQuerySamples(type.GetId(_code), result, img));
        return result;
    }

    public Id ImageSparseTexelsResident(SpvType type, Id code) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSparseTexelsResident(type.GetId(_code), result, code));
        return result;
    }

    public Id ImageSparseRead(SpvType type, Id img, Id coordinate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSparseRead(type.GetId(_code), result, img, coordinate));
        return result;
    }

    public Id ImageSparseRead(SpvType type, Id img, Id coordinate, SpvImageOperandsMask operands) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpImageSparseRead2(type.GetId(_code), result, img, coordinate, operands));
        return result;
    }

    public Id ConvertFToU(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertFToU(type.GetId(_code), result, val));
        return result;
    }

    public Id ConvertFToS(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertFToS(type.GetId(_code), result, val));
        return result;
    }

    public Id ConvertSToF(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertSToF(type.GetId(_code), result, val));
        return result;
    }

    public Id ConvertUToF(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertUToF(type.GetId(_code), result, val));
        return result;
    }

    public Id UConvert(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUConvert(type.GetId(_code), result, val));
        return result;
    }

    public Id SConvert(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSConvert(type.GetId(_code), result, val));
        return result;
    }

    public Id FConvert(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFConvert(type.GetId(_code), result, val));
        return result;
    }

    public Id QuantizeToF16(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpQuantizeToF16(type.GetId(_code), result, val));
        return result;
    }

    public Id ConvertPtrToU(SpvType type, Id ptr) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertPtrToU(type.GetId(_code), result, ptr));
        return result;
    }

    public Id SatConvertSToU(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSatConvertSToU(type.GetId(_code), result, val));
        return result;
    }

    public Id SatConvertUToS(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSatConvertUToS(type.GetId(_code), result, val));
        return result;
    }

    public Id ConvertUToPtr(SpvType type, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpConvertUToPtr(type.GetId(_code), result, val));
        return result;
    }

    public Id PtrCastToGeneric(SpvType type, Id ptr) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpPtrCastToGeneric(type.GetId(_code), result, ptr));
        return result;
    }

    public Id GenericCastToPtr(SpvType type, Id ptr) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGenericCastToPtr(type.GetId(_code), result, ptr));
        return result;
    }

    public Id GenericCastToPtrExplicit(SpvType type, Id ptr, Id storage) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGenericCastToPtrExplicit(type.GetId(_code), result, ptr, storage));
        return result;
    }

    public Id Bitcast(SpvType type, Id operand) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitcast(type.GetId(_code), result, operand));
        return result;
    }

    public Id VectorExtractDynamic(SpvType type, Id vec, Id index) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVectorExtractDynamic(type.GetId(_code), result, vec, index));
        return result;
    }

    public Id VectorInsertDynamic(SpvType type, Id vec, Id component, Id index) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVectorInsertDynamic(type.GetId(_code), result, vec, component, index));
        return result;
    }

    public Id VectorShuffle(SpvType type, Id vec1, Id vec2, uint[] components) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVectorShuffle(type.GetId(_code), result, vec1, vec2, components));
        return result;
    }

    public Id CompositeConstruct(SpvType type, params Id[] constituents) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpCompositeConstruct(type.GetId(_code), result, constituents.Select(v => v.v).ToArray()));
        return result;
    }

    public Id CompositeExtract(SpvType type, Id composite, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpCompositeExtract(type.GetId(_code), result, composite, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id CompositeInsert(SpvType type, Id obj, Id composite, params Id[] indexes) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpCompositeInsert(type.GetId(_code), result, obj, composite, indexes.Select(v => v.v).ToArray()));
        return result;
    }

    public Id CopyObject(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpCopyObject(type.GetId(_code), result, op1));
        return result;
    }

    public Id Transpose(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpTranspose(type.GetId(_code), result, op1));
        return result;
    }

    public Id SNegate(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSNegate(type.GetId(_code), result, op1));
        return result;
    }

    public Id FNegate(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFNegate(type.GetId(_code), result, op1));
        return result;
    }

    public Id IAdd(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIAdd(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FAdd(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFAdd(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ISub(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpISub(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FSub(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFSub(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id IMul(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIMul(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FMul(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFMul(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id UDiv(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUDiv(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SDiv(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSDiv(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FDiv(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFDiv(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id UMod(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUMod(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SMod(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSMod(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FMod(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFMod(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SRem(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSRem(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FRem(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFRem(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id VectorTimesScalar(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVectorTimesScalar(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id MatrixTimesScalar(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpMatrixTimesScalar(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id VectorTimesMatrix(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpVectorTimesMatrix(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id MatrixTimesVector(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpMatrixTimesVector(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id MatrixTimesMatrix(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpMatrixTimesMatrix(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id OuterProduct(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpOuterProduct(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id Dot(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDot(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id IAddCarry(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIAddCarry(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ISubBorrow(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpISubBorrow(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id UMulExtended(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUMulExtended(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SMulExtended(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSMulExtended(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ShiftRightLogical(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpShiftRightLogical(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ShiftRightArithmetic(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpShiftRightArithmetic(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ShiftLeftLogical(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpShiftLeftLogical(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id BitwiseOr(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitwiseOr(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id BitwiseXor(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitwiseXor(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id BitwiseAnd(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitwiseAnd(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id Not(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpNot(type.GetId(_code), result, op1));
        return result;
    }

    public Id BitFieldInsert(SpvType type, Id @base, Id insert, Id offset, Id count) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitFieldInsert(type.GetId(_code), result, @base, insert, offset, count));
        return result;
    }

    public Id BitFieldSExtract(SpvType type, Id @base, Id offset, Id count) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitFieldSExtract(type.GetId(_code), result, @base, offset, count));
        return result;
    }

    public Id BitFieldUExtract(SpvType type, Id @base, Id offset, Id count) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitFieldUExtract(type.GetId(_code), result, @base, offset, count));
        return result;
    }

    public Id BitReverse(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitReverse(type.GetId(_code), result, op1));
        return result;
    }

    public Id BitCount(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpBitCount(type.GetId(_code), result, op1));
        return result;
    }

    public Id Any(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAny(type.GetId(_code), result, op1));
        return result;
    }

    public Id All(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAll(type.GetId(_code), result, op1));
        return result;
    }

    public Id IsNan(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIsNan(type.GetId(_code), result, op1));
        return result;
    }

    public Id IsInf(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIsInf(type.GetId(_code), result, op1));
        return result;
    }

    public Id IsFinite(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIsFinite(type.GetId(_code), result, op1));
        return result;
    }

    public Id IsNormal(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIsNormal(type.GetId(_code), result, op1));
        return result;
    }

    public Id SignBitSet(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSignBitSet(type.GetId(_code), result, op1));
        return result;
    }

    public Id LessOrGreater(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLessOrGreater(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id Ordered(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpOrdered(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id Unordered(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUnordered(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id LogicalEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLogicalEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id LogicalNotEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLogicalNotEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id LogicalOr(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLogicalOr(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id LogicalAnd(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLogicalAnd(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id LogicalNot(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpLogicalNot(type.GetId(_code), result, op1));
        return result;
    }

    public Id Select(SpvType type, Id condition, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSelect(type.GetId(_code), result, condition, op1, op2));
        return result;
    }

    public Id IEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpIEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id INotEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpINotEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id UGreaterThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUGreaterThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SGreaterThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSGreaterThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id UGreaterThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpUGreaterThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SGreaterThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSGreaterThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ULessThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpULessThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SLessThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSLessThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id ULessThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpULessThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id SLessThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpSLessThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdNotEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdNotEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordNotEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordNotEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdLessThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdLessThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordLessThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordLessThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdGreaterThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdGreaterThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordGreaterThan(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordGreaterThan(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdLessThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdLessThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordLessThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordLessThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FOrdGreaterThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFOrdGreaterThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id FUnordGreaterThanEqual(SpvType type, Id op1, Id op2) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFUnordGreaterThanEqual(type.GetId(_code), result, op1, op2));
        return result;
    }

    public Id DPdx(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdx(type.GetId(_code), result, op1));
        return result;
    }

    public Id DPdy(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdy(type.GetId(_code), result, op1));
        return result;
    }

    public Id Fwidth(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFwidth(type.GetId(_code), result, op1));
        return result;
    }

    public Id DPdxFine(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdxFine(type.GetId(_code), result, op1));
        return result;
    }

    public Id DPdyFine(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdyFine(type.GetId(_code), result, op1));
        return result;
    }

    public Id FwidthFine(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFwidthFine(type.GetId(_code), result, op1));
        return result;
    }

    public Id DPdxCoarse(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdxCoarse(type.GetId(_code), result, op1));
        return result;
    }

    public Id DPdyCoarse(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpDPdyCoarse(type.GetId(_code), result, op1));
        return result;
    }

    public Id FwidthCoarse(SpvType type, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpFwidthCoarse(type.GetId(_code), result, op1));
        return result;
    }

    public Id Phi(SpvType type, (Id variable, Id parent)[] parts) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpPhi(type.GetId(_code), result, parts.Select(v => (v.variable.v, v.parent.v)).ToArray()));
        return result;
    }

    public void LoopMerge(Id mergeBlock, Id continueTarget, SpvLoopControlMask loopControl) {
        _function.Instruction(new SpvOp.Unified.OpLoopMerge(mergeBlock, continueTarget, loopControl));
    }

    public void SelectionMerge(Id mergeBlock, SpvSelectionControlMask selectionControl) {
        _function.Instruction(new SpvOp.Unified.OpSelectionMerge(mergeBlock, selectionControl));
    }

    public Id AtomicLoad(SpvType type, Id ptr, Id scope, Id semantics) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicLoad(type.GetId(_code), result, ptr, scope, semantics));
        return result;
    }

    public void AtomicStore(Id ptr, Id scope, Id semantics, Id val) {
        _function.Instruction(new SpvOp.Unified.OpAtomicStore(ptr, scope, semantics, val));
    }

    public Id AtomicExchange(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicExchange(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicCompareExchange(SpvType type, Id ptr, Id scope, Id eq, Id uneq, Id val, Id comparator) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicCompareExchange(type.GetId(_code), result, ptr, scope, eq, uneq, val, comparator));
        return result;
    }

    public Id AtomicCompareExchangeWeak(SpvType type, Id ptr, Id scope, Id eq, Id uneq, Id val, Id comparator) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicCompareExchangeWeak(type.GetId(_code), result, ptr, scope, eq, uneq, val, comparator));
        return result;
    }

    public Id AtomicIIncrement(SpvType type, Id ptr, Id scope, Id semantics) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicIIncrement(type.GetId(_code), result, ptr, scope, semantics));
        return result;
    }

    public Id AtomicIDecrement(SpvType type, Id ptr, Id scope, Id semantics) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicIDecrement(type.GetId(_code), result, ptr, scope, semantics));
        return result;
    }

    public Id AtomicIAdd(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicIAdd(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicISub(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicISub(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicSMin(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicSMin(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicUMin(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicUMin(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicSMax(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicSMax(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicUMax(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicUMax(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicAnd(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicAnd(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicOr(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicOr(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicXor(SpvType type, Id ptr, Id scope, Id semantics, Id val) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicXor(type.GetId(_code), result, ptr, scope, semantics, val));
        return result;
    }

    public Id AtomicFlagTestAndSet(SpvType type, Id ptr, Id scope, Id semantics) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpAtomicFlagTestAndSet(type.GetId(_code), result, ptr, scope, semantics));
        return result;
    }

    public void AtomicFlagClear(Id ptr, Id scope, Id semantics) {
        _function.Instruction(new SpvOp.Unified.OpAtomicFlagClear(ptr, scope, semantics));
    }

    public void EmitVertex() {
        _function.Instruction(new SpvOp.Unified.OpVertex());
    }

    public void EndPrimitive() {
        _function.Instruction(new SpvOp.Unified.OpEndPrimitive());
    }

    public void EmitStreamVertex(Id stream) {
        _function.Instruction(new SpvOp.Unified.OpStreamVertex(stream));
    }

    public void EndStreamPrimitive(Id stream) {
        _function.Instruction(new SpvOp.Unified.OpEndStreamPrimitive(stream));
    }

    public void ControlBarrier(Id execution, Id mem, Id semantics) {
        _function.Instruction(new SpvOp.Unified.OpControlBarrier(execution, mem, semantics));
    }

    public void MemoryBarrier(Id mem, Id semantics) {
        _function.Instruction(new SpvOp.Unified.OpMemoryBarrier(mem, semantics));
    }

    public Id GroupAsyncCopy(SpvType type, Id execution, Id dest, Id src, Id numElements, Id stride, Id @event) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupAsyncCopy(type.GetId(_code), result, execution, dest, src, numElements, stride, @event));
        return result;
    }

    public void GroupWaitEvents(Id execution, Id numEvents, Id eventsList) {
        _function.Instruction(new SpvOp.Unified.OpGroupWaitEvents(execution, numEvents, eventsList));
    }

    public Id GroupAll(SpvType type, Id execution, Id predicate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupAll(type.GetId(_code), result, execution, predicate));
        return result;
    }

    public Id GroupAny(SpvType type, Id execution, Id predicate) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupAny(type.GetId(_code), result, execution, predicate));
        return result;
    }

    public Id GroupBroadcast(SpvType type, Id execution, Id val, Id localId) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupBroadcast(type.GetId(_code), result, execution, val, localId));
        return result;
    }

    public Id GroupIAdd(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupIAdd(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupFAdd(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupFAdd(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupFMin(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupFMin(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupUMin(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupUMin(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupSMin(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupSMin(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupFMax(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupFMax(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupUMax(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupUMax(type.GetId(_code), result, execution, operation, op1));
        return result;
    }

    public Id GroupSMax(SpvType type, Id execution, Id operation, Id op1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.Unified.OpGroupSMax(type.GetId(_code), result, execution, operation, op1));
        return result;
    }
}