namespace GPUCompute.spirv.emit.enums; 

public enum SpvLoopControlMask {
    LoopControlMaskNone = 0,
    LoopControlUnrollMask = 0x00000001,
    LoopControlDontUnrollMask = 0x00000002,
    LoopControlDependencyInfiniteMask = 0x00000004,
    LoopControlDependencyLengthMask = 0x00000008,
    LoopControlMinIterationsMask = 0x00000010,
    LoopControlMaxIterationsMask = 0x00000020,
    LoopControlIterationMultipleMask = 0x00000040,
    LoopControlPeelCountMask = 0x00000080,
    LoopControlPartialCountMask = 0x00000100,
    LoopControlInitiationIntervalINTELMask = 0x00010000,
    LoopControlMaxConcurrencyINTELMask = 0x00020000,
    LoopControlDependencyArrayINTELMask = 0x00040000,
    LoopControlPipelineEnableINTELMask = 0x00080000,
    LoopControlLoopCoalesceINTELMask = 0x00100000,
    LoopControlMaxInterleavingINTELMask = 0x00200000,
    LoopControlSpeculatedIterationsINTELMask = 0x00400000,
    LoopControlNoFusionINTELMask = 0x00800000,
}