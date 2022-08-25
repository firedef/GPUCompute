using GPUCompute.spirv.emit.enums;

namespace GPUCompute.spirv.gen;

public readonly record struct SpvDecorationData(uint id, SpvDecoration name, params uint[] args) {
    public readonly uint id = id;
    public readonly SpvDecoration name = name;
    public readonly uint[] args = args;
}

public readonly record struct SpvMemberDecorationData(uint id, uint member, SpvDecoration name, params uint[] args) {
    public readonly uint id = id;
    public readonly uint member = member;
    public readonly SpvDecoration name = name;
    public readonly uint[] args = args;
}