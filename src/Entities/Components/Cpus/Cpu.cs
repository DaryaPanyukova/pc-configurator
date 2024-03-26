using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Cpus;

namespace PcConfigurator.Entities.Components.Cpus;

public class Cpu : ICpu
{
    public Cpu(
        int? coreFrequency,
        int? coreCount,
        SocketType? socket,
        bool? hasVideoCore,
        int? maxMemoryFrequency,
        int? tdp,
        int? powerConsumption,
        string? name)
    {
        CoreFrequency = coreFrequency ?? throw new ArgumentNullException(nameof(coreFrequency));
        CoreCount = coreCount ?? throw new ArgumentNullException(nameof(coreCount));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        HasVideoCore = hasVideoCore ?? throw new ArgumentNullException(nameof(hasVideoCore));
        MaxMemoryFrequency = maxMemoryFrequency ?? throw new ArgumentNullException(nameof(maxMemoryFrequency));
        Tdp = tdp ?? throw new ArgumentNullException(nameof(tdp));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public int CoreFrequency { get; private set; }
    public int CoreCount { get; private set; }
    public SocketType Socket { get; private set; }
    public bool HasVideoCore { get; private set; }
    public int MaxMemoryFrequency { get; private set; }
    public int Tdp { get; private set; }
    public int PowerConsumption { get; private set; }

    public ICpuBuilder Direct()
    {
        var builder = new CpuBuilder();
        return builder
            .WithCoreFrequency(CoreFrequency)
            .WithCoreCount(CoreCount)
            .WithSocket(Socket)
            .WithHasVideoCore(HasVideoCore)
            .WithMaxMemoryFrequency(MaxMemoryFrequency)
            .WithTdp(Tdp)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}