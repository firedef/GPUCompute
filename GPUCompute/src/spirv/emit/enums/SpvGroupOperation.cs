namespace GPUCompute.spirv.emit.enums; 

public enum SpvGroupOperation {
    GroupOperationReduce = 0,
    GroupOperationInclusiveScan = 1,
    GroupOperationExclusiveScan = 2,
    GroupOperationClusteredReduce = 3,
    GroupOperationPartitionedReduceNV = 6,
    GroupOperationPartitionedInclusiveScanNV = 7,
    GroupOperationPartitionedExclusiveScanNV = 8,
}