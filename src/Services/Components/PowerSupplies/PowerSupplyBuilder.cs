using PcConfigurator.Entities.Components.PowerSupplies;

namespace PcConfigurator.Services.Components.PowerSupplies;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int? _maxWattage;
    private int? _recommendedWattage;
    private string? _name;

    public IPowerSupplyBuilder WithMaxWattage(int maxWattage)
    {
        _maxWattage = maxWattage;
        return this;
    }

    public IPowerSupplyBuilder WithRecommendedWattage(int recommendedWattage)
    {
        _recommendedWattage = recommendedWattage;
        return this;
    }

    public IPowerSupplyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPowerSupply Build()
    {
        return new PowerSupply(_maxWattage, _recommendedWattage, _name);
    }
}