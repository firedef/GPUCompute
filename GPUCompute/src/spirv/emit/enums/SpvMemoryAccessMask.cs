namespace GPUCompute.spirv.emit.enums; 

public enum SpvMemoryAccessMask {
    MemoryAccessMaskNone = 0,
    MemoryAccessVolatileMask = 0x00000001,
    MemoryAccessAlignedMask = 0x00000002,
    MemoryAccessNontemporalMask = 0x00000004,
    MemoryAccessMakePointerAvailableMask = 0x00000008,
    MemoryAccessMakePointerAvailableKHRMask = 0x00000008,
    MemoryAccessMakePointerVisibleMask = 0x00000010,
    MemoryAccessMakePointerVisibleKHRMask = 0x00000010,
    MemoryAccessNonPrivatePointerMask = 0x00000020,
    MemoryAccessNonPrivatePointerKHRMask = 0x00000020,
    MemoryAccessAliasScopeINTELMaskMask = 0x00010000,
    MemoryAccessNoAliasINTELMaskMask = 0x00020000,
}