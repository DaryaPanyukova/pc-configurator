using PcConfigurator.Entities.Components.Cpus;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Cpus;

public interface ICpuBuilder
{
    ICpuBuilder WithCoreFrequency(int coreFrequency);
    ICpuBuilder WithCoreCount(int coreCount);
    ICpuBuilder WithSocket(SocketType socket);
    ICpuBuilder WithHasVideoCore(bool hasVideoCore);
    ICpuBuilder WithMaxMemoryFrequency(int maxMemoryFrequency);
    ICpuBuilder WithTdp(int tdp);
    ICpuBuilder WithPowerConsumption(int powerConsumption);
    ICpuBuilder WithName(string name);
    ICpu Build();
}