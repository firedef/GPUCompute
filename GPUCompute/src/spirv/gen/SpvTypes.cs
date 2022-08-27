using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public static class SpvTypes {
    public static SpvType spvU8 => Int(8, false);
    public static SpvType spvI8 => Int(8, true);
    public static SpvType spvU16 => Int(16, false);
    public static SpvType spvI16 => Int(16, true);
    public static SpvType spvU32 => Int(32, false);
    public static SpvType spvI32 => Int(32, true);
    public static SpvType spvU64 => Int(64, false);
    public static SpvType spvI64 => Int(64, true);
    
    public static SpvType spvF16 => Float(16);
    public static SpvType spvF32 => Float(32);
    public static SpvType spvF64 => Float(64);
    
    public static SpvType spvVoid => new SpvTypeVoid();
    public static SpvType spvBool => new SpvTypeBool();

    public static SpvType spvU8x2 => Vector(spvU8, 2);
    public static SpvType spvU8x3 => Vector(spvU8, 3);
    public static SpvType spvU8x4 => Vector(spvU8, 4);
    public static SpvType spvI8x2 => Vector(spvI8, 2);
    public static SpvType spvI8x3 => Vector(spvI8, 3);
    public static SpvType spvI8x4 => Vector(spvI8, 4);
    
    public static SpvType spvU16x2 => Vector(spvU16, 2);
    public static SpvType spvU16x3 => Vector(spvU16, 3);
    public static SpvType spvU16x4 => Vector(spvU16, 4);
    public static SpvType spvI16x2 => Vector(spvI16, 2);
    public static SpvType spvI16x3 => Vector(spvI16, 3);
    public static SpvType spvI16x4 => Vector(spvI16, 4);
    
    public static SpvType spvU32x2 => Vector(spvU32, 2);
    public static SpvType spvU32x3 => Vector(spvU32, 3);
    public static SpvType spvU32x4 => Vector(spvU32, 4);
    public static SpvType spvI32x2 => Vector(spvI32, 2);
    public static SpvType spvI32x3 => Vector(spvI32, 3);
    public static SpvType spvI32x4 => Vector(spvI32, 4);
    
    public static SpvType spvU64x2 => Vector(spvU64, 2);
    public static SpvType spvU64x3 => Vector(spvU64, 3);
    public static SpvType spvU64x4 => Vector(spvU64, 4);
    public static SpvType spvI64x2 => Vector(spvI64, 2);
    public static SpvType spvI64x3 => Vector(spvI64, 3);
    public static SpvType spvI64x4 => Vector(spvI64, 4);
    
    public static SpvType spvF16x2 => Vector(spvF16, 2);
    public static SpvType spvF16x3 => Vector(spvF16, 3);
    public static SpvType spvF16x4 => Vector(spvF16, 4);
    public static SpvType spvF32x2 => Vector(spvF32, 2);
    public static SpvType spvF32x3 => Vector(spvF32, 3);
    public static SpvType spvF32x4 => Vector(spvF32, 4);
    public static SpvType spvF64x2 => Vector(spvF64, 2);
    public static SpvType spvF64x3 => Vector(spvF64, 3);
    public static SpvType spvF64x4 => Vector(spvF64, 4);
    
    public static SpvType spvBool2 => Vector(spvBool, 2);
    public static SpvType spvBool3 => Vector(spvBool, 3);
    public static SpvType spvBool4 => Vector(spvBool, 4);
    
    public static SpvType spvF32x2x2 => Matrix(spvF32x2, 2);
    public static SpvType spvF32x3x3 => Matrix(spvF32x3, 3);
    public static SpvType spvF32x4x4 => Matrix(spvF32x4, 4);

    public static SpvType spvVec2 => spvF32x2;
    public static SpvType spvVec3 => spvF32x3;
    public static SpvType spvVec4 => spvF32x4;
    
    public static SpvType spvMat2 => spvF32x2x2;
    public static SpvType spvMat3 => spvF32x3x3;
    public static SpvType spvMat4 => spvF32x4x4;

    public static SpvType Int(int width, bool signed) => new SpvTypeInt((uint) width, signed);
    public static SpvType Float(int width) => new SpvTypeFloat((uint) width);
    
    public static SpvType Vector(SpvType elementType, int length) => new SpvTypeVector(elementType, (uint) length);
    public static SpvType Matrix(SpvType columnType, int columnCount) => new SpvTypeMatrix(columnType, (uint) columnCount);
    
    public static SpvType Array(SpvType elementType, int length) => new SpvTypeArray(elementType, (uint) length);
    public static SpvType RuntimeArray(SpvType elementType) => new SpvTypeRuntimeArray(elementType);
    
    public static SpvType Struct(params SpvType[] members) => new SpvTypeStruct(members);

    public static SpvType Pointer(SpvType element, SpvStorageClass storageClass) => new SpvTypePointer(storageClass, element);

    public static SpvType Function(SpvType returnType, params Id[] parameters) => new SpvTypeFunction(returnType, parameters);

    public static Id GetId(this SpvType t, SpirVCodeGenerator gen) => gen.AddType(t);

    public static Id Const<T>(this SpvType t, SpirVCodeGenerator gen, T v) where T : unmanaged => gen.Constant(t.GetId(gen), v);
    public static Id Var(this SpvType t, SpirVCodeGenerator gen, SpvStorageClass storageClass) => gen.Variable(0, t, storageClass);
}