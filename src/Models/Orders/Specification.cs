namespace PcConfigurator.Models.Orders;

public class Specification
{
    private readonly List<string> _hdds;
    private readonly List<string> _ramSticks;
    private readonly List<string> _ssds;

    public Specification(
        string? cpuCoolerName,
        string? cpuName,
        string? gpuName,
        IReadOnlyCollection<string>? hdds,
        string? motherBoardName,
        string? pcCaseName,
        string? powerSupplyName,
        IReadOnlyCollection<string>? ramSticks,
        IReadOnlyCollection<string>? ssds,
        string? wiFiModulesName)
    {
        CpuCoolerName = cpuCoolerName;
        CpuName = cpuName;
        GpuName = gpuName;
        _hdds = hdds == null ? new List<string>() : new List<string>(hdds);
        MotherBoardName = motherBoardName;
        PcCaseName = pcCaseName;
        PowerSupplyName = powerSupplyName;
        _ramSticks = ramSticks == null ? new List<string>() : new List<string>(ramSticks);
        _ssds = ssds == null ? new List<string>() : new List<string>(ssds);
        WiFiModulesName = wiFiModulesName;
    }

    public string? CpuCoolerName { get; private set; }
    public string? CpuName { get; private set; }
    public string? GpuName { get; private set; }
    public IReadOnlyCollection<string>? Hdds => _hdds;
    public string? MotherBoardName { get; private set; }
    public string? PcCaseName { get; private set; }
    public string? PowerSupplyName { get; private set; }
    public IReadOnlyCollection<string>? RamSticks => _ramSticks;
    public IReadOnlyCollection<string>? Ssds => _ssds;
    public string? WiFiModulesName { get; private set; }
}