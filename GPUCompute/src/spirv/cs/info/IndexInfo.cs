namespace GPUCompute.spirv.cs.info; 

public record struct IndexInfo(int argIndex, Type type) {
    public int argIndex = argIndex;
    public Type type = type;
}