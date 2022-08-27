using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen; 

public readonly record struct Id(uint v) : ISpvId {
    public readonly uint v = v;
    public uint id => v;
    public static implicit operator uint(Id v) => v.v;
    public static implicit operator Id(uint v) => new(v);
}

public interface ISpvId {
    public uint id { get; }
} 

public static class IdExtensions {
    public static T Decorate<T>(this T id, SpirVCodeGenerator code, SpvDecoration name, params uint[] args) where T : ISpvId {
        code.decorations.Add(new(id.id, name, args));
        return id;
    }
    
    public static T MemberDecorate<T>(this T id, uint member, SpirVCodeGenerator code, SpvDecoration name, params uint[] args) where T : ISpvId {
        code.memberDecorations.Add(new(id.id, member, name, args));
        return id;
    }

    public static T DecorateBuiltIn<T>(this T id, SpirVCodeGenerator code, SpvBuiltIn name) where T : ISpvId => id.Decorate(code, SpvDecoration.DecorationBuiltIn, (uint) name);
    
    public static T Binding<T>(this T id, SpirVCodeGenerator code, int v) where T : ISpvId => id.Decorate(code, SpvDecoration.DecorationBinding, (uint) v);
    public static T DescriptorSet<T>(this T id, SpirVCodeGenerator code, int v) where T : ISpvId => id.Decorate(code, SpvDecoration.DecorationDescriptorSet, (uint) v);

    public static T Bind<T>(this T id, SpirVCodeGenerator code, int set, int binding) where T : ISpvId {
        code.decorations.Add(new(id.id, SpvDecoration.DecorationDescriptorSet, (uint) set));
        code.decorations.Add(new(id.id, SpvDecoration.DecorationBinding, (uint) binding));
        return id;
    }
    
    public static T ReadOnly<T>(this T id, SpirVCodeGenerator code) where T : ISpvId => id.Decorate(code, SpvDecoration.DecorationNonWritable);
    public static T ReadOnly<T>(this T id, uint member, SpirVCodeGenerator code) where T : ISpvId => id.MemberDecorate(member, code, SpvDecoration.DecorationNonWritable);
    public static T WriteOnly<T>(this T id, SpirVCodeGenerator code) where T : ISpvId => id.Decorate(code, SpvDecoration.DecorationNonReadable);
    public static T WriteOnly<T>(this T id, uint member, SpirVCodeGenerator code) where T : ISpvId => id.MemberDecorate(member, code, SpvDecoration.DecorationNonReadable);
}