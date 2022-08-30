namespace GPUCompute.spirv.cs.info; 

public record struct BufferInfo(int argIndex, bool isIn, bool isOut, bool isUniform, string name, Type type) {
    public int argIndex = argIndex;
    public bool isIn = isIn;
    public bool isOut = isOut;
    public bool isUniform = isUniform;
    public string name = name;
    public Type type = type;
}