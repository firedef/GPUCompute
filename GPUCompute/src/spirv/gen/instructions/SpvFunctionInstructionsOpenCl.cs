namespace GPUCompute.spirv.gen.instructions;

public partial class SpvFunctionInstructions {
    //     public Id Acos(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAcos(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Acosh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAcosh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Acospi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpAcospi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Asin(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAsin(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Asinh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAsinh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Asinpi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpAsinpi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Atan(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAtan(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Atan2(SpvType type, Id y, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAtan2(type.GetId(_code), result, _code.GetOpenCl(), y, x));
    //   return result;
    // }
    // public Id Atanh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpAtanh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Atanpi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpAtanpi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Atan2pi(SpvType type, Id y, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpAtan2pi(type.GetId(_code), result, _code.GetOpenCl(), y, x));
        return result;
    }

    public Id Cbrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpCbrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Ceil(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpCeil(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Copysign(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpCopysign(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    // public Id Cos(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpCos(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Cosh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpCosh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Cospi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpCospi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Erfc(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpErfc(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Erf(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpErf(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Exp(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpExp(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Exp2(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpExp2(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Exp10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpExp10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Expm1(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpExpm1(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Fabs(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFabs(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Fdim(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFdim(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    // public Id Floor(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpFloor(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Fma(SpvType type, Id a, Id b, Id c) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpFma(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
    //   return result;
    // }
    public Id Fmax(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFmax(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Fmin(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFmin(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Fmod(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFmod(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Fract(SpvType type, Id x, Id ptr) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFract(type.GetId(_code), result, _code.GetOpenCl(), x, ptr));
        return result;
    }

    // public Id Frexp(SpvType type, Id x, Id exp) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpFrexp(type.GetId(_code), result, _code.GetOpenCl(), x, exp));
    //   return result;
    // }
    public Id Hypot(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHypot(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Ilogb(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpIlogb(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Ldexp(SpvType type, Id x, Id k) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpLdexp(type.GetId(_code), result, _code.GetOpenCl(), x, k));
    //   return result;
    // }
    public Id Lgamma(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpLgamma(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Lgamma_r(SpvType type, Id x, Id signp) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpLgamma_r(type.GetId(_code), result, _code.GetOpenCl(), x, signp));
        return result;
    }

    // public Id Log(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpLog(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Log2(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpLog2(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Log10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpLog10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Log1p(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpLog1p(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Logb(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpLogb(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Mad(SpvType type, Id a, Id b, Id c) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpMad(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
        return result;
    }

    public Id Maxmag(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpMaxmag(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Minmag(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpMinmag(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    // public Id Modf(SpvType type, Id x, Id iptr) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpModf(type.GetId(_code), result, _code.GetOpenCl(), x, iptr));
    //   return result;
    // }
    public Id Nan(SpvType type, Id nancode) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNan(type.GetId(_code), result, _code.GetOpenCl(), nancode));
        return result;
    }

    public Id Nextafter(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNextafter(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    // public Id Pow(SpvType type, Id x, Id y) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpPow(type.GetId(_code), result, _code.GetOpenCl(), x, y));
    //   return result;
    // }
    public Id Pown(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpPown(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Powr(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpPowr(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Remainder(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRemainder(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Remquo(SpvType type, Id x, Id y, Id quo) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRemquo(type.GetId(_code), result, _code.GetOpenCl(), x, y, quo));
        return result;
    }

    public Id Rint(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRint(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Rootn(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRootn(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    // public Id Round(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpRound(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Rsqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRsqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Sin(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpSin(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Sincos(SpvType type, Id x, Id cosval) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpSincos(type.GetId(_code), result, _code.GetOpenCl(), x, cosval));
        return result;
    }

    // public Id Sinh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpSinh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Sinpi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpSinpi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Sqrt(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpSqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Tan(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpTan(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    // public Id Tanh(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpTanh(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Tanpi(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpTanpi(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Tgamma(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpTgamma(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Trunc(SpvType type, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpTrunc(type.GetId(_code), result, _code.GetOpenCl(), x));
    //   return result;
    // }
    public Id Half_cos(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_cos(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_divide(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_divide(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Half_exp(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_exp(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_exp2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_exp2(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_exp10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_exp10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_log(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_log(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_log2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_log2(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_log10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_log10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_powr(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_powr(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Half_recip(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_recip(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_rsqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_rsqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_sin(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_sin(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_sqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_sqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Half_tan(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpHalf_tan(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_cos(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_cos(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_divide(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_divide(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Native_exp(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_exp(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_exp2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_exp2(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_exp10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_exp10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_log(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_log(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_log2(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_log2(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_log10(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_log10(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_powr(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_powr(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Native_recip(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_recip(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_rsqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_rsqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_sin(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_sin(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_sqrt(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_sqrt(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Native_tan(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpNative_tan(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id S_abs(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_abs(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id S_abs_diff(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_abs_diff(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_add_sat(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_add_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_add_sat(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_add_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_hadd(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_hadd(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_hadd(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_hadd(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_rhadd(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_rhadd(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_rhadd(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_rhadd(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_clamp(SpvType type, Id x, Id minval, Id maxval) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_clamp(type.GetId(_code), result, _code.GetOpenCl(), x, minval, maxval));
        return result;
    }

    public Id U_clamp(SpvType type, Id x, Id minval, Id maxval) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_clamp(type.GetId(_code), result, _code.GetOpenCl(), x, minval, maxval));
        return result;
    }

    public Id Clz(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpClz(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id Ctz(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpCtz(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id S_mad_hi(SpvType type, Id a, Id b, Id c) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_mad_hi(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
        return result;
    }

    public Id U_mad_sat(SpvType type, Id x, Id y, Id z) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_mad_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y, z));
        return result;
    }

    public Id S_mad_sat(SpvType type, Id x, Id y, Id z) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_mad_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y, z));
        return result;
    }

    public Id S_max(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_max(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_max(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_max(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_min(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_min(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_min(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_min(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id S_mul_hi(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_mul_hi(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Rotate(SpvType type, Id v, Id i) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpRotate(type.GetId(_code), result, _code.GetOpenCl(), v, i));
        return result;
    }

    public Id S_sub_sat(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_sub_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_sub_sat(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_sub_sat(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_upsample(SpvType type, Id hi, Id lo) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_upsample(type.GetId(_code), result, _code.GetOpenCl(), hi, lo));
        return result;
    }

    public Id S_upsample(SpvType type, Id hi, Id lo) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_upsample(type.GetId(_code), result, _code.GetOpenCl(), hi, lo));
        return result;
    }

    public Id Popcount(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpPopcount(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id S_mad24(SpvType type, Id x, Id y, Id z) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_mad24(type.GetId(_code), result, _code.GetOpenCl(), x, y, z));
        return result;
    }

    public Id U_mad24(SpvType type, Id x, Id y, Id z) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_mad24(type.GetId(_code), result, _code.GetOpenCl(), x, y, z));
        return result;
    }

    public Id S_mul24(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpS_mul24(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_mul24(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_mul24(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_abs(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_abs(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    public Id U_abs_diff(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_abs_diff(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_mul_hi(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_mul_hi(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id U_mad_hi(SpvType type, Id a, Id b, Id c) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpU_mad_hi(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
        return result;
    }

    public Id Fclamp(SpvType type, Id x, Id minval, Id maxval) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFclamp(type.GetId(_code), result, _code.GetOpenCl(), x, minval, maxval));
        return result;
    }

    // public Id Degrees(SpvType type, Id radians) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpDegrees(type.GetId(_code), result, _code.GetOpenCl(), radians));
    //   return result;
    // }
    public Id Fmax_common(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFmax_common(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Fmin_common(SpvType type, Id x, Id y) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFmin_common(type.GetId(_code), result, _code.GetOpenCl(), x, y));
        return result;
    }

    public Id Mix(SpvType type, Id x, Id y, Id a) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpMix(type.GetId(_code), result, _code.GetOpenCl(), x, y, a));
        return result;
    }

    // public Id Radians(SpvType type, Id degrees) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpRadians(type.GetId(_code), result, _code.GetOpenCl(), degrees));
    //   return result;
    // }
    // public Id Step(SpvType type, Id edge, Id x) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpStep(type.GetId(_code), result, _code.GetOpenCl(), edge, x));
    //   return result;
    // }
    public Id Smoothstep(SpvType type, Id edge0, Id edge1, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpSmoothstep(type.GetId(_code), result, _code.GetOpenCl(), edge0, edge1, x));
        return result;
    }

    public Id Sign(SpvType type, Id x) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpSign(type.GetId(_code), result, _code.GetOpenCl(), x));
        return result;
    }

    // public Id Cross(SpvType type, Id p0, Id p1) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpCross(type.GetId(_code), result, _code.GetOpenCl(), p0, p1));
    //   return result;
    // }
    // public Id Distance(SpvType type, Id p0, Id p1) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpDistance(type.GetId(_code), result, _code.GetOpenCl(), p0, p1));
    //   return result;
    // }
    // public Id Length(SpvType type, Id p) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpLength(type.GetId(_code), result, _code.GetOpenCl(), p));
    //   return result;
    // }
    // public Id Normalize(SpvType type, Id p) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpNormalize(type.GetId(_code), result, _code.GetOpenCl(), p));
    //   return result;
    // }
    public Id Fast_distance(SpvType type, Id p0, Id p1) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFast_distance(type.GetId(_code), result, _code.GetOpenCl(), p0, p1));
        return result;
    }

    public Id Fast_length(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFast_length(type.GetId(_code), result, _code.GetOpenCl(), p));
        return result;
    }

    public Id Fast_normalize(SpvType type, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpFast_normalize(type.GetId(_code), result, _code.GetOpenCl(), p));
        return result;
    }

    public Id Bitselect(SpvType type, Id a, Id b, Id c) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpBitselect(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
        return result;
    }

    // public Id Select(SpvType type, Id a, Id b, Id c) {
    //   Id result = _code.GetNextId();
    //   _function.Instruction(new SpvOp.OpenClStd.OpSelect(type.GetId(_code), result, _code.GetOpenCl(), a, b, c));
    //   return result;
    // }
    public Id Vloadn(SpvType type, Id offset, Id p, Id n) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVloadn(type.GetId(_code), result, _code.GetOpenCl(), offset, p, n));
        return result;
    }

    public Id Vstoren(SpvType type, Id data, Id offset, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstoren(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p));
        return result;
    }

    public Id Vload_half(SpvType type, Id offset, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVload_half(type.GetId(_code), result, _code.GetOpenCl(), offset, p));
        return result;
    }

    public Id Vload_halfn(SpvType type, Id offset, Id p, Id n) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVload_halfn(type.GetId(_code), result, _code.GetOpenCl(), offset, p, n));
        return result;
    }

    public Id Vstore_half(SpvType type, Id data, Id offset, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstore_half(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p));
        return result;
    }

    public Id Vstore_half_r(SpvType type, Id data, Id offset, Id p, Id mode) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstore_half_r(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p, mode));
        return result;
    }

    public Id Vstore_halfn(SpvType type, Id data, Id offset, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstore_halfn(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p));
        return result;
    }

    public Id Vstore_halfn_r(SpvType type, Id data, Id offset, Id p, Id mode) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstore_halfn_r(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p, mode));
        return result;
    }

    public Id Vloada_halfn(SpvType type, Id offset, Id p, Id n) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVloada_halfn(type.GetId(_code), result, _code.GetOpenCl(), offset, p, n));
        return result;
    }

    public Id Vstorea_halfn(SpvType type, Id data, Id offset, Id p) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstorea_halfn(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p));
        return result;
    }

    public Id Vstorea_halfn_r(SpvType type, Id data, Id offset, Id p, Id mode) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpVstorea_halfn_r(type.GetId(_code), result, _code.GetOpenCl(), data, offset, p, mode));
        return result;
    }

    public Id Shuffle(SpvType type, Id x, Id shuffleMask) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpShuffle(type.GetId(_code), result, _code.GetOpenCl(), x, shuffleMask));
        return result;
    }

    public Id Shuffle2(SpvType type, Id x, Id y, Id shuffleMask) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpShuffle2(type.GetId(_code), result, _code.GetOpenCl(), x, y, shuffleMask));
        return result;
    }

    public Id Printf(SpvType type, Id format, params Id[] additionalArguments) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpPrintf(type.GetId(_code), result, _code.GetOpenCl(), format, additionalArguments.Select(v => v.v).ToArray()));
        return result;
    }

    public Id Prefetch(SpvType type, Id ptr, Id numElements) {
        Id result = _code.GetNextId();
        _function.Instruction(new SpvOp.OpenClStd.OpPrefetch(type.GetId(_code), result, _code.GetOpenCl(), ptr, numElements));
        return result;
    }
}