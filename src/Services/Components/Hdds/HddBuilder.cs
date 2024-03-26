using PcConfigurator.Entities.Components.Hdds;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Hdds;

public class HddBuilder : IHddBuilder
{
    private int? _capacity;
    private int? _speed;
    private int? _powerConsumption;
    private string? _name;
    private Sata? _sataType;

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpeed(int speed)
    {
        _speed = speed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithSataType(Sata sataType)
    {
        _sataType = sataType;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(_capacity, _speed, _powerConsumption, _sataType, _name);
    }
}