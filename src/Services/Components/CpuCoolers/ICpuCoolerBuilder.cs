using PcConfigurator.Entities.Components.CpuCoolers;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.CpuCoolers;

public interface ICpuCoolerBuilder
{
    ICpuCoolerBuilder WithSize(Dimensions size);
    ICpuCoolerBuilder WithSockets(IReadOnlyCollection<SocketType> sockets);
    ICpuCoolerBuilder WithMaxTdp(int maxTdp);
    ICpuCoolerBuilder WithName(string name);
    ICpuCooler Build();
}