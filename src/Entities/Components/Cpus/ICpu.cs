using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Cpus;

namespace PcConfigurator.Entities.Components.Cpus;

public interface ICpu : ICpuDirector, IComponent
{
    int CoreFrequency { get; }
    int CoreCount { get; }
    SocketType Socket { get; }
    bool HasVideoCore { get; }
    int MaxMemoryFrequency { get; }
    int Tdp { get; }
    int PowerConsumption { get; }
}