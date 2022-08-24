namespace GPUCompute.spirv.emit.enums; 

public enum SpvQuantizationModes {
    QuantizationModesTRN = 0,
    QuantizationModesTRN_ZERO = 1,
    QuantizationModesRND = 2,
    QuantizationModesRND_ZERO = 3,
    QuantizationModesRND_INF = 4,
    QuantizationModesRND_MIN_INF = 5,
    QuantizationModesRND_CONV = 6,
    QuantizationModesRND_CONV_ODD = 7,
}