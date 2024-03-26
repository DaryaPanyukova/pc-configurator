using PcConfigurator.Entities.Components.PowerSupplies;

namespace PcConfigurator.Services.Components.PowerSupplies;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder WithMaxWattage(int maxWattage);

    IPowerSupplyBuilder WithRecommendedWattage(int recommendedWattage);

    IPowerSupplyBuilder WithName(string name);
    IPowerSupply Build();
}