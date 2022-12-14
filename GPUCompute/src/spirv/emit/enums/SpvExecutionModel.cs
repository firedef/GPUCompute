namespace GPUCompute.spirv.emit.enums; 

public enum SpvExecutionModel {
    ExecutionModelVertex = 0,
    ExecutionModelTessellationControl = 1,
    ExecutionModelTessellationEvaluation = 2,
    ExecutionModelGeometry = 3,
    ExecutionModelFragment = 4,
    ExecutionModelGLCompute = 5,
    ExecutionModelKernel = 6,
    ExecutionModelTaskNV = 5267,
    ExecutionModelMeshNV = 5268,
    ExecutionModelRayGenerationKHR = 5313,
    ExecutionModelRayGenerationNV = 5313,
    ExecutionModelIntersectionKHR = 5314,
    ExecutionModelIntersectionNV = 5314,
    ExecutionModelAnyHitKHR = 5315,
    ExecutionModelAnyHitNV = 5315,
    ExecutionModelClosestHitKHR = 5316,
    ExecutionModelClosestHitNV = 5316,
    ExecutionModelMissKHR = 5317,
    ExecutionModelMissNV = 5317,
    ExecutionModelCallableKHR = 5318,
    ExecutionModelCallableNV = 5318,
}