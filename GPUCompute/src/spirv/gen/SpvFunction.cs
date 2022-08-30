using GPUCompute.spirv.emit;
using GPUCompute.spirv.emit.enums;
using GPUCompute.spirv.gen.instructions;
using GPUCompute.spirv.gen.stack;
using GPUCompute.spirv.gen.types;

namespace GPUCompute.spirv.gen; 

public class SpvFunction {
    public SpirVCodeGenerator generator;
    
    public uint returnType;
    public uint id;
    public SpvFunctionControlMask control = SpvFunctionControlMask.FunctionControlMaskNone;
    public uint functionType;
    
    public readonly List<(uint type, uint id)> parameters = new();
    public readonly List<SpvFunctionBlock> blocks = new();
    public readonly SpvFunctionInstructions instructions;

    public readonly Stack<Id> stack = new();
    public readonly Id[] args;
    public readonly SpvFuncVariable[] localVars;

    public SpvFunction(SpirVCodeGenerator generator, int maxArgs, int maxLocals) {
        this.generator = generator;
        args = new Id[maxArgs];
        localVars = new SpvFuncVariable[maxLocals];
        id = generator.GetNextId();
        NextBlock();
        instructions = new(this);
    }
    
    public void NextBlock() => blocks.Add(new() { blockId = generator.GetNextId() });

    public void Instruction(ISpvInstruction v) => blocks[^1].instructions.Add(v);
    public void Instructions(IEnumerable<ISpvInstruction> v) => blocks[^1].instructions.AddRange(v);
    public void Parameter(Id type, Id id) => parameters.Add((type, id));
    public SpvFuncVariable Variable(SpvType elementType) => generator.FuncVariable(this, SpvTypes.Pointer(elementType, SpvStorageClass.StorageClassFunction));
    
    public void Push(Id v) => stack.Push(v);

    public void PushAsVar(SpvType type, Id v) {
        SpvFuncVariable variable = Variable(type);
        variable.value = v;
        stack.Push(variable.value);
    }
    public void Dup() => stack.Push(stack.Peek());
    public void StoreArg(int i) => args[i] = stack.Pop();
    public void LoadArg(int i) => stack.Push(args[i]);

    public void InitLocal(int i, SpvType type) => localVars[i] = Variable(type);
    public void StoreLocal(int i) => localVars[i].value = stack.Pop();
    public void LoadLocal(int i) => stack.Push(localVars[i].value);

    public void PushType(SpvType type) => Push(type.GetId(generator));
    public void PushConst<T>(SpvType type, T v) where T : unmanaged => Push(type.Const(generator, v));

    public void Swap() {
        Id temp0 = stack.Pop();
        Id temp1 = stack.Pop();
        stack.Push(temp0);
        stack.Push(temp1);
    }
    public Id Peek() => stack.Peek();
    public Id Pop() => stack.Pop();
}