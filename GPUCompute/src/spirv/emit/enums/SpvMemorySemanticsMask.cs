namespace GPUCompute.spirv.emit.enums; 

public enum SpvMemorySemanticsMask {
    MemorySemanticsMaskNone = 0,
    MemorySemanticsAcquireMask = 0x00000002,
    MemorySemanticsReleaseMask = 0x00000004,
    MemorySemanticsAcquireReleaseMask = 0x00000008,
    MemorySemanticsSequentiallyConsistentMask = 0x00000010,
    MemorySemanticsUniformMemoryMask = 0x00000040,
    MemorySemanticsSubgroupMemoryMask = 0x00000080,
    MemorySemanticsWorkgroupMemoryMask = 0x00000100,
    MemorySemanticsCrossWorkgroupMemoryMask = 0x00000200,
    MemorySemanticsAtomicCounterMemoryMask = 0x00000400,
    MemorySemanticsImageMemoryMask = 0x00000800,
    MemorySemanticsOutputMemoryMask = 0x00001000,
    MemorySemanticsOutputMemoryKHRMask = 0x00001000,
    MemorySemanticsMakeAvailableMask = 0x00002000,
    MemorySemanticsMakeAvailableKHRMask = 0x00002000,
    MemorySemanticsMakeVisibleMask = 0x00004000,
    MemorySemanticsMakeVisibleKHRMask = 0x00004000,
    MemorySemanticsVolatileMask = 0x00008000,
}