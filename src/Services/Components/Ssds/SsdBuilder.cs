using PcConfigurator.Entities.Components.Ssds;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Ssds;

public class SsdBuilder : ISsdBuilder
{
    private Connection? _connection;
    private int? _capacity;
    private int? _minSpeed;
    private int? _powerConsumption;
    private string? _name;

    public ISsdBuilder WithConnection(Connection connection)
    {
        _connection = connection;
        return this;
    }

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMinSpeed(int minSpeed)
    {
        _minSpeed = minSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(_connection, _capacity, _minSpeed, _powerConsumption, _name);
    }
}