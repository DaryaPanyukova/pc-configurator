using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Gpus;

namespace PcConfigurator.Entities.Components.Gpus;

public interface IGpu : IGpuDirector, IComponent
{
    Dimensions Size { get; }
    int MemoryCount { get; }
    PcieType Pcie { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}