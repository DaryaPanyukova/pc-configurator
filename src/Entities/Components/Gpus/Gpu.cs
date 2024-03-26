using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Gpus;

namespace PcConfigurator.Entities.Components.Gpus;

public class Gpu : IGpu
{
    public Gpu(
        Dimensions? size,
        int? memoryCount,
        PcieType? pcie,
        int? chipFrequency,
        int? powerConsumption,
        string? name)
    {
        Size = size ?? throw new ArgumentNullException(nameof(size));
        MemoryCount = memoryCount ?? throw new ArgumentNullException(nameof(memoryCount));
        Pcie = pcie ?? throw new ArgumentNullException(nameof(pcie));
        ChipFrequency = chipFrequency ?? throw new ArgumentNullException(nameof(chipFrequency));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public Dimensions Size { get; private set; }
    public int MemoryCount { get; private set; }
    public PcieType Pcie { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }

    public IGpuBuilder Direct()
    {
        var builder = new GpuBuilder();
        return builder
            .WithSize(Size)
            .WithMemoryCount(MemoryCount)
            .WithPcie(Pcie)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}