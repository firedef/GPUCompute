using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using id = System.UInt32;
// ReSharper disable BuiltInTypeReferenceStyle

namespace GPUCompute.spirv.gen; 

public abstract record SpvType {
    public abstract void Emit(SpirVEmitter code, id id);
}

public record SpvTypeVoid : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeVoid(id);
}

public record SpvTypeBool : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeBool(id);
}

public record SpvTypeFloat(uint width) : SpvType {
    public readonly uint width = width;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeFloat(id, width);
}

public record SpvTypeInt(uint width, bool isSigned) : SpvType {
    public readonly uint width = width;
    public readonly bool isSigned = isSigned;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeInt(id, width, isSigned ? 1u : 0u);
}

public record SpvTypeVector(id componentType, uint length) : SpvType {
    public readonly id componentType = componentType;
    public readonly uint length = length;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeVector(id, componentType, length);
}

public record SpvTypeMatrix(id columnType, uint columnCount) : SpvType {
    public readonly id columnType = columnType;
    public readonly uint columnCount = columnCount;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeMatrix(id, columnType, columnCount);
}

public record SpvTypeImage(id sampledType, SpvDimension dimension, uint depth, bool isArrayed, bool isMultisampled, uint sampled, SpvImageFormat format) : SpvType {
    public readonly id sampledType = sampledType;
    public readonly SpvDimension dimension = dimension;
    public readonly uint depth = depth;
    public readonly bool isArrayed = isArrayed;
    public readonly bool isMultisampled = isMultisampled;
    public readonly uint sampled = sampled;
    public readonly SpvImageFormat format = format;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeImage(id, sampledType, dimension, depth, isArrayed ? 1u : 0u, isMultisampled ? 1u : 0u, sampled, format);
}

public record SpvTypeSampler : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeSampler(id);
}

public record SpvTypeSampledImage(id imageType) : SpvType {
    public readonly id imageType = imageType;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeSampledImage(id, imageType);
}

public record SpvTypeArray(id elementType, uint length) : SpvType {
    public readonly id elementType = elementType;
    public readonly uint length = length;

    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeArray(id, elementType, length);
}

public record SpvTypeRuntimeArray(id elementType) : SpvType {
    public readonly id elementType = elementType;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeRuntimeArray(id, elementType);
}

public record SpvTypeStruct(params id[] memberTypes) : SpvType {
    public readonly id[] memberTypes = memberTypes;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeStruct(id, memberTypes);
}

public record SpvTypePointer(SpvStorageClass storageClass, id elementType) : SpvType {
    public readonly SpvStorageClass storageClass = storageClass;
    public readonly id elementType = elementType;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypePointer(id, (uint) storageClass, elementType);
}

public record SpvTypeFunction(id returnType, params id[] parameters) : SpvType {
    public readonly id returnType = returnType;
    public readonly id[] parameters = parameters;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeFunction(id, returnType, parameters);
}

public record SpvTypeEvent : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeEvent(id);
}

public record SpvTypeDeviceEvent : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeDeviceEvent(id);
}

public record SpvTypeQueue : SpvType {
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeQueue(id);
}

public record SpvTypePipe(SpvAccessQualifier accessQualifier) : SpvType {
    public readonly SpvAccessQualifier accessQualifier = accessQualifier;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypePipe(id, accessQualifier);
}

public record SpvTypeForwardPointer(id storageClass) : SpvType {
    public readonly id storageClass = storageClass;
    
    public override void Emit(SpirVEmitter code, id id) => code.EmitOpTypeForwardPointer(id, storageClass);
}

public enum SpvTypeKind {
    @void,
    @bool,
    @float,
    @int,
    vector,
    matrix,
    image,
    sampler,
    sampledImage,
    array,
    runtimeArray,
    @struct,
    pointer,
    function,
    @event,
    deviceEvent,
    queue,
    pipe,
    forwardPointer
}