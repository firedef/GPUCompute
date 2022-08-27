using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen.instructions;

namespace GPUCompute.spirv.gen; 

public class SpvFunction {
    public SpirVCodeGenerator generator;
    
    public uint returnType;
    public uint id;
    public SpvFunctionControlMask control = SpvFunctionControlMask.FunctionControlMaskNone;
    public uint functionType;
    
    public List<(uint type, uint id)> parameters = new();
    public List<SpvFunctionBlock> blocks = new();
    public SpvFunctionInstructions instructions;

    public SpvFunction(SpirVCodeGenerator generator) {
        this.generator = generator;
        id = generator.GetNextId();
        NextBlock();
        instructions = new(this);
    }
    
    public void NextBlock() => blocks.Add(new() { blockId = generator.GetNextId() });

    public void Instruction(ISpvInstruction v) => blocks[^1].instructions.Add(v);
    public void Instructions(IEnumerable<ISpvInstruction> v) => blocks[^1].instructions.AddRange(v);
    public void Parameter(Id type, Id id) => parameters.Add((type, id));
    public Id Variable(Id type) => generator.AddVariable(id, type, SpvStorageClass.StorageClassFunction);
}