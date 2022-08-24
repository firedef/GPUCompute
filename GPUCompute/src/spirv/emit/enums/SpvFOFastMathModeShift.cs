namespace GPUCompute.spirv.emit.enums; 

public enum SpvFOFastMathModeShift {
    FPFastMathModeNotNaNShift = 0,
    FPFastMathModeNotInfShift = 1,
    FPFastMathModeNSZShift = 2,
    FPFastMathModeAllowRecipShift = 3,
    FPFastMathModeFastShift = 4,
    FPFastMathModeAllowContractFastINTELShift = 16,
    FPFastMathModeAllowReassocINTELShift = 17,
}