using GPUCompute.spirv.emit.enums;

// ReSharper disable BuiltInTypeReferenceStyle

namespace GPUCompute.spirv.gen.types; 

public readonly record struct SpvTypeDecorationData(SpvDecoration name, params uint[] args) {
    public readonly SpvDecoration name = name;
    public readonly uint[] args = args;
}

public readonly record struct SpvTypeMemberDecorationData(uint member, SpvDecoration name, params uint[] args) {
    public readonly uint member = member;
    public readonly SpvDecoration name = name;
    public readonly uint[] args = args;
}

public abstract record SpvType {
    public readonly List<SpvTypeDecorationData> decorations = new();
    public readonly List<SpvTypeMemberDecorationData> memberDecorations = new();

    public abstract void Emit(SpirVCodeGenerator code, Id id);

    public void AddRequiredData(SpirVCodeGenerator code, Id id) {
        AddRequiredTypes(code);
        EmitDecorations(code, id);
    }

    public virtual void AddRequiredTypes(SpirVCodeGenerator code) {}

    private void EmitDecorations(SpirVCodeGenerator code, Id id) {
        foreach (SpvTypeDecorationData decoration in decorations) 
            code.decorations.Add(new(id, decoration.name, decoration.args));
        
        foreach (SpvTypeMemberDecorationData decoration in memberDecorations) 
            code.memberDecorations.Add(new(id, decoration.member, decoration.name, decoration.args));
    }

    public SpvType Decorate(SpvDecoration name, params uint[] args) { decorations.Add(new(name, args)); return this; }
    
    public SpvType MemberDecorate(uint member, SpvDecoration name, params uint[] args) { memberDecorations.Add(new(member, name, args)); return this; }
    
    public SpvType ReadOnly() => Decorate(SpvDecoration.DecorationNonWritable);
    public SpvType ReadOnly(uint member) => MemberDecorate(member, SpvDecoration.DecorationNonWritable);
    public SpvType WriteOnly() => Decorate(SpvDecoration.DecorationNonReadable);
    public SpvType WriteOnly(uint member) => MemberDecorate(member, SpvDecoration.DecorationNonReadable);

    public virtual bool Equals(SpvType? other) {
        if (other == null) return false;
        if (decorations.Count != other.decorations.Count) return false;
        if (memberDecorations.Count != other.memberDecorations.Count) return false;
    
        for (int i = 0; i < decorations.Count; i++) 
            if (decorations[i] != other.decorations[i])
                return false;
        
        for (int i = 0; i < memberDecorations.Count; i++) 
            if (memberDecorations[i] != other.memberDecorations[i])
                return false;
    
        return true;
    }

    public override int GetHashCode() {
        unchecked {
            int hash = 4235765;
            foreach (SpvTypeDecorationData v in decorations) hash = hash * 31 + v.GetHashCode();
            foreach (SpvTypeMemberDecorationData v in memberDecorations) hash = hash * 31 + v.GetHashCode();
            return hash;
        }
    }
}

public record SpvTypeVoid : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeVoid(id);
    
    public virtual bool Equals(SpvTypeVoid? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), -785960);
}

public record SpvTypeBool : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeBool(id);
    
    public virtual bool Equals(SpvTypeBool? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), 587394);
}

public record SpvTypeFloat(uint width) : SpvType {
    public readonly uint width = width;

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeFloat(id, width);
    
    public virtual bool Equals(SpvTypeFloat? other) => other != null && width == other.width && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), width);
}

public record SpvTypeInt(uint width, bool isSigned) : SpvType {
    public readonly uint width = width;
    public readonly bool isSigned = isSigned;

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeInt(id, width, isSigned ? 1u : 0u);
    
    public virtual bool Equals(SpvTypeInt? other) => other != null && width == other.width && isSigned == other.isSigned && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), width, isSigned);
}

public record SpvTypeVector(SpvType componentType, uint length) : SpvType {
    public readonly SpvType componentType = componentType;
    public readonly uint length = length;

    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(componentType);
    }

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeVector(id, code.GetType(componentType), length);
    
    public virtual bool Equals(SpvTypeVector? other) => other != null && componentType.Equals(other.componentType) && length == other.length && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), componentType, length);
}

public record SpvTypeMatrix(SpvType columnType, uint columnCount) : SpvType {
    public readonly SpvType columnType = columnType;
    public readonly uint columnCount = columnCount;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(columnType);
    }

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeMatrix(id, code.GetType(columnType), columnCount);
    
    public virtual bool Equals(SpvTypeMatrix? other) => other != null && columnType.Equals(other.columnType) && columnCount == other.columnCount && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), columnType, columnCount);
}

public record SpvTypeImage(SpvType sampledType, SpvDimension dimension, uint depth, bool isArrayed, bool isMultisampled, uint sampled, SpvImageFormat format) : SpvType {
    public readonly SpvType sampledType = sampledType;
    public readonly SpvDimension dimension = dimension;
    public readonly uint depth = depth;
    public readonly bool isArrayed = isArrayed;
    public readonly bool isMultisampled = isMultisampled;
    public readonly uint sampled = sampled;
    public readonly SpvImageFormat format = format;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(sampledType);
    }

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeImage(id, code.GetType(sampledType), dimension, depth, isArrayed ? 1u : 0u, isMultisampled ? 1u : 0u, sampled, format);
   
    public virtual bool Equals(SpvTypeImage? other) => other != null && 
                                                       sampledType.Equals(other.sampledType) && 
                                                       dimension == other.dimension && 
                                                       depth == other.depth && 
                                                       isArrayed == other.isArrayed && 
                                                       isMultisampled == other.isMultisampled && 
                                                       sampled == other.sampled && 
                                                       format == other.format && 
                                                       base.Equals(other);
    
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), sampledType, dimension, depth, isArrayed, isMultisampled, sampled, format);
}

public record SpvTypeSampler : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeSampler(id);
    
    public virtual bool Equals(SpvTypeSampler? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), 6745);
}

public record SpvTypeSampledImage(SpvType imageType) : SpvType {
    public readonly SpvType imageType = imageType;

    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(imageType);
    }

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeSampledImage(id, code.GetType(imageType));
    
    public virtual bool Equals(SpvTypeSampledImage? other) => other != null && imageType == other.imageType && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), imageType);
}

public record SpvTypeArray(SpvType elementType, uint length) : SpvType {
    public readonly SpvType elementType = elementType;
    public readonly uint length = length;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(elementType);
    }

    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeArray(id, code.GetType(elementType), length);
    
    public virtual bool Equals(SpvTypeArray? other) => other != null && elementType.Equals(other.elementType) && length == other.length && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), elementType, length);
}

public record SpvTypeRuntimeArray(SpvType elementType) : SpvType {
    public readonly SpvType elementType = elementType;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(elementType);
    }
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeRuntimeArray(id, code.GetType(elementType));
    
    public virtual bool Equals(SpvTypeRuntimeArray? other) => other != null && elementType.Equals(other.elementType) && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), elementType, -978234);
}

public record SpvTypeStruct(params SpvType[] memberTypes) : SpvType {
    public readonly SpvType[] memberTypes = memberTypes;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        foreach (SpvType type in memberTypes) code.AddType(type);
    }
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeStruct(id, memberTypes.Select(v => code.GetType(v).v).ToArray());

    public virtual bool Equals(SpvTypeStruct? other) {
        if (other == null) return false;
        if (memberTypes.Length != other.memberTypes.Length) return false;
        
        for (int i = 0; i < memberTypes.Length; i++) 
            if (memberTypes[i] != other.memberTypes[i])
                return false;

        return base.Equals(other);
    }

    public override int GetHashCode() {
        unchecked {
            int hash = base.GetHashCode() ^ 594377;
            foreach (SpvType v in memberTypes) hash = hash * 31 + v.GetHashCode();
            return hash;
        }
    }
}

public record SpvTypePointer(SpvStorageClass storageClass, SpvType elementType) : SpvType {
    public readonly SpvStorageClass storageClass = storageClass;
    public readonly SpvType elementType = elementType;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(elementType);
    }
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypePointer(id, (uint) storageClass, code.GetType(elementType));
    
    public virtual bool Equals(SpvTypePointer? other) => other != null && elementType.Equals(other.elementType) && storageClass == other.storageClass && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), elementType, storageClass);
}

public record SpvTypeFunction(SpvType returnType, params Id[] parameters) : SpvType {
    public readonly SpvType returnType = returnType;
    public readonly Id[] parameters = parameters;
    
    public override void AddRequiredTypes(SpirVCodeGenerator code) {
        code.AddType(returnType);
    }
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeFunction(id, code.GetType(returnType), parameters.Select(v => (uint) v).ToArray());
    
    public virtual bool Equals(SpvTypeFunction? other) {
        if (other == null) return false;
        if (parameters.Length != other.parameters.Length) return false;
        if (returnType != other.returnType) return false;
        
        for (int i = 0; i < parameters.Length; i++) 
            if (parameters[i] != other.parameters[i])
                return false;

        return base.Equals(other);
    }

    public override int GetHashCode() {
        unchecked {
            int hash = base.GetHashCode() ^ -756223;
            foreach (Id v in parameters) hash = hash * 31 + v.GetHashCode();
            return HashCode.Combine(hash, returnType);
        }
    }
}

public record SpvTypeEvent : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeEvent(id);
    
    public virtual bool Equals(SpvTypeEvent? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), 98797684);
}

public record SpvTypeDeviceEvent : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeDeviceEvent(id);
    
    public virtual bool Equals(SpvTypeDeviceEvent? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), 123446);
}

public record SpvTypeQueue : SpvType {
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeQueue(id);
    
    public virtual bool Equals(SpvTypeQueue? other) => other != null && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), -6456345);
}

public record SpvTypePipe(SpvAccessQualifier accessQualifier) : SpvType {
    public readonly SpvAccessQualifier accessQualifier = accessQualifier;
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypePipe(id, accessQualifier);

    public virtual bool Equals(SpvTypePipe? other) => other != null && accessQualifier == other.accessQualifier && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), accessQualifier, -42393);
}

public record SpvTypeForwardPointer(Id storageClass) : SpvType {
    public readonly Id storageClass = storageClass;
    
    public override void Emit(SpirVCodeGenerator code, Id id) => code.code.EmitOpTypeForwardPointer(id, storageClass);
    
    public virtual bool Equals(SpvTypeForwardPointer? other) => other != null && storageClass == other.storageClass && base.Equals(other);
    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), storageClass);
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