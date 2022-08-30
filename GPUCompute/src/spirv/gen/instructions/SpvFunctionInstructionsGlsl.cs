using GPUCompute.spirv.gen.types;

namespace GPUCompute.spirv.gen.instructions;

public partial class SpvFunctionInstructions {
    public Id Round(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpRound(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id RoundEven(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpRoundEven(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Trunc(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpTrunc(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id FAbs(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFAbs(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id SAbs(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSAbs(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id FSign(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFSign(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id SSign(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSSign(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Floor(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFloor(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Ceil(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpCeil(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Fract(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFract(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Radians(SpvType type, Id degrees) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpRadians(type.GetId(_code), result, _code.GetGlsl(), degrees));
        return result;
    }

    public Id Degrees(SpvType type, Id radians) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpDegrees(type.GetId(_code), result, _code.GetGlsl(), radians));
        return result;
    }

    public Id Sin(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSin(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Cos(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpCos(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Tan(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpTan(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Asin(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAsin(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Acos(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAcos(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Atan(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAtan(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Sinh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSinh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Cosh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpCosh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Tanh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpTanh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Asinh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAsinh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Acosh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAcosh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Atanh(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAtanh(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Atan2(SpvType type, Id y, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpAtan2(type.GetId(_code), result, _code.GetGlsl(), y, x));
        return result;
    }

    public Id Pow(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPow(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id Exp(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpExp(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Log(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpLog(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Exp2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpExp2(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Log2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpLog2(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Sqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSqrt(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id InverseSqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpInverseSqrt(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Determinant(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpDeterminant(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id MatrixInverse(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpMatrixInverse(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Modf(SpvType type, Id x, Id i) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpModf(type.GetId(_code), result, _code.GetGlsl(), x, i));
        return result;
    }

    public Id ModfStruct(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpModfStruct(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id FMin(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFMin(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id UMin(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUMin(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id SMin(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSMin(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id FMax(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFMax(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id UMax(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUMax(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id SMax(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSMax(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id FClamp(SpvType type, Id x, Id min, Id max) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFClamp(type.GetId(_code), result, _code.GetGlsl(), x, min, max));
        return result;
    }

    public Id UClamp(SpvType type, Id x, Id min, Id max) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUClamp(type.GetId(_code), result, _code.GetGlsl(), x, min, max));
        return result;
    }

    public Id SClamp(SpvType type, Id x, Id min, Id max) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSClamp(type.GetId(_code), result, _code.GetGlsl(), x, min, max));
        return result;
    }

    public Id FMix(SpvType type, Id a, Id b, Id time) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFMix(type.GetId(_code), result, _code.GetGlsl(), a, b, time));
        return result;
    }

    public Id Step(SpvType type, Id edge, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpStep(type.GetId(_code), result, _code.GetGlsl(), edge, x));
        return result;
    }

    public Id SmoothStep(SpvType type, Id edge0, Id edge1, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpSmoothStep(type.GetId(_code), result, _code.GetGlsl(), edge0, edge1, x));
        return result;
    }

    public Id Fma(SpvType type, Id a, Id b, Id c) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFma(type.GetId(_code), result, _code.GetGlsl(), a, b, c));
        return result;
    }

    public Id Frexp(SpvType type, Id x, Id exp) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFrexp(type.GetId(_code), result, _code.GetGlsl(), x, exp));
        return result;
    }

    public Id FrexpStruct(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFrexpStruct(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Ldexp(SpvType type, Id x, Id exp) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpLdexp(type.GetId(_code), result, _code.GetGlsl(), x, exp));
        return result;
    }

    public Id PackSnorm4x8(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackSnorm4x8(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id PackUnorm4x8(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackUnorm4x8(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id PackSnorm2x16(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackSnorm2x16(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id PackUnorm2x16(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackUnorm2x16(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id PackHalf2x16(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackHalf2x16(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id PackDouble2x32(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpPackDouble2x32(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id UnpackSnorm2x16(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackSnorm2x16(type.GetId(_code), result, _code.GetGlsl(), p));
        return result;
    }

    public Id UnpackUnorm2x16(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackUnorm2x16(type.GetId(_code), result, _code.GetGlsl(), p));
        return result;
    }

    public Id UnpackHalf2x16(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackHalf2x16(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id UnpackSnorm4x8(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackSnorm4x8(type.GetId(_code), result, _code.GetGlsl(), p));
        return result;
    }

    public Id UnpackUnorm4x8(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackUnorm4x8(type.GetId(_code), result, _code.GetGlsl(), p));
        return result;
    }

    public Id UnpackDouble2x32(SpvType type, Id v) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpUnpackDouble2x32(type.GetId(_code), result, _code.GetGlsl(), v));
        return result;
    }

    public Id Length(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpLength(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id Distance(SpvType type, Id p0, Id p1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpDistance(type.GetId(_code), result, _code.GetGlsl(), p0, p1));
        return result;
    }

    public Id Cross(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpCross(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id Normalize(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpNormalize(type.GetId(_code), result, _code.GetGlsl(), x));
        return result;
    }

    public Id FaceForward(SpvType type, Id n, Id i, Id nRef) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFaceForward(type.GetId(_code), result, _code.GetGlsl(), n, i, nRef));
        return result;
    }

    public Id Reflect(SpvType type, Id i, Id n) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpReflect(type.GetId(_code), result, _code.GetGlsl(), i, n));
        return result;
    }

    public Id Refract(SpvType type, Id i, Id n, Id eta) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpRefract(type.GetId(_code), result, _code.GetGlsl(), i, n, eta));
        return result;
    }

    public Id FindILsb(SpvType type, Id value) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFindILsb(type.GetId(_code), result, _code.GetGlsl(), value));
        return result;
    }

    public Id FindSMsb(SpvType type, Id value) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFindSMsb(type.GetId(_code), result, _code.GetGlsl(), value));
        return result;
    }

    public Id FindUMsb(SpvType type, Id value) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpFindUMsb(type.GetId(_code), result, _code.GetGlsl(), value));
        return result;
    }

    public Id InterpolateAtCentroid(SpvType type, Id interpolant) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpInterpolateAtCentroid(type.GetId(_code), result, _code.GetGlsl(), interpolant));
        return result;
    }

    public Id InterpolateAtSample(SpvType type, Id interpolant, Id sample) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpInterpolateAtSample(type.GetId(_code), result, _code.GetGlsl(), interpolant, sample));
        return result;
    }

    public Id InterpolateAtOffset(SpvType type, Id interpolant, Id offset) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpInterpolateAtOffset(type.GetId(_code), result, _code.GetGlsl(), interpolant, offset));
        return result;
    }

    public Id NMin(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpNMin(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id NMax(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpNMax(type.GetId(_code), result, _code.GetGlsl(), x, y));
        return result;
    }

    public Id NClamp(SpvType type, Id x, Id min, Id max) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.GlslStd.OpNClamp(type.GetId(_code), result, _code.GetGlsl(), x, min, max));
        return result;
    }
}