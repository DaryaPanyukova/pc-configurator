using PcConfigurator.Entities.Components.Gpus;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Gpus;

public class GpuBuilder : IGpuBuilder
{
    private Dimensions? _size;
    private int? _memoryCount;
    private PcieType? _pcie;
    private int? _chipFrequency;
    private int? _powerConsumption;
    private string? _name;

    public IGpuBuilder WithSize(Dimensions size)
    {
        _size = size;
        return this;
    }

    public IGpuBuilder WithMemoryCount(int memoryCount)
    {
        _memoryCount = memoryCount;
        return this;
    }

    public IGpuBuilder WithPcie(PcieType pcie)
    {
        _pcie = pcie;
        return this;
    }

    public IGpuBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IGpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IGpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IGpu Build()
    {
        return new Gpu(_size, _memoryCount, _pcie, _chipFrequency, _powerConsumption, _name);
    }
}