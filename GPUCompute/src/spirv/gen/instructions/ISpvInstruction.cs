using GPUCompute.spirv.emit;

namespace GPUCompute.spirv.gen.instructions; 

public interface ISpvInstruction {
    public void Emit(SpirVEmitter code);
}