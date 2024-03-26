using PcConfigurator.Services.Components.PowerSupplies;

namespace PcConfigurator.Entities.Components.PowerSupplies;

public interface IPowerSupply : IPowerSupplyDirector, IComponent
{
    int MaxWattage { get; }
    int RecommendedWattage { get; }
}