using PcConfigurator.Entities.Components.Ssds;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Ssds;

public interface ISsdBuilder
{
    ISsdBuilder WithConnection(Connection connection);

    ISsdBuilder WithCapacity(int capacity);

    ISsdBuilder WithMinSpeed(int minSpeed);

    ISsdBuilder WithPowerConsumption(int powerConsumption);
    ISsdBuilder WithName(string name);

    ISsd Build();
}