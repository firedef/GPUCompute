using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.emit.enums.extensions;
using id = System.UInt32;

// ReSharper disable BuiltInTypeReferenceStyle

namespace GPUCompute.spirv.gen.instructions;

public partial class SpvOp {
    public static class Unified {
        public readonly record struct OpNop : ISpvInstruction {
            public void Emit(SpirVEmitter code) => code.EmitOpNop();
        }

        public readonly record struct OpUndef(id resultType, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUndef(resultType, result);
        }

        public readonly record struct OpSource(SpvSourceLanguage lang, uint version) : ISpvInstruction {
            public readonly SpvSourceLanguage lang = lang;
            public readonly uint version = version;
            public void Emit(SpirVEmitter code) => code.EmitOpSource(lang, version);
        }

        public readonly record struct OpSourceExtension(string ext) : ISpvInstruction {
            public readonly string ext = ext;
            public void Emit(SpirVEmitter code) => code.EmitOpSourceExtension(ext);
        }

        public readonly record struct OpName(id id, string name) : ISpvInstruction {
            public readonly id id = id;
            public readonly string name = name;
            public void Emit(SpirVEmitter code) => code.EmitOpName(id, name);
        }

        public readonly record struct OpMemberName(id id, id member, string name) : ISpvInstruction {
            public readonly id id = id;
            public readonly id member = member;
            public readonly string name = name;
            public void Emit(SpirVEmitter code) => code.EmitOpMemberName(id, member, name);
        }

        public readonly record struct OpDecorate(id target, SpvDecoration decoration, params uint[] literals) : ISpvInstruction {
            public readonly SpvDecoration decoration = decoration;
            public readonly uint[] literals = literals;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpDecorate(target, decoration, literals);
        }

        public readonly record struct OpDecorateBuiltIn(id target, SpvBuiltIn builtIn) : ISpvInstruction {
            public readonly SpvBuiltIn builtIn = builtIn;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpDecorateBuiltIn(target, builtIn);
        }

        public readonly record struct OpMemberDecorate
            (id structureType, id member, SpvDecoration decoration, params uint[] literals) : ISpvInstruction {
            public readonly SpvDecoration decoration = decoration;
            public readonly uint[] literals = literals;
            public readonly id member = member;
            public readonly id structureType = structureType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpMemberDecorate(structureType, member, decoration, literals);
        }

        public readonly record struct OpDecorationGroup(id result) : ISpvInstruction {
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpDecorationGroup(result);
        }

        public readonly record struct OpGroupDecorate(id group, id[] targets) : ISpvInstruction {
            public readonly id group = group;
            public readonly id[] targets = targets;
            public void Emit(SpirVEmitter code) => code.EmitOpGroupDecorate(group, targets);
        }

        public readonly record struct OpGroupMemberDecorate(id group, (id id, uint literal)[] args) : ISpvInstruction {
            public readonly (id id, uint literal)[] args = args;
            public readonly id group = group;
            public void Emit(SpirVEmitter code) => code.EmitOpGroupMemberDecorate(group, args);
        }

        public readonly record struct OpExtension(id id, string ext) : ISpvInstruction {
            public readonly string ext = ext;
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpExtension(id, ext);
        }

        public readonly record struct OpExtInstImport(id id, string ext) : ISpvInstruction {
            public readonly string ext = ext;
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInstImport(id, ext);
        }

        public readonly record struct OpMemoryModel(SpvAddressingModel model, id id) : ISpvInstruction {
            public readonly id id = id;
            public readonly SpvAddressingModel model = model;
            public void Emit(SpirVEmitter code) => code.EmitOpMemoryModel(model, id);
        }

        public readonly record struct OpEntryPoint
            (SpvExecutionModel executionModel, id entryPoint, string name, params id[] interfaces) : ISpvInstruction {
            public readonly id entryPoint = entryPoint;
            public readonly SpvExecutionModel executionModel = executionModel;
            public readonly id[] interfaces = interfaces;
            public readonly string name = name;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpEntryPoint(executionModel, entryPoint, name, interfaces);
        }

        public readonly record struct OpExecutionMode(id id, SpvExecutionMode mode, uint x, uint y, uint z) : ISpvInstruction {
            public readonly id id = id;
            public readonly SpvExecutionMode mode = mode;
            public readonly uint x = x;
            public readonly uint y = y;
            public readonly uint z = z;
            public void Emit(SpirVEmitter code) => code.EmitOpExecutionMode(id, mode, x, y, z);
        }

        public readonly record struct OpCapability(SpvCapability capability) : ISpvInstruction {
            public readonly SpvCapability capability = capability;
            public void Emit(SpirVEmitter code) => code.EmitOpCapability(capability);
        }

        public readonly record struct OpType(SpvOpCode type, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly SpvOpCode type = type;
            public void Emit(SpirVEmitter code) => code.EmitOpType(type, result);
        }

        public readonly record struct OpTypeVoid(id result) : ISpvInstruction {
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeVoid(result);
        }

        public readonly record struct OpTypeBool(id result) : ISpvInstruction {
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeBool(result);
        }

        public readonly record struct OpTypeFloat(id result, uint width) : ISpvInstruction {
            public readonly id result = result;
            public readonly uint width = width;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeFloat(result, width);
        }

        public readonly record struct OpTypeInt(id result, uint width, uint signedness) : ISpvInstruction {
            public readonly id result = result;
            public readonly uint signedness = signedness;
            public readonly uint width = width;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeInt(result, width, signedness);
        }

        public readonly record struct OpTypeVector(id result, id componentType, uint length) : ISpvInstruction {
            public readonly id componentType = componentType;
            public readonly uint length = length;
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeVector(result, componentType, length);
        }

        public readonly record struct OpTypeMatrix(id result, id columnType, uint columnCount) : ISpvInstruction {
            public readonly uint columnCount = columnCount;
            public readonly id columnType = columnType;
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeMatrix(result, columnType, columnCount);
        }

        public readonly record struct OpTypeImage(id result, id sampledType, SpvDimension dim, uint depth, uint arrayed, uint multisample,
            uint sampled, SpvImageFormat format) : ISpvInstruction {
            public readonly uint arrayed = arrayed;
            public readonly uint depth = depth;
            public readonly SpvDimension dim = dim;
            public readonly SpvImageFormat format = format;
            public readonly uint multisample = multisample;
            public readonly id result = result;
            public readonly uint sampled = sampled;
            public readonly id sampledType = sampledType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpTypeImage(result, sampledType, dim, depth, arrayed, multisample, sampled, format);
        }

        public readonly record struct OpTypeSampler(id result) : ISpvInstruction {
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeSampler(result);
        }

        public readonly record struct OpTypeSampledImage(id result, id imageType) : ISpvInstruction {
            public readonly id imageType = imageType;
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeSampledImage(result, imageType);
        }

        public readonly record struct OpTypeArray(id result, id elementType, uint length) : ISpvInstruction {
            public readonly id elementType = elementType;
            public readonly uint length = length;
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeArray(result, elementType, length);
        }

        public readonly record struct OpTypeRuntimeArray(id result, id elementType) : ISpvInstruction {
            public readonly id elementType = elementType;
            public readonly id result = result;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeRuntimeArray(result, elementType);
        }

        public readonly record struct OpTypeStruct(id id, params id[] memberTypes) : ISpvInstruction {
            public readonly id id = id;
            public readonly id[] memberTypes = memberTypes;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeStruct(id, memberTypes);
        }

        public readonly record struct OpTypePointer(id id, id storageClass, id type) : ISpvInstruction {
            public readonly id id = id;
            public readonly id storageClass = storageClass;
            public readonly id type = type;
            public void Emit(SpirVEmitter code) => code.EmitOpTypePointer(id, storageClass, type);
        }

        public readonly record struct OpTypeFunction(id id, id returnType, params id[] parameters) : ISpvInstruction {
            public readonly id id = id;
            public readonly id[] parameters = parameters;
            public readonly id returnType = returnType;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeFunction(id, returnType, parameters);
        }

        public readonly record struct OpTypeEvent(id id) : ISpvInstruction {
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeEvent(id);
        }

        public readonly record struct OpTypeDeviceEvent(id id) : ISpvInstruction {
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeDeviceEvent(id);
        }

        public readonly record struct OpTypeReserveId(id id) : ISpvInstruction {
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeReserveId(id);
        }

        public readonly record struct OpTypeQueue(id id) : ISpvInstruction {
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeQueue(id);
        }

        public readonly record struct OpTypePipe(id id, SpvAccessQualifier access) : ISpvInstruction {
            public readonly SpvAccessQualifier access = access;
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpTypePipe(id, access);
        }

        public readonly record struct OpTypeForwardPointer(uint id, uint storageClass) : ISpvInstruction {
            public readonly uint id = id;
            public readonly uint storageClass = storageClass;
            public void Emit(SpirVEmitter code) => code.EmitOpTypeForwardPointer(id, storageClass);
        }

        public readonly record struct OpConstantTrue(id resultType, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpConstantTrue(resultType, result);
        }

        public readonly record struct OpConstantFalse(id resultType, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpConstantFalse(resultType, result);
        }

        public readonly record struct OpConstantNull(id resultType, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpConstantNull(resultType, result);
        }

        public readonly record struct OpConstant<T>(id type, id id, T v) : ISpvInstruction where T : unmanaged {
            public readonly id id = id;
            public readonly id type = type;
            public readonly T v = v;
            public void Emit(SpirVEmitter code) => code.EmitOpConstant(type, id, v);
        }

        public readonly record struct OpConstant2(id type, id id, uint[] v) : ISpvInstruction {
            public readonly id id = id;
            public readonly id type = type;
            public readonly uint[] v = v;
            public void Emit(SpirVEmitter code) => code.EmitOpConstant(type, id, v);
        }

        public readonly record struct OpConstantComposite(id resultType, id result, params id[] constituents) : ISpvInstruction {
            public readonly id[] constituents = constituents;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpConstantComposite(resultType, result, constituents);
        }

        public readonly record struct OpBranch(id target) : ISpvInstruction {
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpBranch(target);
        }

        public readonly record struct OpBranchConditional(id condition, id ifTrue, id ifFalse) : ISpvInstruction {
            public readonly id condition = condition;
            public readonly id ifFalse = ifFalse;
            public readonly id ifTrue = ifTrue;
            public void Emit(SpirVEmitter code) => code.EmitOpBranchConditional(condition, ifTrue, ifFalse);
        }

        public readonly record struct OpBranchConditional2
            (id condition, id ifTrue, id ifFalse, uint weightTrue, uint weightFalse) : ISpvInstruction {
            public readonly id condition = condition;
            public readonly id ifFalse = ifFalse;
            public readonly id ifTrue = ifTrue;
            public readonly uint weightFalse = weightFalse;
            public readonly uint weightTrue = weightTrue;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpBranchConditional(condition, ifTrue, ifFalse, weightTrue, weightFalse);
        }

        public readonly record struct OpSwitch(id selector, id ifDefault, (uint literal, id label)[] elements) : ISpvInstruction {
            public readonly (uint literal, id label)[] elements = elements;
            public readonly id ifDefault = ifDefault;
            public readonly id selector = selector;
            public void Emit(SpirVEmitter code) => code.EmitOpSwitch(selector, ifDefault, elements);
        }

        public readonly record struct OpLabel(id id) : ISpvInstruction {
            public readonly id id = id;
            public void Emit(SpirVEmitter code) => code.EmitOpLabel(id);
        }

        public readonly record struct OpReturn : ISpvInstruction {
            public void Emit(SpirVEmitter code) => code.EmitOpReturn();
        }

        public readonly record struct OpReturnValue(id value) : ISpvInstruction {
            public readonly id value = value;
            public void Emit(SpirVEmitter code) => code.EmitOpReturnValue(value);
        }

        public readonly record struct OpExtInst
            (id resultType, id result, id instructionSet, uint instruction, params id[] operands) : ISpvInstruction {
            public readonly uint instruction = instruction;
            public readonly id instructionSet = instructionSet;
            public readonly id[] operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, instruction, operands);
        }

        public readonly record struct OpVariable(id resultType, id result, SpvStorageClass storageClass) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly SpvStorageClass storageClass = storageClass;
            public void Emit(SpirVEmitter code) => code.EmitOpVariable(resultType, result, storageClass);
        }

        public readonly record struct OpVariable2(id resultType, id result, id storageClass, id access) : ISpvInstruction {
            public readonly id access = access;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id storageClass = storageClass;
            public void Emit(SpirVEmitter code) => code.EmitOpVariable(resultType, result, storageClass, access);
        }

        public readonly record struct OpImageTexelPointer(id resultType, id result, id img, id coordinate, id sample) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id sample = sample;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageTexelPointer(resultType, result, img, coordinate, sample);
        }

        public readonly record struct OpLoad(id resultType, id result, id pointer) : ISpvInstruction {
            public readonly id pointer = pointer;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLoad(resultType, result, pointer);
        }

        public readonly record struct OpLoad2(id resultType, id result, id pointer, id access) : ISpvInstruction {
            public readonly id access = access;
            public readonly id pointer = pointer;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLoad(resultType, result, pointer, access);
        }

        public readonly record struct OpStore(id pointer, id obj) : ISpvInstruction {
            public readonly id obj = obj;
            public readonly id pointer = pointer;
            public void Emit(SpirVEmitter code) => code.EmitOpStore(pointer, obj);
        }

        public readonly record struct OpStore2(id pointer, id obj, id access) : ISpvInstruction {
            public readonly id access = access;
            public readonly id obj = obj;
            public readonly id pointer = pointer;
            public void Emit(SpirVEmitter code) => code.EmitOpStore(pointer, obj, access);
        }

        public readonly record struct OpCopyMemory(id target, id src) : ISpvInstruction {
            public readonly id src = src;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpCopyMemory(target, src);
        }

        public readonly record struct OpCopyMemory2(id target, id src, SpvMemoryAccessMask access) : ISpvInstruction {
            public readonly SpvMemoryAccessMask access = access;
            public readonly id src = src;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpCopyMemory(target, src, access);
        }

        public readonly record struct OpCopyMemorySized(id target, id src, id size) : ISpvInstruction {
            public readonly id size = size;
            public readonly id src = src;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpCopyMemorySized(target, src, size);
        }

        public readonly record struct OpCopyMemorySized2(id target, id src, id size, SpvMemoryAccessMask access) : ISpvInstruction {
            public readonly SpvMemoryAccessMask access = access;
            public readonly id size = size;
            public readonly id src = src;
            public readonly id target = target;
            public void Emit(SpirVEmitter code) => code.EmitOpCopyMemorySized(target, src, size, access);
        }

        public readonly record struct OpAccessChain(id resultType, id result, id baseid, params id[] indexes) : ISpvInstruction {
            public readonly id baseid = baseid;
            public readonly id[] indexes = indexes;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpAccessChain(resultType, result, baseid, indexes);
        }

        public readonly record struct OpInBoundsAccessChain(id resultType, id result, id baseid, params id[] indexes) : ISpvInstruction {
            public readonly id baseid = baseid;
            public readonly id[] indexes = indexes;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpInBoundsAccessChain(resultType, result, baseid, indexes);
        }

        public readonly record struct OpPtrAccessChain
            (id resultType, id result, id baseid, id element, params id[] indexes) : ISpvInstruction {
            public readonly id baseid = baseid;
            public readonly id element = element;
            public readonly id[] indexes = indexes;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpPtrAccessChain(resultType, result, baseid, element, indexes);
        }

        public readonly record struct OpArrayLength(id resultType, id result, id structure, uint arrayMem) : ISpvInstruction {
            public readonly uint arrayMem = arrayMem;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id structure = structure;
            public void Emit(SpirVEmitter code) => code.EmitOpArrayLength(resultType, result, structure, arrayMem);
        }

        public readonly record struct OpGenericPtrMemSemantics(id resultType, id result, id ptr) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpGenericPtrMemSemantics(resultType, result, ptr);
        }

        public readonly record struct OpInBoundsPtrAccessChain
            (id resultType, id result, id baseid, id element, id[] indexes) : ISpvInstruction {
            public readonly id baseid = baseid;
            public readonly id element = element;
            public readonly id[] indexes = indexes;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpInBoundsPtrAccessChain(resultType, result, baseid, element, indexes);
        }

        public readonly record struct OpFunction
            (id resultType, id result, SpvFunctionControlMask control, id functionType) : ISpvInstruction {
            public readonly SpvFunctionControlMask control = control;
            public readonly id functionType = functionType;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFunction(resultType, result, control, functionType);
        }

        public readonly record struct OpFunctionParameter(id resultType, id result) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFunctionParameter(resultType, result);
        }

        public readonly record struct OpFunctionEnd : ISpvInstruction {
            public void Emit(SpirVEmitter code) => code.EmitOpFunctionEnd();
        }

        public readonly record struct OpFunctionCall(id resultType, id result, id func, id[] args) : ISpvInstruction {
            public readonly id[] args = args;
            public readonly id func = func;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFunctionCall(resultType, result, func, args);
        }

        public readonly record struct OpSampledImage(id resultType, id result, id img, id sampler) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id sampler = sampler;
            public void Emit(SpirVEmitter code) => code.EmitOpSampledImage(resultType, result, img, sampler);
        }

        public readonly record struct OpImageSampleImplicitLod(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleImplicitLod(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageSampleImplicitLod2(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleImplicitLod(resultType, result, img, coordinate, operands, ids);
        }

        public readonly record struct OpImageSampleExplicitLod(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id id) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id id = id;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleExplicitLod(resultType, result, img, coordinate, operands, id);
        }

        public readonly record struct OpImageSampleExplicitLod2(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id id, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id id = id;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleExplicitLod(resultType, result, img, coordinate, operands, id, ids);
        }

        public readonly record struct OpImageSampleDrefImplicitLod
            (id resultType, id result, id img, id coordinate, id dref) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleDrefImplicitLod(resultType, result, img, coordinate, dref);
        }

        public readonly record struct OpImageSampleDrefImplicitLod2(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleDrefImplicitLod(resultType, result, img, coordinate, dref, operands, ids);
        }

        public readonly record struct OpImageSampleDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id id) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id id = id;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleDrefExplicitLod(resultType, result, img, coordinate, dref, operands, id);
        }

        public readonly record struct OpImageSampleDrefExplicitLod2(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id id, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id id = id;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleDrefExplicitLod(resultType, result, img, coordinate, dref, operands, id, ids);
        }

        public readonly record struct OpImageSampleProjImplicitLod(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjImplicitLod(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageSampleProjImplicitLod2(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjImplicitLod(resultType, result, img, coordinate, operands, ids);
        }

        public readonly record struct OpImageSampleProjExplicitLod(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id id) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id id = id;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjExplicitLod(resultType, result, img, coordinate, operands, id);
        }

        public readonly record struct OpImageSampleProjExplicitLod2(id resultType, id result, id img, id coordinate,
            SpvImageOperandsMask operands, id id, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id id = id;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjExplicitLod(resultType, result, img, coordinate, operands, id, ids);
        }

        public readonly record struct OpImageSampleProjDrefImplicitLod
            (id resultType, id result, id img, id coordinate, id dref) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjDrefImplicitLod(resultType, result, img, coordinate, dref);
        }

        public readonly record struct OpImageSampleProjDrefImplicitLod2(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjDrefImplicitLod(resultType, result, img, coordinate, dref, operands, ids);
        }

        public readonly record struct OpImageSampleProjDrefExplicitLod(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id id) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id id = id;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjDrefExplicitLod(resultType, result, img, coordinate, dref, operands, id);
        }

        public readonly record struct OpImageSampleProjDrefExplicitLod2(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id id, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id id = id;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSampleProjDrefExplicitLod(resultType, result, img, coordinate, dref, operands, id, ids);
        }

        public readonly record struct OpImageFetch(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageFetch(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageFetch2(id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands,
            id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageFetch(resultType, result, img, coordinate, operands, ids);
        }

        public readonly record struct OpImageGather(id resultType, id result, id img, id coordinate, id component) : ISpvInstruction {
            public readonly id component = component;
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageGather(resultType, result, img, coordinate, component);
        }

        public readonly record struct OpImageGather2(id resultType, id result, id img, id coordinate, id component,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id component = component;
            public readonly id coordinate = coordinate;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageGather(resultType, result, img, coordinate, component, operands, ids);
        }

        public readonly record struct OpImageDrefGather(id resultType, id result, id img, id coordinate, id dref) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageDrefGather(resultType, result, img, coordinate, dref);
        }

        public readonly record struct OpImageDrefGather2(id resultType, id result, id img, id coordinate, id dref,
            SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id dref = dref;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageDrefGather(resultType, result, img, coordinate, dref, operands, ids);
        }

        public readonly record struct OpImageRead(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageRead(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageRead2
            (id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageRead(resultType, result, img, coordinate, operands, ids);
        }

        public readonly record struct OpImageWrite(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageWrite(resultType, result, img);
        }

        public readonly record struct OpImageWrite2
            (id resultType, id result, id img, SpvImageOperandsMask operands, id[] ids) : ISpvInstruction {
            public readonly id[] ids = ids;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageWrite(resultType, result, img, operands, ids);
        }

        public readonly record struct OpImage(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImage(resultType, result, img);
        }

        public readonly record struct OpImageQueryFormat(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQueryFormat(resultType, result, img);
        }

        public readonly record struct OpImageQueryOrder(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQueryOrder(resultType, result, img);
        }

        public readonly record struct OpImageQuerySizeLod(id resultType, id result, id img, id lod) : ISpvInstruction {
            public readonly id img = img;
            public readonly id lod = lod;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQuerySizeLod(resultType, result, img, lod);
        }

        public readonly record struct OpImageQuerySize(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQuerySize(resultType, result, img);
        }

        public readonly record struct OpImageQueryLod(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQueryLod(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageQueryLevels(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQueryLevels(resultType, result, img);
        }

        public readonly record struct OpImageQuerySamples(id resultType, id result, id img) : ISpvInstruction {
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageQuerySamples(resultType, result, img);
        }

        public readonly record struct OpImageSparseTexelsResident(id resultType, id result, id code_) : ISpvInstruction {
            public readonly id code_ = code_;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageSparseTexelsResident(resultType, result, code_);
        }

        public readonly record struct OpImageSparseRead(id resultType, id result, id img, id coordinate) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpImageSparseRead(resultType, result, img, coordinate);
        }

        public readonly record struct OpImageSparseRead2
            (id resultType, id result, id img, id coordinate, SpvImageOperandsMask operands) : ISpvInstruction {
            public readonly id coordinate = coordinate;
            public readonly id img = img;
            public readonly SpvImageOperandsMask operands = operands;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpImageSparseRead(resultType, result, img, coordinate, operands);
        }

        public readonly record struct OpConvertFToU(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertFToU(resultType, result, val);
        }

        public readonly record struct OpConvertFToS(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertFToS(resultType, result, val);
        }

        public readonly record struct OpConvertSToF(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertSToF(resultType, result, val);
        }

        public readonly record struct OpConvertUToF(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertUToF(resultType, result, val);
        }

        public readonly record struct OpUConvert(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpUConvert(resultType, result, val);
        }

        public readonly record struct OpSConvert(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpSConvert(resultType, result, val);
        }

        public readonly record struct OpFConvert(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpFConvert(resultType, result, val);
        }

        public readonly record struct OpQuantizeToF16(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpQuantizeToF16(resultType, result, val);
        }

        public readonly record struct OpConvertPtrToU(id resultType, id result, id ptr) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertPtrToU(resultType, result, ptr);
        }

        public readonly record struct OpSatConvertSToU(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpSatConvertSToU(resultType, result, val);
        }

        public readonly record struct OpSatConvertUToS(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpSatConvertUToS(resultType, result, val);
        }

        public readonly record struct OpConvertUToPtr(id resultType, id result, id val) : ISpvInstruction {
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpConvertUToPtr(resultType, result, val);
        }

        public readonly record struct OpPtrCastToGeneric(id resultType, id result, id ptr) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpPtrCastToGeneric(resultType, result, ptr);
        }

        public readonly record struct OpGenericCastToPtr(id resultType, id result, id ptr) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpGenericCastToPtr(resultType, result, ptr);
        }

        public readonly record struct OpGenericCastToPtrExplicit(id resultType, id result, id ptr, id storage) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id storage = storage;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGenericCastToPtrExplicit(resultType, result, ptr, storage);
        }

        public readonly record struct OpBitcast(id resultType, id result, id operand) : ISpvInstruction {
            public readonly id operand = operand;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitcast(resultType, result, operand);
        }

        public readonly record struct OpVectorExtractDynamic(id resultType, id result, id vec, id index) : ISpvInstruction {
            public readonly id index = index;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id vec = vec;
            public void Emit(SpirVEmitter code) => code.EmitOpVectorExtractDynamic(resultType, result, vec, index);
        }

        public readonly record struct OpVectorInsertDynamic(id resultType, id result, id vec, id component, id index) : ISpvInstruction {
            public readonly id component = component;
            public readonly id index = index;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id vec = vec;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpVectorInsertDynamic(resultType, result, vec, component, index);
        }

        public readonly record struct OpVectorShuffle(id resultType, id result, id vec1, id vec2, uint[] components) : ISpvInstruction {
            public readonly uint[] components = components;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id vec1 = vec1;
            public readonly id vec2 = vec2;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpVectorShuffle(resultType, result, vec1, vec2, components);
        }

        public readonly record struct OpCompositeConstruct(id resultType, id result, id[] constituents) : ISpvInstruction {
            public readonly id[] constituents = constituents;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpCompositeConstruct(resultType, result, constituents);
        }

        public readonly record struct OpCompositeExtract(id resultType, id result, id composite, id[] indexes) : ISpvInstruction {
            public readonly id composite = composite;
            public readonly id[] indexes = indexes;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpCompositeExtract(resultType, result, composite, indexes);
        }

        public readonly record struct OpCompositeInsert(id resultType, id result, id obj, id composite, id[] indexes) : ISpvInstruction {
            public readonly id composite = composite;
            public readonly id[] indexes = indexes;
            public readonly id obj = obj;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpCompositeInsert(resultType, result, obj, composite, indexes);
        }

        public readonly record struct OpCopyObject(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpCopyObject(resultType, result, op1);
        }

        public readonly record struct OpTranspose(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpTranspose(resultType, result, op1);
        }

        public readonly record struct OpSNegate(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSNegate(resultType, result, op1);
        }

        public readonly record struct OpFNegate(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFNegate(resultType, result, op1);
        }

        public readonly record struct OpIAdd(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIAdd(resultType, result, op1, op2);
        }

        public readonly record struct OpFAdd(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFAdd(resultType, result, op1, op2);
        }

        public readonly record struct OpISub(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpISub(resultType, result, op1, op2);
        }

        public readonly record struct OpFSub(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFSub(resultType, result, op1, op2);
        }

        public readonly record struct OpIMul(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIMul(resultType, result, op1, op2);
        }

        public readonly record struct OpFMul(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFMul(resultType, result, op1, op2);
        }

        public readonly record struct OpUDiv(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUDiv(resultType, result, op1, op2);
        }

        public readonly record struct OpSDiv(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSDiv(resultType, result, op1, op2);
        }

        public readonly record struct OpFDiv(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFDiv(resultType, result, op1, op2);
        }

        public readonly record struct OpUMod(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUMod(resultType, result, op1, op2);
        }

        public readonly record struct OpSMod(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSMod(resultType, result, op1, op2);
        }

        public readonly record struct OpFMod(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFMod(resultType, result, op1, op2);
        }

        public readonly record struct OpSRem(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSRem(resultType, result, op1, op2);
        }

        public readonly record struct OpFRem(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFRem(resultType, result, op1, op2);
        }

        public readonly record struct OpVectorTimesScalar(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpVectorTimesScalar(resultType, result, op1, op2);
        }

        public readonly record struct OpMatrixTimesScalar(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpMatrixTimesScalar(resultType, result, op1, op2);
        }

        public readonly record struct OpVectorTimesMatrix(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpVectorTimesMatrix(resultType, result, op1, op2);
        }

        public readonly record struct OpMatrixTimesVector(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpMatrixTimesVector(resultType, result, op1, op2);
        }

        public readonly record struct OpMatrixTimesMatrix(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpMatrixTimesMatrix(resultType, result, op1, op2);
        }

        public readonly record struct OpOuterProduct(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpOuterProduct(resultType, result, op1, op2);
        }

        public readonly record struct OpDot(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDot(resultType, result, op1, op2);
        }

        public readonly record struct OpIAddCarry(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIAddCarry(resultType, result, op1, op2);
        }

        public readonly record struct OpISubBorrow(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpISubBorrow(resultType, result, op1, op2);
        }

        public readonly record struct OpUMulExtended(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUMulExtended(resultType, result, op1, op2);
        }

        public readonly record struct OpSMulExtended(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSMulExtended(resultType, result, op1, op2);
        }

        public readonly record struct OpShiftRightLogical(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpShiftRightLogical(resultType, result, op1, op2);
        }

        public readonly record struct OpShiftRightArithmetic(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpShiftRightArithmetic(resultType, result, op1, op2);
        }

        public readonly record struct OpShiftLeftLogical(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpShiftLeftLogical(resultType, result, op1, op2);
        }

        public readonly record struct OpBitwiseOr(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitwiseOr(resultType, result, op1, op2);
        }

        public readonly record struct OpBitwiseXor(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitwiseXor(resultType, result, op1, op2);
        }

        public readonly record struct OpBitwiseAnd(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitwiseAnd(resultType, result, op1, op2);
        }

        public readonly record struct OpNot(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpNot(resultType, result, op1);
        }

        public readonly record struct OpBitFieldInsert
            (id resultType, id result, id @base, id insert, id offset, id count) : ISpvInstruction {
            public readonly id @base = @base;
            public readonly id count = count;
            public readonly id insert = insert;
            public readonly id offset = offset;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpBitFieldInsert(resultType, result, @base, insert, offset, count);
        }

        public readonly record struct OpBitFieldSExtract(id resultType, id result, id @base, id offset, id count) : ISpvInstruction {
            public readonly id @base = @base;
            public readonly id count = count;
            public readonly id offset = offset;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpBitFieldSExtract(resultType, result, @base, offset, count);
        }

        public readonly record struct OpBitFieldUExtract(id resultType, id result, id @base, id offset, id count) : ISpvInstruction {
            public readonly id @base = @base;
            public readonly id count = count;
            public readonly id offset = offset;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpBitFieldUExtract(resultType, result, @base, offset, count);
        }

        public readonly record struct OpBitReverse(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitReverse(resultType, result, op1);
        }

        public readonly record struct OpBitCount(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpBitCount(resultType, result, op1);
        }

        public readonly record struct OpAny(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpAny(resultType, result, op1);
        }

        public readonly record struct OpAll(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpAll(resultType, result, op1);
        }

        public readonly record struct OpIsNan(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIsNan(resultType, result, op1);
        }

        public readonly record struct OpIsInf(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIsInf(resultType, result, op1);
        }

        public readonly record struct OpIsFinite(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIsFinite(resultType, result, op1);
        }

        public readonly record struct OpIsNormal(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIsNormal(resultType, result, op1);
        }

        public readonly record struct OpSignBitSet(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSignBitSet(resultType, result, op1);
        }

        public readonly record struct OpLessOrGreater(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLessOrGreater(resultType, result, op1, op2);
        }

        public readonly record struct OpOrdered(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpOrdered(resultType, result, op1, op2);
        }

        public readonly record struct OpUnordered(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUnordered(resultType, result, op1, op2);
        }

        public readonly record struct OpLogicalEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLogicalEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpLogicalNotEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLogicalNotEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpLogicalOr(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLogicalOr(resultType, result, op1, op2);
        }

        public readonly record struct OpLogicalAnd(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLogicalAnd(resultType, result, op1, op2);
        }

        public readonly record struct OpLogicalNot(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpLogicalNot(resultType, result, op1);
        }

        public readonly record struct OpSelect(id resultType, id result, id condition, id op1, id op2) : ISpvInstruction {
            public readonly id condition = condition;
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSelect(resultType, result, condition, op1, op2);
        }

        public readonly record struct OpIEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpIEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpINotEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpINotEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpUGreaterThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUGreaterThan(resultType, result, op1, op2);
        }

        public readonly record struct OpSGreaterThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSGreaterThan(resultType, result, op1, op2);
        }

        public readonly record struct OpUGreaterThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpUGreaterThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpSGreaterThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSGreaterThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpULessThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpULessThan(resultType, result, op1, op2);
        }

        public readonly record struct OpSLessThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSLessThan(resultType, result, op1, op2);
        }

        public readonly record struct OpULessThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpULessThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpSLessThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpSLessThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdNotEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdNotEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordNotEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordNotEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdLessThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdLessThan(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordLessThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordLessThan(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdGreaterThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdGreaterThan(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordGreaterThan(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordGreaterThan(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdLessThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdLessThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordLessThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordLessThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFOrdGreaterThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFOrdGreaterThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpFUnordGreaterThanEqual(id resultType, id result, id op1, id op2) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id op2 = op2;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFUnordGreaterThanEqual(resultType, result, op1, op2);
        }

        public readonly record struct OpDPdx(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdx(resultType, result, op1);
        }

        public readonly record struct OpDPdy(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdy(resultType, result, op1);
        }

        public readonly record struct OpFwidth(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFwidth(resultType, result, op1);
        }

        public readonly record struct OpDPdxFine(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdxFine(resultType, result, op1);
        }

        public readonly record struct OpDPdyFine(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdyFine(resultType, result, op1);
        }

        public readonly record struct OpFwidthFine(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFwidthFine(resultType, result, op1);
        }

        public readonly record struct OpDPdxCoarse(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdxCoarse(resultType, result, op1);
        }

        public readonly record struct OpDPdyCoarse(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpDPdyCoarse(resultType, result, op1);
        }

        public readonly record struct OpFwidthCoarse(id resultType, id result, id op1) : ISpvInstruction {
            public readonly id op1 = op1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpFwidthCoarse(resultType, result, op1);
        }

        public readonly record struct OpPhi(id resultType, id result, (id variable, id parent)[] parts) : ISpvInstruction {
            public readonly (id variable, id parent)[] parts = parts;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpPhi(resultType, result, parts);
        }

        public readonly record struct OpLoopMerge(id mergeBlock, id continueTarget, SpvLoopControlMask loopControl) : ISpvInstruction {
            public readonly id continueTarget = continueTarget;
            public readonly SpvLoopControlMask loopControl = loopControl;
            public readonly id mergeBlock = mergeBlock;
            public void Emit(SpirVEmitter code) => code.EmitOpLoopMerge(mergeBlock, continueTarget, loopControl);
        }

        public readonly record struct OpSelectionMerge(id mergeBlock, SpvSelectionControlMask selectionControl) : ISpvInstruction {
            public readonly id mergeBlock = mergeBlock;
            public readonly SpvSelectionControlMask selectionControl = selectionControl;
            public void Emit(SpirVEmitter code) => code.EmitOpSelectionMerge(mergeBlock, selectionControl);
        }

        public readonly record struct OpAtomicLoad(id resultType, id result, id ptr, id scope, id semantics) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicLoad(resultType, result, ptr, scope, semantics);
        }

        public readonly record struct OpAtomicStore(id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;
            public void Emit(SpirVEmitter code) => code.EmitOpAtomicStore(ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicExchange(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicExchange(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicCompareExchange(id resultType, id result, id ptr, id scope, id eq, id uneq, id val,
            id comparator) : ISpvInstruction {
            public readonly id comparator = comparator;
            public readonly id eq = eq;
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id uneq = uneq;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicCompareExchange(resultType, result, ptr, scope, eq, uneq, val, comparator);
        }

        public readonly record struct OpAtomicCompareExchangeWeak(id resultType, id result, id ptr, id scope, id eq, id uneq, id val,
            id comparator) : ISpvInstruction {
            public readonly id comparator = comparator;
            public readonly id eq = eq;
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id uneq = uneq;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicCompareExchangeWeak(resultType, result, ptr, scope, eq, uneq, val, comparator);
        }

        public readonly record struct OpAtomicIIncrement(id resultType, id result, id ptr, id scope, id semantics) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicIIncrement(resultType, result, ptr, scope, semantics);
        }

        public readonly record struct OpAtomicIDecrement(id resultType, id result, id ptr, id scope, id semantics) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicIDecrement(resultType, result, ptr, scope, semantics);
        }

        public readonly record struct OpAtomicIAdd(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicIAdd(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicISub(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicISub(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicSMin(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicSMin(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicUMin(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicUMin(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicSMax(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicSMax(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicUMax(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicUMax(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicAnd(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicAnd(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicOr(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicOr(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicXor(id resultType, id result, id ptr, id scope, id semantics, id val) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicXor(resultType, result, ptr, scope, semantics, val);
        }

        public readonly record struct OpAtomicFlagTestAndSet(id resultType, id result, id ptr, id scope, id semantics) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id scope = scope;
            public readonly id semantics = semantics;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpAtomicFlagTestAndSet(resultType, result, ptr, scope, semantics);
        }

        public readonly record struct OpAtomicFlagClear(id ptr, id scope, id semantics) : ISpvInstruction {
            public readonly id ptr = ptr;
            public readonly id scope = scope;
            public readonly id semantics = semantics;
            public void Emit(SpirVEmitter code) => code.EmitOpAtomicFlagClear(ptr, scope, semantics);
        }

        public readonly record struct OpVertex : ISpvInstruction {
            public void Emit(SpirVEmitter code) => code.EmitOpEmitVertex();
        }

        public readonly record struct OpEndPrimitive : ISpvInstruction {
            public void Emit(SpirVEmitter code) => code.EmitOpEndPrimitive();
        }

        public readonly record struct OpStreamVertex(id stream) : ISpvInstruction {
            public readonly id stream = stream;
            public void Emit(SpirVEmitter code) => code.EmitOpEmitStreamVertex(stream);
        }

        public readonly record struct OpEndStreamPrimitive(id stream) : ISpvInstruction {
            public readonly id stream = stream;
            public void Emit(SpirVEmitter code) => code.EmitOpEndStreamPrimitive(stream);
        }

        public readonly record struct OpControlBarrier(id execution, id mem, id semantics) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id mem = mem;
            public readonly id semantics = semantics;
            public void Emit(SpirVEmitter code) => code.EmitOpControlBarrier(execution, mem, semantics);
        }

        public readonly record struct OpMemoryBarrier(id mem, id semantics) : ISpvInstruction {
            public readonly id mem = mem;
            public readonly id semantics = semantics;
            public void Emit(SpirVEmitter code) => code.EmitOpMemoryBarrier(mem, semantics);
        }

        public readonly record struct OpGroupAsyncCopy(id resultType, id result, id execution, id dest, id src, id numElements, id stride,
            id @event) : ISpvInstruction {
            public readonly id dest = dest;
            public readonly id @event = @event;
            public readonly id execution = execution;
            public readonly id numElements = numElements;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id src = src;
            public readonly id stride = stride;

            public void Emit(SpirVEmitter code) => code.EmitOpGroupAsyncCopy(resultType, result, execution, dest,
                src, numElements, stride, @event);
        }

        public readonly record struct OpGroupWaitEvents(id execution, id numEvents, id eventsList) : ISpvInstruction {
            public readonly id eventsList = eventsList;
            public readonly id execution = execution;
            public readonly id numEvents = numEvents;
            public void Emit(SpirVEmitter code) => code.EmitOpGroupWaitEvents(execution, numEvents, eventsList);
        }

        public readonly record struct OpGroupAll(id resultType, id result, id execution, id predicate) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id predicate = predicate;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpGroupAll(resultType, result, execution, predicate);
        }

        public readonly record struct OpGroupAny(id resultType, id result, id execution, id predicate) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id predicate = predicate;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpGroupAny(resultType, result, execution, predicate);
        }

        public readonly record struct OpGroupBroadcast(id resultType, id result, id execution, id val, id localId) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id localId = localId;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id val = val;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupBroadcast(resultType, result, execution, val, localId);
        }

        public readonly record struct OpGroupIAdd(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupIAdd(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupFAdd(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupFAdd(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupFMin(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupFMin(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupUMin(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupUMin(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupSMin(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupSMin(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupFMax(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupFMax(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupUMax(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupUMax(resultType, result, execution, operation, op1);
        }

        public readonly record struct OpGroupSMax(id resultType, id result, id execution, id operation, id op1) : ISpvInstruction {
            public readonly id execution = execution;
            public readonly id op1 = op1;
            public readonly id operation = operation;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpGroupSMax(resultType, result, execution, operation, op1);
        }
    }
}