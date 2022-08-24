using System.Text;
using GPUCompute.spirv.emit.enums;

using id = System.UInt32;
// ReSharper disable BuiltInTypeReferenceStyle

namespace GPUCompute.spirv.emit; 

public class SpirVEmitter {
    private List<uint> bytecode = new();

    public SpirVEmitter() {
        EmitHeader();
    }

    public uint[] GetByteCode() => bytecode.ToArray();

    private void Emit(uint b) => bytecode.Add(b);

    private void Emit(uint b0, uint b1) {
        bytecode.Add(b0);
        bytecode.Add(b1);
    }
    
    private void Emit(uint b0, uint b1, uint b2) {
        bytecode.Add(b0);
        bytecode.Add(b1);
        bytecode.Add(b2);
    }
    
    private void Emit(uint b0, uint b1, uint b2, uint b3) {
        bytecode.Add(b0);
        bytecode.Add(b1);
        bytecode.Add(b2);
        bytecode.Add(b3);
    }

    private void Emit(params uint[] words) {
        foreach (uint w in words) Emit(w);
    }

    private void EmitMagicNum() => Emit(0x07230203);
    private void EmitVersion() => Emit(0x00010000);
    private void EmitCompilerMagicNum() => Emit(0);
    private void EmitBound() => Emit(0x0000003e);
    private void EmitReserved4() => Emit(0);

    private void EmitHeader() {
        EmitMagicNum();
        EmitVersion();
        EmitCompilerMagicNum();
        EmitBound();
        EmitReserved4();
    }

    public void EmitOpCode(ushort wordCount, ushort opCode) => Emit(opCode | ((uint)wordCount << 16));
    public void EmitOpCode(ushort wordCount, SpvOpCode spvOpCode) => Emit((ushort) spvOpCode | ((uint)wordCount << 16));
    public void EmitInstructionType(uint type) => Emit(type);
    public void EmitOperand(uint op) => Emit(op);

    public void EmitOp(ushort wordCount, SpvOpCode opCode) => EmitOpCode(wordCount, opCode);

    public void EmitOp(ushort wordCount, SpvOpCode opCode, uint w0) {
        EmitOpCode(wordCount, opCode);
        Emit(w0);
    }
    
    public void EmitOp(ushort wordCount, SpvOpCode opCode, uint w0, uint w1) {
        EmitOpCode(wordCount, opCode);
        Emit(w0);
        Emit(w1);
    }
    
    public void EmitOp(ushort wordCount, SpvOpCode opCode, uint w0, uint w1, uint w2) {
        EmitOpCode(wordCount, opCode);
        Emit(w0);
        Emit(w1);
        Emit(w2);
    }
    
    public void EmitOp(ushort wordCount, SpvOpCode opCode, uint w0, uint w1, uint w2, uint w3) {
        EmitOpCode(wordCount, opCode);
        Emit(w0);
        Emit(w1);
        Emit(w2);
        Emit(w3);
    }
    
    public void EmitOp(ushort wordCount, SpvOpCode opCode, params uint[] words) {
        EmitOpCode(wordCount, opCode);
        foreach (uint w in words) Emit(w);
    }

    private void EmitString(string s) {
        uint[] ints = GetInts(s);
        foreach (uint v in ints) Emit(v);
    }

    private uint[] GetInts(string s) {
        s += '\0';
        byte[] bytes = Encoding.ASCII.GetBytes(s);
        uint[] ints = new uint[(int)MathF.Ceiling(bytes.Length * .25f)];
        Buffer.BlockCopy(bytes, 0, ints, 0, bytes.Length);
        return ints;
    }
    
    private unsafe uint[] GetInts<T>(T v) where T : unmanaged {
        uint[] ints = new uint[(int)MathF.Ceiling(sizeof(T) * .25f)];
        for (int i = 0; i < ints.Length; i++) ints[i] = 0;
        fixed (uint* intsPtr = ints) *(T*)intsPtr = v;
        return ints;
    }

    public void EmitOpNop() => EmitOp(1, SpvOpCode.OpNop);
    public void EmitOpUndef(id resultType, id result) => EmitOp(3, SpvOpCode.OpUndef, resultType, result);
    
    public void EmitOpSource(SpvSourceLanguage lang, uint version) => EmitOp(3, SpvOpCode.OpSource, (uint)lang, version);

    public void EmitOpSourceExtension(string ext) {
        uint[] ints = GetInts(ext);
        EmitOp((ushort)(1 + ints.Length), SpvOpCode.OpSourceExtension);
        Emit(ints);
    }

    public void EmitOpName(id id, string name) {
        uint[] ints = GetInts(name);
        EmitOp((ushort)(2 + ints.Length), SpvOpCode.OpName, id);
        Emit(ints);
    }
    
    public void EmitOpMemberName(id id, id member, string name) {
        uint[] ints = GetInts(name);
        EmitOp((ushort)(3 + ints.Length), SpvOpCode.OpMemberName, id, member);
        Emit(ints);
    }

    public void EmitOpDecorate(id target, SpvDecoration decoration, params uint[] literals) {
        EmitOp((ushort)(3 + literals.Length), SpvOpCode.OpDecorate, target, (uint)decoration);
        Emit(literals);
    }

    public void EmitOpMemberDecorate(id structureType, id member, SpvDecoration decoration, params uint[] literals) {
        EmitOp((ushort)(4 + literals.Length), SpvOpCode.OpMemberDecorate, structureType, member, (uint)decoration);
        Emit(literals);
    }

    public void EmitOpDecorationGroup(id result) => EmitOp(2, SpvOpCode.OpDecorationGroup, result);

    public void EmitOpGroupDecorate(id group, id[] targets) {
        EmitOp((ushort)(2 + targets.Length), SpvOpCode.OpGroupDecorate, group);
        Emit(targets);
    }
    
    public void EmitOpGroupMemberDecorate(id group, (id id, uint literal)[] args) {
        EmitOp((ushort)(2 + args.Length * 2), SpvOpCode.OpGroupMemberDecorate, group);
        foreach ((id id, uint literal) in args) Emit(id, literal);
    }

    public void EmitOpExtension(id id, string ext) {
        uint[] ints = GetInts(ext);
        EmitOp((ushort)(2 + ints.Length), SpvOpCode.OpExtension, id);
        Emit(ints);
    }
    
    public void EmitOpExtInstImport(id id, string ext) {
        uint[] ints = GetInts(ext);
        EmitOp((ushort)(2 + ints.Length), SpvOpCode.OpExtInstImport, id);
        Emit(ints);
    }
    
    public void EmitOpMemoryModel(SpvAddressingModel model, id id) => EmitOp(3, SpvOpCode.OpMemoryModel, (uint)model, id);
    
    public void EmitOpEntryPoint(SpvExecutionModel executionModel, id entryPoint, string name, params id[] interfaces) {
        uint[] nameInts = GetInts(name);
        EmitOp((ushort)(3 + nameInts.Length + interfaces.Length), SpvOpCode.OpEntryPoint, (uint)executionModel, entryPoint);
        Emit(nameInts);
        Emit(interfaces);
    }

    public void EmitOpExecutionMode(id id, SpvExecutionMode mode, uint x, uint y, uint z) => EmitOp(6, SpvOpCode.OpExecutionMode, id, (uint)mode, x, y, z);
    public void EmitOpCapability(SpvCapability capability) => EmitOp(2, SpvOpCode.OpCapability, (uint)capability);
    
    public void EmitOpType(SpvOpCode type, id result) => EmitOp(2, type, result);
    public void EmitOpTypeVoid(id result) => EmitOpType(SpvOpCode.OpTypeVoid, result);
    public void EmitOpTypeBool(id result) => EmitOpType(SpvOpCode.OpTypeBool, result);
    public void EmitOpTypeFloat(id result, uint width) => EmitOp(3, SpvOpCode.OpTypeFloat, result, width);
    public void EmitOpTypeInt(id result, uint width, uint signedness) => EmitOp(4, SpvOpCode.OpTypeInt, result, width, signedness);
    public void EmitOpTypeVector(id result, id componentType, uint length) => EmitOp(4, SpvOpCode.OpTypeVector, result, componentType, length);
    public void EmitOpTypeMatrix(id result, id columnType, uint columnCount) => EmitOp(4, SpvOpCode.OpTypeMatrix, result, columnType, columnCount);
    public void EmitOpTypeImage(id result, id sampledType, SpvDimension dim, uint depth, uint arrayed, uint multisample, uint sampled, SpvImageFormat format) => EmitOp(9, SpvOpCode.OpTypeImage, result, sampledType, (uint)dim, depth, arrayed, multisample, sampled, (uint) format);
    public void EmitOpTypeSampler(id result) => EmitOp(2, SpvOpCode.OpTypeSampler, result);
    public void EmitOpTypeSampledImage(id result, id imageType) => EmitOp(3, SpvOpCode.OpTypeSampledImage, result, imageType);
    public void EmitOpTypeArray(id result, id elementType, uint length) => EmitOp(4, SpvOpCode.OpTypeArray, result, elementType, length);
    public void EmitOpTypeRuntimeArray(id result, id elementType) => EmitOp(3, SpvOpCode.OpTypeRuntimeArray, result, elementType);

    public void EmitOpTypeStruct(id id, params id[] memberTypes) {
        EmitOp((ushort)(2 + memberTypes.Length), SpvOpCode.OpTypeStruct, id);
        Emit(memberTypes);
    }
    
    public void EmitOpTypePointer(id id, id storageClass, id type) => EmitOp(4, SpvOpCode.OpTypePointer, id, storageClass, type);

    public void EmitOpTypeFunction(id id, id returnType, params id[] parameters) {
        EmitOp((ushort)(3 + parameters.Length), SpvOpCode.OpTypeFunction, id, returnType);
        Emit(parameters);
    }
    
    public void EmitOpTypeEvent(id id) => EmitOp(2, SpvOpCode.OpTypeEvent, id);
    public void EmitOpTypeDeviceEvent(id id) => EmitOp(2, SpvOpCode.OpTypeDeviceEvent, id);
    public void EmitOpTypeReserveId(id id) => EmitOp(2, SpvOpCode.OpTypeReserveId, id);
    public void EmitOpTypeQueue(id id) => EmitOp(2, SpvOpCode.OpTypeQueue, id);
    public void EmitOpTypePipe(id id, SpvAccessQualifier access) => EmitOp(3, SpvOpCode.OpTypePipe, id, (uint) access);
    public void EmitOpTypeForwardPointer(uint id, uint storageClass) => EmitOp(3, SpvOpCode.OpTypeForwardPointer, id, storageClass);

    public void EmitOpConstantTrue(id resultType, id result) => EmitOp(3, SpvOpCode.OpConstantTrue, resultType, result);
    public void EmitOpConstantFalse(id resultType, id result) => EmitOp(3, SpvOpCode.OpConstantFalse, resultType, result);
    public void EmitOpConstantNull(id resultType, id result) => EmitOp(3, SpvOpCode.OpConstantNull, resultType, result);
    
    public void EmitOpConstant<T>(id type, id id, T v) where T : unmanaged {
        uint[] ints = GetInts(v);
        EmitOp((ushort)(3 + ints.Length), SpvOpCode.OpConstant, type, id);
        Emit(ints);
    }

    public void EmitOpConstantComposite(id resultType, id result, params id[] constituents) {
        EmitOp((ushort)(3 + constituents.Length), SpvOpCode.OpConstantComposite, resultType, result);
        Emit(constituents);
    }

    public void EmitOpBranch(id target) => EmitOp(2, SpvOpCode.OpBranch, target);
    public void EmitOpBranchConditional(id condition, id ifTrue, id ifFalse) => EmitOp(4, SpvOpCode.OpBranchConditional, condition, ifTrue, ifFalse);
    public void EmitOpBranchConditional(id condition, id ifTrue, id ifFalse, uint weightTrue, uint weightFalse) => EmitOp(6, SpvOpCode.OpBranchConditional, condition, ifTrue, ifFalse, weightTrue, weightFalse);

    public void EmitOpSwitch(id selector, id ifDefault, (uint literal, id label)[] elements) {
        EmitOp((ushort)(3 + elements.Length * 2), SpvOpCode.OpBranchConditional, selector, ifDefault);
        foreach ((uint literal, uint label) in elements) Emit(literal, label);
    }
    
    public void EmitOpLabel(id id) => EmitOp(2, SpvOpCode.OpLabel, id);
    public void EmitOpReturn() => EmitOp(1, SpvOpCode.OpReturn);
    public void EmitOpReturnValue(id value) => EmitOp(1, SpvOpCode.OpReturnValue, value);
    
    public void EmitOpExtInst(id resultType, id result, id instructionSet, SpvExtInst instruction, params id[] operands) {
        EmitOp((ushort)(5 + operands.Length), SpvOpCode.OpExtInst, resultType, result, instructionSet, (uint)instruction);
        Emit(operands);
    }
    
    public void EmitOpVariable(id resultType, id result, id storageClass) => EmitOp(4, SpvOpCode.OpVariable, resultType, result, storageClass);
    public void EmitOpVariable(id resultType, id result, id storageClass, id access) => EmitOp(5, SpvOpCode.OpVariable, resultType, result, storageClass, access);
    
    public void EmitOpImageTexelPointer(id resultType, id result, id img, id coordinate, id sample) => EmitOp(6, SpvOpCode.OpImageTexelPointer, resultType, result, img, coordinate, sample);
    
    public void EmitOpLoad(id resultType, id result, id pointer) => EmitOp(4, SpvOpCode.OpLoad, resultType, result, pointer);
    public void EmitOpLoad(id resultType, id result, id pointer, id access) => EmitOp(5, SpvOpCode.OpLoad, resultType, result, pointer, access);
    
    public void EmitOpStore(id pointer, id obj) => EmitOp(3, SpvOpCode.OpStore, pointer, obj);
    public void EmitOpStore(id pointer, id obj, id access) => EmitOp(4, SpvOpCode.OpStore, pointer, obj, access);

    public void EmitOpCopyMemory(id target, id src) => EmitOp(3, SpvOpCode.OpCopyMemory, target, src);
    public void EmitOpCopyMemory(id target, id src, SpvMemoryAccessMask access) => EmitOp(4, SpvOpCode.OpCopyMemory, target, src, (uint)access);
    
    public void EmitOpCopyMemorySized(id target, id src, id size) => EmitOp(4, SpvOpCode.OpCopyMemorySized, target, src, size);
    public void EmitOpCopyMemorySized(id target, id src, id size, SpvMemoryAccessMask access) => EmitOp(5, SpvOpCode.OpCopyMemorySized, target, src, size, (uint) access);
    
    public void EmitOpAccessChain(id resultType, id result, id baseid, params id[] indexes) {
        EmitOp((ushort)(4 + indexes.Length), SpvOpCode.OpAccessChain, resultType, result, baseid);
        Emit(indexes);
    }
    
    public void EmitOpInBoundsAccessChain(id resultType, id result, id baseid, params id[] indexes) {
        EmitOp((ushort)(4 + indexes.Length), SpvOpCode.OpInBoundsAccessChain, resultType, result, baseid);
        Emit(indexes);
    }
    
    public void EmitOpPtrAccessChain(id resultType, id result, id baseid, id element, params id[] indexes) {
        EmitOp((ushort)(5 + indexes.Length), SpvOpCode.OpPtrAccessChain, resultType, result, baseid, element);
        Emit(indexes);
    }
    
    public void EmitOpArrayLength(id resultType, id result, id structure, uint arrayMem) => EmitOp(5, SpvOpCode.OpArrayLength, resultType, result, structure, arrayMem);
    public void EmitOpGenericPtrMemSemantics(id resultType, id result, id ptr) => EmitOp(4, SpvOpCode.OpGenericPtrMemSemantics, resultType, result, ptr);
    
    public void EmitOpInBoundsPtrAccessChain(id resultType, id result, id baseid, id element, id[] indexes) {
        EmitOp((ushort)(5 + indexes.Length), SpvOpCode.OpInBoundsPtrAccessChain, resultType, result, baseid, element);
        Emit(indexes);
    }

    public void EmitOpFunction(id resultType, id result, SpvFunctionControlMask control, id functionType) => EmitOp(5, SpvOpCode.OpFunction, resultType, result, (uint)control, functionType);
    public void EmitOpFunctionParameter(id resultType, id result) => EmitOp(3, SpvOpCode.OpFunctionParameter, resultType, result);
    public void EmitOpFunctionEnd() => EmitOp(1, SpvOpCode.OpFunctionEnd);
    
    public void EmitOpFunctionCall(id resultType, id result, id func, id[] args) {
        EmitOp((ushort)(4 + args.Length), SpvOpCode.OpFunctionCall, resultType, result, func);
        Emit(args);
    }
    
    public void EmitOpSampledImage(id resultType, id result, id img, id sampler) => EmitOp(5, SpvOpCode.OpSampledImage, resultType, result, img, sampler);
    
    public void EmitOpImageSampleImplicitLod(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageSampleImplicitLod, resultType, result, img, coordinate);
    public void EmitOpImageSampleImplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(6 + ids.Length), SpvOpCode.OpImageSampleImplicitLod, resultType, result, img, coordinate, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageSampleExplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id id) => EmitOp(7, SpvOpCode.OpImageSampleExplicitLod, resultType, result, img, coordinate, (uint)operands, id);
    public void EmitOpImageSampleExplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id id, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageSampleExplicitLod, resultType, result, img, coordinate, (uint)operands, id);
        Emit(ids);
    }
    
    public void EmitOpImageSampleDrefImplicitLod(id resultType, id result, id img, id coordinate, id dref) => EmitOp(6, SpvOpCode.OpImageSampleDrefImplicitLod, resultType, result, img, coordinate, dref);
    public void EmitOpImageSampleDrefImplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageSampleDrefImplicitLod, resultType, result, img, coordinate, dref, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageSampleDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id id) => EmitOp(8, SpvOpCode.OpImageSampleDrefExplicitLod, resultType, result, img, coordinate, dref, (uint)operands, id);
    public void EmitOpImageSampleDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id id, id[] ids) {
        EmitOp((ushort)(8 + ids.Length), SpvOpCode.OpImageSampleDrefExplicitLod, resultType, result, img, coordinate, dref, (uint)operands, id);
        Emit(ids);
    }
    
    public void EmitOpImageSampleProjImplicitLod(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageSampleProjImplicitLod, resultType, result, img, coordinate);
    public void EmitOpImageSampleProjImplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(5 + ids.Length), SpvOpCode.OpImageSampleProjImplicitLod, resultType, result, img, coordinate, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageSampleProjExplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id id) => EmitOp(7, SpvOpCode.OpImageSampleProjExplicitLod, resultType, result, img, coordinate, (uint)operands, id);
    public void EmitOpImageSampleProjExplicitLod(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id id, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageSampleProjExplicitLod, resultType, result, img, coordinate, (uint)operands, id);
        Emit(ids);
    }
    
    public void EmitOpImageSampleProjDrefImplicitLod(id resultType, id result, id img, id coordinate, id dref) => EmitOp(6, SpvOpCode.OpImageSampleProjDrefImplicitLod, resultType, result, img, coordinate, dref);
    public void EmitOpImageSampleProjDrefImplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageSampleProjDrefImplicitLod, resultType, result, img, coordinate, dref, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageSampleProjDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id id) => EmitOp(8, SpvOpCode.OpImageSampleProjDrefExplicitLod, resultType, result, img, coordinate, dref, (uint)operands, id);
    public void EmitOpImageSampleProjDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id id, id[] ids) {
        EmitOp((ushort)(8 + ids.Length), SpvOpCode.OpImageSampleProjDrefExplicitLod, resultType, result, img, coordinate, dref, (uint)operands, id);
        Emit(ids);
    }
    
    public void EmitOpImageFetch(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageFetch, resultType, result, img, coordinate);
    public void EmitOpImageFetch(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(6 + ids.Length), SpvOpCode.OpImageFetch, resultType, result, img, coordinate, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageGather(id resultType, id result, id img, id coordinate, id component) => EmitOp(6, SpvOpCode.OpImageGather, resultType, result, img, coordinate, component);
    public void EmitOpImageGather(id resultType, id result, id img, id coordinate, id component, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageGather, resultType, result, img, coordinate, component, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageDrefGather(id resultType, id result, id img, id coordinate, id dref) => EmitOp(6, SpvOpCode.OpImageDrefGather, resultType, result, img, coordinate, dref);
    public void EmitOpImageDrefGather(id resultType, id result, id img, id coordinate, id dref, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(7 + ids.Length), SpvOpCode.OpImageDrefGather, resultType, result, img, coordinate, dref, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageRead(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageRead, resultType, result, img, coordinate);
    public void EmitOpImageRead(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(6 + ids.Length), SpvOpCode.OpImageRead, resultType, result, img, coordinate, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImageWrite(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageWrite, resultType, result, img);
    public void EmitOpImageWrite(id resultType, id result, id img, SpvImageOperandsMask operands, id[] ids) {
        EmitOp((ushort)(5 + ids.Length), SpvOpCode.OpImageWrite, resultType, result, img, (uint)operands);
        Emit(ids);
    }
    
    public void EmitOpImage(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImage, resultType, result, img);
    public void EmitOpImageQueryFormat(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageQueryFormat, resultType, result, img);
    public void EmitOpImageQueryOrder(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageQueryOrder, resultType, result, img);
    public void EmitOpImageQuerySizeLod(id resultType, id result, id img, id lod) => EmitOp(5, SpvOpCode.OpImageQuerySizeLod, resultType, result, img, lod);
    public void EmitOpImageQuerySize(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageQuerySize, resultType, result, img);
    public void EmitOpImageQueryLod(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageQueryLod, resultType, result, img, coordinate);
    public void EmitOpImageQueryLevels(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageQueryLevels, resultType, result, img);
    public void EmitOpImageQuerySamples(id resultType, id result, id img) => EmitOp(4, SpvOpCode.OpImageQuerySamples, resultType, result, img);
    
    public void EmitOpImageSparseTexelsResident(id resultType, id result, id code) => EmitOp(4, SpvOpCode.OpImageSparseTexelsResident, resultType, result, code);
    
    public void EmitOpImageSparseRead(id resultType, id result, id img, id coordinate) => EmitOp(5, SpvOpCode.OpImageSparseRead, resultType, result, img, coordinate);
    public void EmitOpImageSparseRead(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands) => EmitOp(6, SpvOpCode.OpImageSparseRead, resultType, result, img, coordinate, (uint)operands);
    
    public void EmitOpConvertFToU(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpConvertFToU, resultType, result, val);
    public void EmitOpConvertFToS(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpConvertFToS, resultType, result, val);
    public void EmitOpConvertSToF(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpConvertSToF, resultType, result, val);
    public void EmitOpConvertUToF(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpConvertUToF, resultType, result, val);
    public void EmitOpUConvert(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpUConvert, resultType, result, val);
    public void EmitOpSConvert(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpSConvert, resultType, result, val);
    public void EmitOpFConvert(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpFConvert, resultType, result, val);
    public void EmitOpQuantizeToF16(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpQuantizeToF16, resultType, result, val);
    
    public void EmitOpConvertPtrToU(id resultType, id result, id ptr) => EmitOp(4, SpvOpCode.OpConvertPtrToU, resultType, result, ptr);
    public void EmitOpSatConvertSToU(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpSatConvertSToU, resultType, result, val);
    public void EmitOpSatConvertUToS(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpSatConvertUToS, resultType, result, val);
    public void EmitOpConvertUToPtr(id resultType, id result, id val) => EmitOp(4, SpvOpCode.OpConvertUToPtr, resultType, result, val);
    
    public void EmitOpPtrCastToGeneric(id resultType, id result, id ptr) => EmitOp(4, SpvOpCode.OpPtrCastToGeneric, resultType, result, ptr);
    public void EmitOpGenericCastToPtr(id resultType, id result, id ptr) => EmitOp(4, SpvOpCode.OpGenericCastToPtr, resultType, result, ptr);
    public void EmitOpGenericCastToPtrExplicit(id resultType, id result, id ptr, id storage) => EmitOp(5, SpvOpCode.OpGenericCastToPtrExplicit, resultType, result, ptr, storage);
    public void EmitOpBitcast(id resultType, id result, id operand) => EmitOp(4, SpvOpCode.OpBitcast, resultType, result, operand);
    
    public void EmitOpVectorExtractDynamic(id resultType, id result, id vec, id index) => EmitOp(5, SpvOpCode.OpVectorExtractDynamic, resultType, result, vec, index);
    public void EmitOpVectorInsertDynamic(id resultType, id result, id vec, id component, id index) => EmitOp(6, SpvOpCode.OpVectorInsertDynamic, resultType, result, vec, component, index);
    
    public void EmitOpVectorShuffle(id resultType, id result, id vec1, id vec2, uint[] components) {
        EmitOp((ushort)(5 + components.Length), SpvOpCode.OpVectorShuffle, resultType, result, vec1, vec2);
        Emit(components);
    }
    
    public void EmitOpCompositeConstruct(id resultType, id result, id[] constituents) {
        EmitOp((ushort)(3 + constituents.Length), SpvOpCode.OpCompositeConstruct, resultType, result);
        Emit(constituents);
    }
    
    public void EmitOpCompositeExtract(id resultType, id result, id composite, id[] indexes) {
        EmitOp((ushort)(4 + indexes.Length), SpvOpCode.OpCompositeExtract, resultType, result, composite);
        Emit(indexes);
    }

    public void EmitOpCompositeInsert(id resultType, id result, id obj, id composite, id[] indexes) {
        EmitOp((ushort)(5 + indexes.Length), SpvOpCode.OpCompositeInsert, resultType, result, obj, composite);
        Emit(indexes);
    }
    
    public void EmitOpCopyObject(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpCopyObject, resultType, result, op1);
    public void EmitOpTranspose(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpTranspose, resultType, result, op1);
    
    public void EmitOpSNegate(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpSNegate, resultType, result, op1);
    public void EmitOpFNegate(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpFNegate, resultType, result, op1);
    
    public void EmitOpIAdd(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpIAdd, resultType, result, op1, op2);
    public void EmitOpFAdd(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFAdd, resultType, result, op1, op2);
    
    public void EmitOpISub(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpISub, resultType, result, op1, op2);
    public void EmitOpFSub(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFSub, resultType, result, op1, op2);
    
    public void EmitOpIMul(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpIMul, resultType, result, op1, op2);
    public void EmitOpFMul(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFMul, resultType, result, op1, op2);
    
    public void EmitOpUDiv(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUDiv, resultType, result, op1, op2);
    public void EmitOpSDiv(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSDiv, resultType, result, op1, op2);
    public void EmitOpFDiv(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFDiv, resultType, result, op1, op2);
    
    public void EmitOpUMod(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUMod, resultType, result, op1, op2);
    public void EmitOpSMod(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSMod, resultType, result, op1, op2);
    public void EmitOpFMod(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFMod, resultType, result, op1, op2);
    public void EmitOpSRem(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSRem, resultType, result, op1, op2);
    public void EmitOpFRem(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFRem, resultType, result, op1, op2);
    
    public void EmitOpVectorTimesScalar(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpVectorTimesScalar, resultType, result, op1, op2);
    public void EmitOpMatrixTimesScalar(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpMatrixTimesScalar, resultType, result, op1, op2);
    public void EmitOpVectorTimesMatrix(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpVectorTimesMatrix, resultType, result, op1, op2);
    public void EmitOpMatrixTimesVector(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpMatrixTimesVector, resultType, result, op1, op2);
    public void EmitOpMatrixTimesMatrix(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpMatrixTimesMatrix, resultType, result, op1, op2);
    
    public void EmitOpOuterProduct(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpOuterProduct, resultType, result, op1, op2);
    public void EmitOpDot(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpDot, resultType, result, op1, op2);
    
    public void EmitOpIAddCarry(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpIAddCarry, resultType, result, op1, op2);
    public void EmitOpISubBorrow(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpISubBorrow, resultType, result, op1, op2);
    
    public void EmitOpUMulExtended(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUMulExtended, resultType, result, op1, op2);
    public void EmitOpSMulExtended(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSMulExtended, resultType, result, op1, op2);
    
    public void EmitOpShiftRightLogical(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpShiftRightLogical, resultType, result, op1, op2);
    public void EmitOpShiftRightArithmetic(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpShiftRightArithmetic, resultType, result, op1, op2);
    public void EmitOpShiftLeftLogical(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpShiftLeftLogical, resultType, result, op1, op2);
    
    public void EmitOpBitwiseOr(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpBitwiseOr, resultType, result, op1, op2);
    public void EmitOpBitwiseXor(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpBitwiseXor, resultType, result, op1, op2);
    public void EmitOpBitwiseAnd(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpBitwiseAnd, resultType, result, op1, op2);
    public void EmitOpNot(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpNot, resultType, result, op1);
    
    public void EmitOpBitFieldInsert(id resultType, id result, id @base, id insert, id offset, id count) => EmitOp(7, SpvOpCode.OpBitFieldInsert, resultType, result, @base, insert, offset, count);
    public void EmitOpBitFieldSExtract(id resultType, id result, id @base, id offset, id count) => EmitOp(6, SpvOpCode.OpBitFieldSExtract, resultType, result, @base, offset, count);
    public void EmitOpBitFieldUExtract(id resultType, id result, id @base, id offset, id count) => EmitOp(6, SpvOpCode.OpBitFieldUExtract, resultType, result, @base, offset, count);
    
    public void EmitOpBitReverse(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpBitReverse, resultType, result, op1);
    public void EmitOpBitCount(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpBitCount, resultType, result, op1);
    
    public void EmitOpAny(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpAny, resultType, result, op1);
    public void EmitOpAll(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpAll, resultType, result, op1);
    
    public void EmitOpIsNan(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpIsNan, resultType, result, op1);
    public void EmitOpIsInf(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpIsInf, resultType, result, op1);
    public void EmitOpIsFinite(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpIsFinite, resultType, result, op1);
    public void EmitOpIsNormal(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpIsNormal, resultType, result, op1);
    public void EmitOpSignBitSet(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpSignBitSet, resultType, result, op1);
    
    public void EmitOpLessOrGreater(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpLessOrGreater, resultType, result, op1, op2);
    public void EmitOpOrdered(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpOrdered, resultType, result, op1, op2);
    public void EmitOpUnordered(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUnordered, resultType, result, op1, op2);
    
    public void EmitOpLogicalEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpLogicalEqual, resultType, result, op1, op2);
    public void EmitOpLogicalNotEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpLogicalNotEqual, resultType, result, op1, op2);
    public void EmitOpLogicalOr(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpLogicalOr, resultType, result, op1, op2);
    public void EmitOpLogicalAnd(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpLogicalAnd, resultType, result, op1, op2);
    public void EmitOpLogicalNot(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpLogicalNot, resultType, result, op1);
    
    public void EmitOpSelect(id resultType, id result, id condition, id op1, id op2) => EmitOp(6, SpvOpCode.OpSelect, resultType, result, condition, op1, op2);
    
    
    public void EmitOpIEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpIEqual, resultType, result, op1, op2);
    public void EmitOpINotEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpINotEqual, resultType, result, op1, op2);
    public void EmitOpUGreaterThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUGreaterThan, resultType, result, op1, op2);
    public void EmitOpSGreaterThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSGreaterThan, resultType, result, op1, op2);
    public void EmitOpUGreaterThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpUGreaterThanEqual, resultType, result, op1, op2);
    public void EmitOpSGreaterThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSGreaterThanEqual, resultType, result, op1, op2);
    public void EmitOpULessThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpULessThan, resultType, result, op1, op2);
    public void EmitOpSLessThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSLessThan, resultType, result, op1, op2);
    public void EmitOpULessThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpULessThanEqual, resultType, result, op1, op2);
    public void EmitOpSLessThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpSLessThanEqual, resultType, result, op1, op2);
    public void EmitOpFOrdEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdEqual, resultType, result, op1, op2);
    public void EmitOpFUnordEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordEqual, resultType, result, op1, op2);
    public void EmitOpFOrdNotEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdNotEqual, resultType, result, op1, op2);
    public void EmitOpFUnordNotEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordNotEqual, resultType, result, op1, op2);
    public void EmitOpFOrdLessThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdLessThan, resultType, result, op1, op2);
    public void EmitOpFUnordLessThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordLessThan, resultType, result, op1, op2);
    public void EmitOpFOrdGreaterThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdGreaterThan, resultType, result, op1, op2);
    public void EmitOpFUnordGreaterThan(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordGreaterThan, resultType, result, op1, op2);
    public void EmitOpFOrdLessThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdLessThanEqual, resultType, result, op1, op2);
    public void EmitOpFUnordLessThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordLessThanEqual, resultType, result, op1, op2);
    public void EmitOpFOrdGreaterThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFOrdGreaterThanEqual, resultType, result, op1, op2);
    public void EmitOpFUnordGreaterThanEqual(id resultType, id result, id op1, id op2) => EmitOp(5, SpvOpCode.OpFUnordGreaterThanEqual, resultType, result, op1, op2);
    
    public void EmitOpDPdx(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdx, resultType, result, op1);
    public void EmitOpDPdy(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdy, resultType, result, op1);
    public void EmitOpFwidth(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpFwidth, resultType, result, op1);
    public void EmitOpDPdxFine(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdxFine, resultType, result, op1);
    public void EmitOpDPdyFine(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdyFine, resultType, result, op1);
    public void EmitOpFwidthFine(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpFwidthFine, resultType, result, op1);
    public void EmitOpDPdxCoarse(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdxCoarse, resultType, result, op1);
    public void EmitOpDPdyCoarse(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpDPdyCoarse, resultType, result, op1);
    public void EmitOpFwidthCoarse(id resultType, id result, id op1) => EmitOp(4, SpvOpCode.OpFwidthCoarse, resultType, result, op1);

    public void EmitOpPhi(id resultType, id result, (id variable, id parent)[] parts) {
        EmitOp((ushort)(3 + parts.Length * 2), SpvOpCode.OpPhi, resultType, result);
        foreach ((uint variable, uint parent) in parts) Emit(variable, parent);
    }
    
    public void EmitOpLoopMerge(id mergeBlock, id continueTarget, SpvLoopControlMask loopControl) => EmitOp(4, SpvOpCode.OpLoopMerge, mergeBlock, continueTarget, (uint) loopControl);
    public void EmitOpSelectionMerge(id mergeBlock, SpvSelectionControlMask selectionControl) => EmitOp(3, SpvOpCode.OpSelectionMerge, mergeBlock, (uint) selectionControl);
    
    public void EmitOpAtomicLoad(id resultType, id result, id ptr, id scope, id semantics) => EmitOp(6, SpvOpCode.OpAtomicLoad, resultType, result, ptr, scope, semantics);
    public void EmitOpAtomicStore(id ptr, id scope, id semantics, id val) => EmitOp(5, SpvOpCode.OpAtomicStore, ptr, scope, semantics, val);
    
    public void EmitOpAtomicExchange(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicExchange, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicCompareExchange(id resultType, id result, id ptr, id scope, id eq, id uneq, id val, id comparator) => EmitOp(9, SpvOpCode.OpAtomicCompareExchange, resultType, result, ptr, scope, eq, uneq, val, comparator);
    public void EmitOpAtomicCompareExchangeWeak(id resultType, id result, id ptr, id scope, id eq, id uneq, id val, id comparator) => EmitOp(9, SpvOpCode.OpAtomicCompareExchangeWeak, resultType, result, ptr, scope, eq, uneq, val, comparator);
    
    public void EmitOpAtomicIIncrement(id resultType, id result, id ptr, id scope, id semantics) => EmitOp(6, SpvOpCode.OpAtomicIIncrement, resultType, result, ptr, scope, semantics);
    public void EmitOpAtomicIDecrement(id resultType, id result, id ptr, id scope, id semantics) => EmitOp(6, SpvOpCode.OpAtomicIDecrement, resultType, result, ptr, scope, semantics);
    public void EmitOpAtomicIAdd(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicIAdd, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicISub(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicISub, resultType, result, ptr, scope, semantics, val);
    
    public void EmitOpAtomicSMin(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicSMin, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicUMin(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicUMin, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicSMax(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicSMax, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicUMax(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicUMax, resultType, result, ptr, scope, semantics, val);
    
    public void EmitOpAtomicAnd(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicAnd, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicOr(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicOr, resultType, result, ptr, scope, semantics, val);
    public void EmitOpAtomicXor(id resultType, id result, id ptr, id scope, id semantics, id val) => EmitOp(7, SpvOpCode.OpAtomicXor, resultType, result, ptr, scope, semantics, val);
    
    public void EmitOpAtomicFlagTestAndSet(id resultType, id result, id ptr, id scope, id semantics) => EmitOp(6, SpvOpCode.OpAtomicFlagTestAndSet, resultType, result, ptr, scope, semantics);
    public void EmitOpAtomicFlagClear(id ptr, id scope, id semantics) => EmitOp(4, SpvOpCode.OpAtomicFlagClear, ptr, scope, semantics);
    
    public void EmitOpEmitVertex() => EmitOp(1, SpvOpCode.OpEmitVertex);
    public void EmitOpEndPrimitive() => EmitOp(1, SpvOpCode.OpEndPrimitive);
    public void EmitOpEmitStreamVertex(id stream) => EmitOp(2, SpvOpCode.OpEmitStreamVertex, stream);
    public void EmitOpEndStreamPrimitive(id stream) => EmitOp(2, SpvOpCode.OpEndStreamPrimitive, stream);
    
    public void EmitOpControlBarrier(id execution, id mem, id semantics) => EmitOp(4, SpvOpCode.OpControlBarrier, execution, mem, semantics);
    public void EmitOpMemoryBarrier(id mem, id semantics) => EmitOp(3, SpvOpCode.OpMemoryBarrier, mem, semantics);
    
    public void EmitOpGroupAsyncCopy(id resultType, id result, id execution, id dest, id src, id numElements, id stride, id @event) => EmitOp(9, SpvOpCode.OpGroupAsyncCopy, resultType, result, execution, dest, src, numElements, stride, @event);
    
    public void EmitOpGroupWaitEvents(id execution, id numEvents, id eventsList) => EmitOp(4, SpvOpCode.OpGroupWaitEvents, execution, numEvents, eventsList);
    public void EmitOpGroupAll(id resultType, id result, id execution, id predicate) => EmitOp(5, SpvOpCode.OpGroupAll, resultType, result, execution, predicate);
    public void EmitOpGroupAny(id resultType, id result, id execution, id predicate) => EmitOp(5, SpvOpCode.OpGroupAny, resultType, result, execution, predicate);
    public void EmitOpGroupBroadcast(id resultType, id result, id execution, id val, id localId) => EmitOp(6, SpvOpCode.OpGroupBroadcast, resultType, result, execution, val, localId);
    
    public void EmitOpGroupIAdd(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupIAdd, resultType, result, execution, operation, op1);
    public void EmitOpGroupFAdd(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupFAdd, resultType, result, execution, operation, op1);
    public void EmitOpGroupFMin(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupFMin, resultType, result, execution, operation, op1);
    public void EmitOpGroupUMin(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupUMin, resultType, result, execution, operation, op1);
    public void EmitOpGroupSMin(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupSMin, resultType, result, execution, operation, op1);
    public void EmitOpGroupFMax(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupFMax, resultType, result, execution, operation, op1);
    public void EmitOpGroupUMax(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupUMax, resultType, result, execution, operation, op1);
    public void EmitOpGroupSMax(id resultType, id result, id execution, id operation, id op1) => EmitOp(6, SpvOpCode.OpGroupSMax, resultType, result, execution, operation, op1);
    
}