using PcConfigurator.Entities.Components.Hdds;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Hdds;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(int capacity);
    IHddBuilder WithSpeed(int speed);
    IHddBuilder WithPowerConsumption(int powerConsumption);
    IHddBuilder WithName(string name);

    IHddBuilder WithSataType(Sata sataType);
    IHdd Build();
}