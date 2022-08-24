namespace GPUCompute.spirv.emit.enums; 

public enum SpvFunctionParameterAttribute {
    FunctionParameterAttributeZext = 0,
    FunctionParameterAttributeSext = 1,
    FunctionParameterAttributeByVal = 2,
    FunctionParameterAttributeSret = 3,
    FunctionParameterAttributeNoAlias = 4,
    FunctionParameterAttributeNoCapture = 5,
    FunctionParameterAttributeNoWrite = 6,
    FunctionParameterAttributeNoReadWrite = 7,
}