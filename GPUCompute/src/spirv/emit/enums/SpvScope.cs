namespace GPUCompute.spirv.emit.enums; 

public enum SpvScope {
    ScopeCrossDevice = 0,
    ScopeDevice = 1,
    ScopeWorkgroup = 2,
    ScopeSubgroup = 3,
    ScopeInvocation = 4,
    ScopeQueueFamily = 5,
    ScopeQueueFamilyKHR = 5,
    ScopeShaderCallKHR = 6,
}