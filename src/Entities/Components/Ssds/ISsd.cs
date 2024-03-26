using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Ssds;

namespace PcConfigurator.Entities.Components.Ssds;

public interface ISsd : ISsdDirector, IComponent
{
    Connection Connection { get; }

    int Capacity { get; }

    int MinSpeed { get; }

    int PowerConsumption { get; }
}