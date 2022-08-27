namespace GPUCompute.spirv.gen.instructions; 

public partial class SpvFunctionInstructions {
    public Id AccessAndLoad(SpvType elementType, SpvType type, Id baseid, params Id[] indexes) =>
        Load(elementType, AccessChain(type, baseid, indexes));
    
    public void AccessAndStore(Id val, SpvType type, Id baseid, params Id[] indexes) =>
        Store(AccessChain(type, baseid, indexes), val);
}