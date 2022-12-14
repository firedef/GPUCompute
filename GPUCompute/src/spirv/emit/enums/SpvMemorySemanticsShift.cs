namespace GPUCompute.spirv.emit.enums; 

public enum SpvMemorySemanticsShift {
    MemorySemanticsAcquireShift = 1,
    MemorySemanticsReleaseShift = 2,
    MemorySemanticsAcquireReleaseShift = 3,
    MemorySemanticsSequentiallyConsistentShift = 4,
    MemorySemanticsUniformMemoryShift = 6,
    MemorySemanticsSubgroupMemoryShift = 7,
    MemorySemanticsWorkgroupMemoryShift = 8,
    MemorySemanticsCrossWorkgroupMemoryShift = 9,
    MemorySemanticsAtomicCounterMemoryShift = 10,
    MemorySemanticsImageMemoryShift = 11,
    MemorySemanticsOutputMemoryShift = 12,
    MemorySemanticsOutputMemoryKHRShift = 12,
    MemorySemanticsMakeAvailableShift = 13,
    MemorySemanticsMakeAvailableKHRShift = 13,
    MemorySemanticsMakeVisibleShift = 14,
    MemorySemanticsMakeVisibleKHRShift = 14,
    MemorySemanticsVolatileShift = 15,
}