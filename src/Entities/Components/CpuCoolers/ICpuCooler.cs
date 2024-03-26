using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.CpuCoolers;

namespace PcConfigurator.Entities.Components.CpuCoolers;

public interface ICpuCooler : ICpuCoolerDirector, IComponent
{
    Dimensions Size { get; }
    IReadOnlyCollection<SocketType> Sockets { get; }
    int MaxTdp { get; }

    bool IsSupported(SocketType socket);
}