using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums.extensions;
using id = System.UInt32;

// ReSharper disable BuiltInTypeReferenceStyle
namespace GPUCompute.spirv.gen.instructions;

public partial class SpvOp {
    public static class GlslStd {
        public readonly record struct OpRound(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Round, x);
        }

        public readonly record struct OpRoundEven(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.RoundEven, x);
        }

        public readonly record struct OpTrunc(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Trunc, x);
        }

        public readonly record struct OpFAbs(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FAbs, x);
        }

        public readonly record struct OpSAbs(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.SAbs, x);
        }

        public readonly record struct OpFSign(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FSign, x);
        }

        public readonly record struct OpSSign(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.SSign, x);
        }

        public readonly record struct OpFloor(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Floor, x);
        }

        public readonly record struct OpCeil(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Ceil, x);
        }

        public readonly record struct OpFract(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Fract, x);
        }

        public readonly record struct OpRadians(id resultType, id result, id instructionSet, id degrees) : ISpvInstruction {
            public readonly id degrees = degrees;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Radians, degrees);
        }

        public readonly record struct OpDegrees(id resultType, id result, id instructionSet, id radians) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id radians = radians;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Degrees, radians);
        }

        public readonly record struct OpSin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Sin, x);
        }

        public readonly record struct OpCos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Cos, x);
        }

        public readonly record struct OpTan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Tan, x);
        }

        public readonly record struct OpAsin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Asin, x);
        }

        public readonly record struct OpAcos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Acos, x);
        }

        public readonly record struct OpAtan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Atan, x);
        }

        public readonly record struct OpSinh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Sinh, x);
        }

        public readonly record struct OpCosh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Cosh, x);
        }

        public readonly record struct OpTanh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Tanh, x);
        }

        public readonly record struct OpAsinh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Asinh, x);
        }

        public readonly record struct OpAcosh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Acosh, x);
        }

        public readonly record struct OpAtanh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Atanh, x);
        }

        public readonly record struct OpAtan2(id resultType, id result, id instructionSet, id y, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Atan2, y, x);
        }

        public readonly record struct OpPow(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Pow, x, y);
        }

        public readonly record struct OpExp(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Exp, x);
        }

        public readonly record struct OpLog(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Log, x);
        }

        public readonly record struct OpExp2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Exp2, x);
        }

        public readonly record struct OpLog2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Log2, x);
        }

        public readonly record struct OpSqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Sqrt, x);
        }

        public readonly record struct OpInverseSqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.InverseSqrt, x);
        }

        public readonly record struct OpDeterminant(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Determinant, x);
        }

        public readonly record struct OpMatrixInverse(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.MatrixInverse, x);
        }

        public readonly record struct OpModf(id resultType, id result, id instructionSet, id x, id i) : ISpvInstruction {
            public readonly id i = i;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Modf, x, i);
        }

        public readonly record struct OpModfStruct(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.ModfStruct, x);
        }

        public readonly record struct OpFMin(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FMin, x, y);
        }

        public readonly record struct OpUMin(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UMin, x, y);
        }

        public readonly record struct OpSMin(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.SMin, x, y);
        }

        public readonly record struct OpFMax(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FMax, x, y);
        }

        public readonly record struct OpUMax(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UMax, x, y);
        }

        public readonly record struct OpSMax(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.SMax, x, y);
        }

        public readonly record struct OpFClamp(id resultType, id result, id instructionSet, id x, id min, id max) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id max = max;
            public readonly id min = min;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FClamp, x, min, max);
        }

        public readonly record struct OpUClamp(id resultType, id result, id instructionSet, id x, id min, id max) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id max = max;
            public readonly id min = min;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UClamp, x, min, max);
        }

        public readonly record struct OpSClamp(id resultType, id result, id instructionSet, id x, id min, id max) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id max = max;
            public readonly id min = min;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.SClamp, x, min, max);
        }

        public readonly record struct OpFMix(id resultType, id result, id instructionSet, id a, id b, id time) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id time = time;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FMix, a, b, time);
        }

        public readonly record struct OpStep(id resultType, id result, id instructionSet, id edge, id x) : ISpvInstruction {
            public readonly id edge = edge;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Step, edge, x);
        }

        public readonly record struct OpSmoothStep
            (id resultType, id result, id instructionSet, id edge0, id edge1, id x) : ISpvInstruction {
            public readonly id edge0 = edge0;
            public readonly id edge1 = edge1;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet,
                SpvExtInstGlslStd.SmoothStep, edge0, edge1, x);
        }

        public readonly record struct OpFma(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Fma, a, b, c);
        }

        public readonly record struct OpFrexp(id resultType, id result, id instructionSet, id x, id exp) : ISpvInstruction {
            public readonly id exp = exp;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Frexp, x, exp);
        }

        public readonly record struct OpFrexpStruct(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FrexpStruct, x);
        }

        public readonly record struct OpLdexp(id resultType, id result, id instructionSet, id x, id exp) : ISpvInstruction {
            public readonly id exp = exp;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Ldexp, x, exp);
        }

        public readonly record struct OpPackSnorm4x8(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackSnorm4x8, v);
        }

        public readonly record struct OpPackUnorm4x8(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackUnorm4x8, v);
        }

        public readonly record struct OpPackSnorm2x16(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackSnorm2x16, v);
        }

        public readonly record struct OpPackUnorm2x16(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackUnorm2x16, v);
        }

        public readonly record struct OpPackHalf2x16(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackHalf2x16, v);
        }

        public readonly record struct OpPackDouble2x32(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.PackDouble2x32, v);
        }

        public readonly record struct OpUnpackSnorm2x16(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackSnorm2x16, p);
        }

        public readonly record struct OpUnpackUnorm2x16(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackUnorm2x16, p);
        }

        public readonly record struct OpUnpackHalf2x16(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackHalf2x16, v);
        }

        public readonly record struct OpUnpackSnorm4x8(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackSnorm4x8, p);
        }

        public readonly record struct OpUnpackUnorm4x8(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackUnorm4x8, p);
        }

        public readonly record struct OpUnpackDouble2x32(id resultType, id result, id instructionSet, id v) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.UnpackDouble2x32, v);
        }

        public readonly record struct OpLength(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Length, x);
        }

        public readonly record struct OpDistance(id resultType, id result, id instructionSet, id p0, id p1) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p0 = p0;
            public readonly id p1 = p1;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Distance, p0, p1);
        }

        public readonly record struct OpCross(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Cross, x, y);
        }

        public readonly record struct OpNormalize(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Normalize, x);
        }

        public readonly record struct OpFaceForward(id resultType, id result, id instructionSet, id n, id i, id nRef) : ISpvInstruction {
            public readonly id i = i;
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id nRef = nRef;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FaceForward, n, i, nRef);
        }

        public readonly record struct OpReflect(id resultType, id result, id instructionSet, id i, id n) : ISpvInstruction {
            public readonly id i = i;
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Reflect, i, n);
        }

        public readonly record struct OpRefract(id resultType, id result, id instructionSet, id i, id n, id eta) : ISpvInstruction {
            public readonly id eta = eta;
            public readonly id i = i;
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.Refract, i, n, eta);
        }

        public readonly record struct OpFindILsb(id resultType, id result, id instructionSet, id value) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id value = value;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FindILsb, value);
        }

        public readonly record struct OpFindSMsb(id resultType, id result, id instructionSet, id value) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id value = value;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FindSMsb, value);
        }

        public readonly record struct OpFindUMsb(id resultType, id result, id instructionSet, id value) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id value = value;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.FindUMsb, value);
        }

        public readonly record struct OpInterpolateAtCentroid
            (id resultType, id result, id instructionSet, id interpolant) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id interpolant = interpolant;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet,
                SpvExtInstGlslStd.InterpolateAtCentroid, interpolant);
        }

        public readonly record struct OpInterpolateAtSample
            (id resultType, id result, id instructionSet, id interpolant, id sample) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id interpolant = interpolant;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id sample = sample;

            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet,
                SpvExtInstGlslStd.InterpolateAtSample, interpolant, sample);
        }

        public readonly record struct OpInterpolateAtOffset
            (id resultType, id result, id instructionSet, id interpolant, id offset) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id interpolant = interpolant;
            public readonly id offset = offset;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet,
                SpvExtInstGlslStd.InterpolateAtOffset, interpolant, offset);
        }

        public readonly record struct OpNMin(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.NMin, x, y);
        }

        public readonly record struct OpNMax(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.NMax, x, y);
        }

        public readonly record struct OpNClamp(id resultType, id result, id instructionSet, id x, id min, id max) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id max = max;
            public readonly id min = min;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;

            public void Emit(SpirVEmitter code) =>
                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstGlslStd.NClamp, x, min, max);
        }
    }
    
    
}