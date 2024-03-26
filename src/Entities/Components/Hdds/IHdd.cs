using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Hdds;

namespace PcConfigurator.Entities.Components.Hdds;

public interface IHdd : IHddDirector, IComponent
{
    int Capacity { get; }
    int Speed { get; }
    int PowerConsumption { get; }
    Sata SataType { get; }
}