using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums.extensions;
using id = System.UInt32;

// ReSharper disable BuiltInTypeReferenceStyle
namespace GPUCompute.spirv.gen.instructions;

public partial class SpvOp {
    public static class OpenClStd {
        public readonly record struct OpAcos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Acos, x);
        }

        public readonly record struct OpAcosh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Acosh, x);
        }

        public readonly record struct OpAcospi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Acospi, x);
        }

        public readonly record struct OpAsin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Asin, x);
        }

        public readonly record struct OpAsinh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Asinh, x);
        }

        public readonly record struct OpAsinpi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Asinpi, x);
        }

        public readonly record struct OpAtan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Atan, x);
        }

        public readonly record struct OpAtan2(id resultType, id result, id instructionSet, id y, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Atan2, y, x);
        }

        public readonly record struct OpAtanh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Atanh, x);
        }

        public readonly record struct OpAtanpi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Atanpi, x);
        }

        public readonly record struct OpAtan2pi(id resultType, id result, id instructionSet, id y, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Atan2pi, y, x);
        }

        public readonly record struct OpCbrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Cbrt, x);
        }

        public readonly record struct OpCeil(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Ceil, x);
        }

        public readonly record struct OpCopysign(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Copysign, x, y);
        }

        public readonly record struct OpCos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Cos, x);
        }

        public readonly record struct OpCosh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Cosh, x);
        }

        public readonly record struct OpCospi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Cospi, x);
        }

        public readonly record struct OpErfc(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Erfc, x);
        }

        public readonly record struct OpErf(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Erf, x);
        }

        public readonly record struct OpExp(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Exp, x);
        }

        public readonly record struct OpExp2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Exp2, x);
        }

        public readonly record struct OpExp10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Exp10, x);
        }

        public readonly record struct OpExpm1(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Expm1, x);
        }

        public readonly record struct OpFabs(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fabs, x);
        }

        public readonly record struct OpFdim(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fdim, x, y);
        }

        public readonly record struct OpFloor(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Floor, x);
        }

        public readonly record struct OpFma(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fma, a, b, c);
        }

        public readonly record struct OpFmax(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fmax, x, y);
        }

        public readonly record struct OpFmin(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fmin, x, y);
        }

        public readonly record struct OpFmod(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fmod, x, y);
        }

        public readonly record struct OpFract(id resultType, id result, id instructionSet, id x, id ptr) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fract, x, ptr);
        }

        public readonly record struct OpFrexp(id resultType, id result, id instructionSet, id x, id exp) : ISpvInstruction {
            public readonly id exp = exp;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Frexp, x, exp);
        }

        public readonly record struct OpHypot(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Hypot, x, y);
        }

        public readonly record struct OpIlogb(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Ilogb, x);
        }

        public readonly record struct OpLdexp(id resultType, id result, id instructionSet, id x, id k) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id k = k;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Ldexp, x, k);
        }

        public readonly record struct OpLgamma(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Lgamma, x);
        }

        public readonly record struct OpLgamma_r(id resultType, id result, id instructionSet, id x, id signp) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id signp = signp;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Lgamma_r, x, signp);
        }

        public readonly record struct OpLog(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Log, x);
        }

        public readonly record struct OpLog2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Log2, x);
        }

        public readonly record struct OpLog10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Log10, x);
        }

        public readonly record struct OpLog1p(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Log1p, x);
        }

        public readonly record struct OpLogb(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Logb, x);
        }

        public readonly record struct OpMad(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Mad, a, b, c);
        }

        public readonly record struct OpMaxmag(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Maxmag, x, y);
        }

        public readonly record struct OpMinmag(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Minmag, x, y);
        }

        public readonly record struct OpModf(id resultType, id result, id instructionSet, id x, id iptr) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id iptr = iptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Modf, x, iptr);
        }

        public readonly record struct OpNan(id resultType, id result, id instructionSet, id nancode) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id nancode = nancode;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Nan, nancode);
        }

        public readonly record struct OpNextafter(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Nextafter, x, y);
        }

        public readonly record struct OpPow(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Pow, x, y);
        }

        public readonly record struct OpPown(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Pown, x, y);
        }

        public readonly record struct OpPowr(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Powr, x, y);
        }

        public readonly record struct OpRemainder(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Remainder, x, y);
        }

        public readonly record struct OpRemquo(id resultType, id result, id instructionSet, id x, id y, id quo) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id quo = quo;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Remquo, x, y, quo);
        }

        public readonly record struct OpRint(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Rint, x);
        }

        public readonly record struct OpRootn(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Rootn, x, y);
        }

        public readonly record struct OpRound(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Round, x);
        }

        public readonly record struct OpRsqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Rsqrt, x);
        }

        public readonly record struct OpSin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sin, x);
        }

        public readonly record struct OpSincos(id resultType, id result, id instructionSet, id x, id cosval) : ISpvInstruction {
            public readonly id cosval = cosval;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sincos, x, cosval);
        }

        public readonly record struct OpSinh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sinh, x);
        }

        public readonly record struct OpSinpi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sinpi, x);
        }

        public readonly record struct OpSqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sqrt, x);
        }

        public readonly record struct OpTan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Tan, x);
        }

        public readonly record struct OpTanh(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Tanh, x);
        }

        public readonly record struct OpTanpi(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Tanpi, x);
        }

        public readonly record struct OpTgamma(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Tgamma, x);
        }

        public readonly record struct OpTrunc(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Trunc, x);
        }

        public readonly record struct OpHalf_cos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_cos, x);
        }

        public readonly record struct OpHalf_divide(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_divide, x, y);
        }

        public readonly record struct OpHalf_exp(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_exp, x);
        }

        public readonly record struct OpHalf_exp2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_exp2, x);
        }

        public readonly record struct OpHalf_exp10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_exp10, x);
        }

        public readonly record struct OpHalf_log(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_log, x);
        }

        public readonly record struct OpHalf_log2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_log2, x);
        }

        public readonly record struct OpHalf_log10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_log10, x);
        }

        public readonly record struct OpHalf_powr(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_powr, x, y);
        }

        public readonly record struct OpHalf_recip(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_recip, x);
        }

        public readonly record struct OpHalf_rsqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_rsqrt, x);
        }

        public readonly record struct OpHalf_sin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_sin, x);
        }

        public readonly record struct OpHalf_sqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_sqrt, x);
        }

        public readonly record struct OpHalf_tan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Half_tan, x);
        }

        public readonly record struct OpNative_cos(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_cos, x);
        }

        public readonly record struct OpNative_divide(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_divide, x, y);
        }

        public readonly record struct OpNative_exp(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_exp, x);
        }

        public readonly record struct OpNative_exp2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_exp2, x);
        }

        public readonly record struct OpNative_exp10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_exp10, x);
        }

        public readonly record struct OpNative_log(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_log, x);
        }

        public readonly record struct OpNative_log2(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_log2, x);
        }

        public readonly record struct OpNative_log10(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_log10, x);
        }

        public readonly record struct OpNative_powr(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_powr, x, y);
        }

        public readonly record struct OpNative_recip(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_recip, x);
        }

        public readonly record struct OpNative_rsqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_rsqrt, x);
        }

        public readonly record struct OpNative_sin(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_sin, x);
        }

        public readonly record struct OpNative_sqrt(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_sqrt, x);
        }

        public readonly record struct OpNative_tan(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Native_tan, x);
        }

        public readonly record struct OpS_abs(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_abs, x);
        }

        public readonly record struct OpS_abs_diff(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_abs_diff, x, y);
        }

        public readonly record struct OpS_add_sat(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_add_sat, x, y);
        }

        public readonly record struct OpU_add_sat(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_add_sat, x, y);
        }

        public readonly record struct OpS_hadd(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_hadd, x, y);
        }

        public readonly record struct OpU_hadd(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_hadd, x, y);
        }

        public readonly record struct OpS_rhadd(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_rhadd, x, y);
        }

        public readonly record struct OpU_rhadd(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_rhadd, x, y);
        }

        public readonly record struct OpS_clamp(id resultType, id result, id instructionSet, id x, id minval, id maxval) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id maxval = maxval;
            public readonly id minval = minval;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_clamp, x, minval, maxval);
        }

        public readonly record struct OpU_clamp(id resultType, id result, id instructionSet, id x, id minval, id maxval) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id maxval = maxval;
            public readonly id minval = minval;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_clamp, x, minval, maxval);
        }

        public readonly record struct OpClz(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Clz, x);
        }

        public readonly record struct OpCtz(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Ctz, x);
        }

        public readonly record struct OpS_mad_hi(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_mad_hi, a, b, c);
        }

        public readonly record struct OpU_mad_sat(id resultType, id result, id instructionSet, id x, id y, id z) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public readonly id z = z;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_mad_sat, x, y, z);
        }

        public readonly record struct OpS_mad_sat(id resultType, id result, id instructionSet, id x, id y, id z) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public readonly id z = z;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_mad_sat, x, y, z);
        }

        public readonly record struct OpS_max(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_max, x, y);
        }

        public readonly record struct OpU_max(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_max, x, y);
        }

        public readonly record struct OpS_min(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_min, x, y);
        }

        public readonly record struct OpU_min(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_min, x, y);
        }

        public readonly record struct OpS_mul_hi(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_mul_hi, x, y);
        }

        public readonly record struct OpRotate(id resultType, id result, id instructionSet, id v, id i) : ISpvInstruction {
            public readonly id i = i;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id v = v;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Rotate, v, i);
        }

        public readonly record struct OpS_sub_sat(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_sub_sat, x, y);
        }

        public readonly record struct OpU_sub_sat(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_sub_sat, x, y);
        }

        public readonly record struct OpU_upsample(id resultType, id result, id instructionSet, id hi, id lo) : ISpvInstruction {
            public readonly id hi = hi;
            public readonly id instructionSet = instructionSet;
            public readonly id lo = lo;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_upsample, hi, lo);
        }

        public readonly record struct OpS_upsample(id resultType, id result, id instructionSet, id hi, id lo) : ISpvInstruction {
            public readonly id hi = hi;
            public readonly id instructionSet = instructionSet;
            public readonly id lo = lo;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_upsample, hi, lo);
        }

        public readonly record struct OpPopcount(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Popcount, x);
        }

        public readonly record struct OpS_mad24(id resultType, id result, id instructionSet, id x, id y, id z) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public readonly id z = z;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_mad24, x, y, z);
        }

        public readonly record struct OpU_mad24(id resultType, id result, id instructionSet, id x, id y, id z) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public readonly id z = z;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_mad24, x, y, z);
        }

        public readonly record struct OpS_mul24(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.S_mul24, x, y);
        }

        public readonly record struct OpU_mul24(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_mul24, x, y);
        }

        public readonly record struct OpU_abs(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_abs, x);
        }

        public readonly record struct OpU_abs_diff(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_abs_diff, x, y);
        }

        public readonly record struct OpU_mul_hi(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_mul_hi, x, y);
        }

        public readonly record struct OpU_mad_hi(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.U_mad_hi, a, b, c);
        }

        public readonly record struct OpFclamp(id resultType, id result, id instructionSet, id x, id minval, id maxval) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id maxval = maxval;
            public readonly id minval = minval;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fclamp, x, minval, maxval);
        }

        public readonly record struct OpDegrees(id resultType, id result, id instructionSet, id radians) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id radians = radians;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Degrees, radians);
        }

        public readonly record struct OpFmax_common(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fmax_common, x, y);
        }

        public readonly record struct OpFmin_common(id resultType, id result, id instructionSet, id x, id y) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fmin_common, x, y);
        }

        public readonly record struct OpMix(id resultType, id result, id instructionSet, id x, id y, id a) : ISpvInstruction {
            public readonly id a = a;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Mix, x, y, a);
        }

        public readonly record struct OpRadians(id resultType, id result, id instructionSet, id degrees) : ISpvInstruction {
            public readonly id degrees = degrees;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Radians, degrees);
        }

        public readonly record struct OpStep(id resultType, id result, id instructionSet, id edge, id x) : ISpvInstruction {
            public readonly id edge = edge;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Step, edge, x);
        }

        public readonly record struct OpSmoothstep(id resultType, id result, id instructionSet, id edge0, id edge1, id x) : ISpvInstruction {
            public readonly id edge0 = edge0;
            public readonly id edge1 = edge1;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Smoothstep, edge0, edge1, x);
        }

        public readonly record struct OpSign(id resultType, id result, id instructionSet, id x) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Sign, x);
        }

        public readonly record struct OpCross(id resultType, id result, id instructionSet, id p0, id p1) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p0 = p0;
            public readonly id p1 = p1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Cross, p0, p1);
        }

        public readonly record struct OpDistance(id resultType, id result, id instructionSet, id p0, id p1) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p0 = p0;
            public readonly id p1 = p1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Distance, p0, p1);
        }

        public readonly record struct OpLength(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Length, p);
        }

        public readonly record struct OpNormalize(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Normalize, p);
        }

        public readonly record struct OpFast_distance(id resultType, id result, id instructionSet, id p0, id p1) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p0 = p0;
            public readonly id p1 = p1;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fast_distance, p0, p1);
        }

        public readonly record struct OpFast_length(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fast_length, p);
        }

        public readonly record struct OpFast_normalize(id resultType, id result, id instructionSet, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Fast_normalize, p);
        }

        public readonly record struct OpBitselect(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Bitselect, a, b, c);
        }

        public readonly record struct OpSelect(id resultType, id result, id instructionSet, id a, id b, id c) : ISpvInstruction {
            public readonly id a = a;
            public readonly id b = b;
            public readonly id c = c;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Select, a, b, c);
        }

        public readonly record struct OpVloadn(id resultType, id result, id instructionSet, id offset, id p, id n) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vloadn, offset, p, n);
        }

        public readonly record struct OpVstoren(id resultType, id result, id instructionSet, id data, id offset, id p) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstoren, data, offset, p);
        }

        public readonly record struct OpVload_half(id resultType, id result, id instructionSet, id offset, id p) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vload_half, offset, p);
        }

        public readonly record struct OpVload_halfn(id resultType, id result, id instructionSet, id offset, id p, id n) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vload_halfn, offset, p, n);
        }

        public readonly record struct OpVstore_half(id resultType, id result, id instructionSet, id data, id offset, id p) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstore_half, data, offset, p);
        }

        public readonly record struct OpVstore_half_r(id resultType, id result, id instructionSet, id data, id offset, id p, id mode) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id mode = mode;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstore_half_r, data, offset, p, mode);
        }

        public readonly record struct OpVstore_halfn(id resultType, id result, id instructionSet, id data, id offset, id p) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstore_halfn, data, offset, p);
        }

        public readonly record struct OpVstore_halfn_r(id resultType, id result, id instructionSet, id data, id offset, id p, id mode) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id mode = mode;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstore_halfn_r, data, offset, p, mode);
        }

        public readonly record struct OpVloada_halfn(id resultType, id result, id instructionSet, id offset, id p, id n) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id n = n;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vloada_halfn, offset, p, n);
        }

        public readonly record struct OpVstorea_halfn(id resultType, id result, id instructionSet, id data, id offset, id p) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstorea_halfn, data, offset, p);
        }

        public readonly record struct OpVstorea_halfn_r(id resultType, id result, id instructionSet, id data, id offset, id p, id mode) : ISpvInstruction {
            public readonly id data = data;
            public readonly id instructionSet = instructionSet;
            public readonly id mode = mode;
            public readonly id offset = offset;
            public readonly id p = p;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Vstorea_halfn_r, data, offset, p, mode);
        }

        public readonly record struct OpShuffle(id resultType, id result, id instructionSet, id x, id shuffleMask) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id shuffleMask = shuffleMask;
            public readonly id x = x;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Shuffle, x, shuffleMask);
        }

        public readonly record struct OpShuffle2(id resultType, id result, id instructionSet, id x, id y, id shuffleMask) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public readonly id shuffleMask = shuffleMask;
            public readonly id x = x;
            public readonly id y = y;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Shuffle2, x, y, shuffleMask);
        }

        public readonly record struct OpPrintf(id resultType, id result, id instructionSet, id format, params id[] additionalArguments) : ISpvInstruction {
            public readonly id[] additionalArguments = additionalArguments;
            public readonly id format = format;
            public readonly id instructionSet = instructionSet;
            public readonly id result = result;
            public readonly id resultType = resultType;

            public void Emit(SpirVEmitter code) {
                int pLen = additionalArguments.Length;
                uint[] args = new uint[1 + pLen];
                args[0] = format;
                for (int i = 0; i < pLen; i++) args[i + 1] = additionalArguments[i];

                code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Printf, args);
            }
        }

        public readonly record struct OpPrefetch(id resultType, id result, id instructionSet, id ptr, id numElements) : ISpvInstruction {
            public readonly id instructionSet = instructionSet;
            public readonly id numElements = numElements;
            public readonly id ptr = ptr;
            public readonly id result = result;
            public readonly id resultType = resultType;
            public void Emit(SpirVEmitter code) => code.EmitOpExtInst(resultType, result, instructionSet, SpvExtInstOpenClStd.Prefetch, ptr, numElements);
        }
    }
}