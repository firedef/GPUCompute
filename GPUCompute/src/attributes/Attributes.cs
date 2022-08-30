namespace GPUCompute.attributes;

[AttributeUsage(AttributeTargets.Parameter)]
public class InAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Parameter)]
public class OutAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Parameter)]
public class IndexAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Parameter)]
public class UniformAttribute : Attribute { }