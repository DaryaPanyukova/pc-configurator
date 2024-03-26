using PcConfigurator.Entities.Components.Gpus;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Gpus;

public interface IGpuBuilder
{
    IGpuBuilder WithSize(Dimensions size);
    IGpuBuilder WithMemoryCount(int memoryCount);
    IGpuBuilder WithPcie(PcieType pcie);
    IGpuBuilder WithChipFrequency(int chipFrequency);
    IGpuBuilder WithPowerConsumption(int powerConsumption);
    IGpuBuilder WithName(string name);
    IGpu Build();
}