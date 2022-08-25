using GPUCompute.spirv.emit;
using GPUCompute.spirv.gen.instructions;

namespace GPUCompute.spirv.gen; 

public class SpvFunctionBlock {
    public SpvFunctionBlock? next;
    public uint blockId;

    public List<ISpvInstruction> instructions = new();

    public void Emit(SpirVEmitter code, bool emitLabel = true) {
        if (emitLabel) code.EmitOpLabel(blockId);

        foreach (ISpvInstruction instruction in instructions) 
            instruction.Emit(code);

        if (next == null) return;
        
        code.EmitOpBranch(next.blockId);
        next.Emit(code);
    }
}