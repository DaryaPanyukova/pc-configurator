using PcConfigurator.Entities.Components.CpuCoolers;
using PcConfigurator.Entities.Components.Cpus;
using PcConfigurator.Entities.Components.Gpus;
using PcConfigurator.Entities.Components.Hdds;
using PcConfigurator.Entities.Components.MotherBoards;
using PcConfigurator.Entities.Components.PcCases;
using PcConfigurator.Entities.Components.PowerSupplies;
using PcConfigurator.Entities.Components.Rams;
using PcConfigurator.Entities.Components.Ssds;
using PcConfigurator.Entities.Components.WiFiModules;
using PcConfigurator.Entities.Computers;
using PcConfigurator.Models.Orders;

namespace PcConfigurator.Services.Computers;

public class UnorderedAssemblyBuilder
{
    private List<IRam>? _rams;
    private List<ISsd>? _ssds;
    private List<IHdd>? _hdds;
    private IMotherBoard? _motherBoard;
    private ICpu? _cpu;
    private IGpu? _gpu;
    private ICpuCooler? _cooler;
    private IPcCase? _pcCase;
    private IPowerSupply? _powerSupply;
    private IWiFiModule? _wiFiModule;

    public UnorderedAssemblyBuilder WithPcCase(IPcCase? pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public UnorderedAssemblyBuilder WithMotherBoard(IMotherBoard? motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public UnorderedAssemblyBuilder WithCpu(ICpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public UnorderedAssemblyBuilder WithRams(IReadOnlyCollection<IRam>? rams)
    {
        _rams = rams == null ? new List<IRam>() : new List<IRam>(rams);
        return this;
    }

    public UnorderedAssemblyBuilder WithSsds(IReadOnlyCollection<ISsd>? ssds)
    {
        _ssds = ssds == null ? new List<ISsd>() : new List<ISsd>(ssds);
        return this;
    }

    public UnorderedAssemblyBuilder WithHdds(IReadOnlyCollection<IHdd>? hdds)
    {
        _hdds = hdds == null ? new List<IHdd>() : new List<IHdd>(hdds);
        return this;
    }

    public UnorderedAssemblyBuilder WithCooler(ICpuCooler? cpuCooler)
    {
        _cooler = cpuCooler;
        return this;
    }

    public UnorderedAssemblyBuilder WithPowerSupply(IPowerSupply? powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public UnorderedAssemblyBuilder WithGpu(IGpu? gpu)
    {
        _gpu = gpu;
        return this;
    }

    public UnorderedAssemblyBuilder WithWiFiModule(IWiFiModule? wiFiModule)
    {
        _wiFiModule = wiFiModule;
        return this;
    }

    public Order Build()
    {
        IPcCaseSelector builder = Computer.Builder;
        return builder
            .WithPcCase(_pcCase)
            .WithMotherBoard(_motherBoard)
            .WithCpu(_cpu)
            .WithRams(_rams)
            .WithSsds(_ssds)
            .WithHdds(_hdds)
            .WithCooler(_cooler)
            .WithPowerSupply(_powerSupply)
            .WithGpu(_gpu)
            .WithWiFiModule(_wiFiModule)
            .Build();
    }
}