using GPUCompute.vulkan.descriptors;
using Vulkan;

namespace GPUCompute.core; 

public class DescriptorSet : IDisposable {
    public Device device;
    public VulkanDescriptorPool pool;
    public VulkanDescriptorSetLayout layout;
    public VulkanDescriptorSet set;

    public DescriptorSet(VulkanDescriptorPool pool, params VkDescriptorType[] bindings) {
        this.pool = pool;
        device = pool.device;

        layout = new(device, bindings.Select((t, i) => new VkDescriptorSetLayoutBinding() {
            binding = (uint)i,
            descriptorCount = 1,
            descriptorType = t,
            stageFlags = VkShaderStageFlags.Compute
        }).ToArray());

        set = new(device, pool, new[] { layout.layout });
    }

    public void Dispose() {
        layout.Dispose();
        GC.SuppressFinalize(this);
    }

    ~DescriptorSet() => layout.Dispose();
}