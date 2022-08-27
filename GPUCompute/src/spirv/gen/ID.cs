using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public readonly record struct Id(uint v) {
    public readonly uint v = v;
    public static implicit operator uint(Id v) => v.v;
    public static implicit operator Id(uint v) => new(v);
}

public static class IdExtensions {
    public static Id Decorate(this Id id, SpirVCodeGenerator code, SpvDecoration name, params uint[] args) {
        code.decorations.Add(new(id, name, args));
        return id;
    }
    
    public static Id MemberDecorate(this Id id, uint member, SpirVCodeGenerator code, SpvDecoration name, params uint[] args) {
        code.memberDecorations.Add(new(id, member, name, args));
        return id;
    }

    public static Id DecorateBuiltIn(this Id id, SpirVCodeGenerator code, SpvBuiltIn name) => id.Decorate(code, SpvDecoration.DecorationBuiltIn, (uint) name);
    
    public static Id Binding(this Id id, SpirVCodeGenerator code, int v) => id.Decorate(code, SpvDecoration.DecorationBinding, (uint) v);
    public static Id DescriptorSet(this Id id, SpirVCodeGenerator code, int v) => id.Decorate(code, SpvDecoration.DecorationDescriptorSet, (uint) v);

    public static Id Bind(this Id id, SpirVCodeGenerator code, int set, int binding) {
        code.decorations.Add(new(id, SpvDecoration.DecorationDescriptorSet, (uint) set));
        code.decorations.Add(new(id, SpvDecoration.DecorationBinding, (uint) binding));
        return id;
    }
    
    public static Id ReadOnly(this Id id, SpirVCodeGenerator code) => id.Decorate(code, SpvDecoration.DecorationNonWritable);
    public static Id ReadOnly(this Id id, uint member, SpirVCodeGenerator code) => id.MemberDecorate(member, code, SpvDecoration.DecorationNonWritable);
    public static Id WriteOnly(this Id id, SpirVCodeGenerator code) => id.Decorate(code, SpvDecoration.DecorationNonReadable);
    public static Id WriteOnly(this Id id, uint member, SpirVCodeGenerator code) => id.MemberDecorate(member, code, SpvDecoration.DecorationNonReadable);
}