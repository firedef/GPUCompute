namespace GPUCompute.spirv.gen.instructions;

public partial class SpvFunctionInstructions {
    private readonly SpvFunction _function;
    public SpvFunctionInstructions(SpvFunction function) => _function = function;
    private SpirVCodeGenerator _code => _function.generator;
}