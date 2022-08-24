namespace GPUCompute.spirv.emit.enums; 

public enum SpvFPFastMathModeMask {
    FPFastMathModeMaskNone = 0,
    FPFastMathModeNotNaNMask = 0x00000001,
    FPFastMathModeNotInfMask = 0x00000002,
    FPFastMathModeNSZMask = 0x00000004,
    FPFastMathModeAllowRecipMask = 0x00000008,
    FPFastMathModeFastMask = 0x00000010,
    FPFastMathModeAllowContractFastINTELMask = 0x00010000,
    FPFastMathModeAllowReassocINTELMask = 0x00020000,
}