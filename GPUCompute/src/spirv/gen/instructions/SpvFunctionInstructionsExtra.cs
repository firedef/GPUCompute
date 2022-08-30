using GPUCompute.spirv.gen.types;

namespace GPUCompute.spirv.gen.instructions; 

public partial class SpvFunctionInstructions {
    public Id AccessAndLoad(SpvType elementType, SpvType type, Id baseid, params Id[] indexes) =>
        Load(elementType, AccessChain(type, baseid, indexes));
    
    public void AccessAndStore(Id val, SpvType type, Id baseid, params Id[] indexes) =>
        Store(AccessChain(type, baseid, indexes), val);

    /// <summary>
    /// Pop: 4 + N <br/>
    /// Push: 1 <br/>
    /// <br/>
    /// - SpvType elementType <br/>
    /// - SpvType type <br/>
    /// - Id baseid <br/>
    /// - uint indexCount <br/>
    /// - Id[] indexes <br/>
    /// </summary>
    public void AccessAndLoad(SpvType elementType, SpvType type, uint indexCount) {
        Id baseid = _function.Pop();
        
        Id[] indexes = new Id[indexCount];
        for (int i = 0; i < indexCount; i++)
            indexes[i] = _function.Pop();

        _function.Push(Load(elementType, AccessChain(type, baseid, indexes)));
    }
}