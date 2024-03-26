using PcConfigurator.Entities.Components.Cpus;

namespace PcConfigurator.Models.Attributes;

public class Bios
{
    private readonly List<string> _cpuSupported;

    public Bios(string type, string version, IReadOnlyCollection<string> cpuSupported)
    {
        Type = type;
        Version = version;
        _cpuSupported = new List<string>(cpuSupported);
    }

    public string Type { get; private set; }
    public string Version { get; private set; }
    public IReadOnlyCollection<string> CpuSupported => _cpuSupported;

    public bool IsSupported(ICpu cpu) => CpuSupported.Contains(cpu.Name);
}