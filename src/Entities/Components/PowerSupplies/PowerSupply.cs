using PcConfigurator.Services.Components.PowerSupplies;

namespace PcConfigurator.Entities.Components.PowerSupplies;

public class PowerSupply : IPowerSupply
{
    public PowerSupply(int? maxWattage, int? recommendedWattage, string? name)
    {
        MaxWattage = maxWattage ?? throw new ArgumentNullException(nameof(maxWattage));
        RecommendedWattage = recommendedWattage ?? throw new ArgumentNullException(nameof(recommendedWattage));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public int MaxWattage { get; private set; }

    public int RecommendedWattage { get; private set; }

    public IPowerSupplyBuilder Direct()
    {
        var builder = new PowerSupplyBuilder();
        return builder.WithMaxWattage(MaxWattage).WithRecommendedWattage(RecommendedWattage).WithName(Name);
    }
}