namespace GPUCompute.spirv.emit.enums; 

public enum SpvMemoryAccessShift {
    MemoryAccessVolatileShift = 0,
    MemoryAccessAlignedShift = 1,
    MemoryAccessNontemporalShift = 2,
    MemoryAccessMakePointerAvailableShift = 3,
    MemoryAccessMakePointerAvailableKHRShift = 3,
    MemoryAccessMakePointerVisibleShift = 4,
    MemoryAccessMakePointerVisibleKHRShift = 4,
    MemoryAccessNonPrivatePointerShift = 5,
    MemoryAccessNonPrivatePointerKHRShift = 5,
    MemoryAccessAliasScopeINTELMaskShift = 16,
    MemoryAccessNoAliasINTELMaskShift = 17,
}