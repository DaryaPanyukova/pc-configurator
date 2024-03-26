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

namespace PcConfigurator.Services.Factories;

public class ComputerDetailsFactory
{
    private readonly IFactory<ICpuCooler> _cpuCoolerFactory;
    private readonly IFactory<ICpu> _cpuFactory;
    private readonly IFactory<IGpu> _gpuFactory;
    private readonly IFactory<IHdd> _hddFactory;
    private readonly IFactory<IMotherBoard> _motherBoardFactory;
    private readonly IFactory<IPcCase> _pcCaseFactory;
    private readonly IFactory<IPowerSupply> _powerSupplyFactory;
    private readonly IFactory<IRam> _ramFactory;
    private readonly IFactory<ISsd> _ssdFactory;
    private readonly IFactory<IWiFiModule> _wiFiModuleFactory;

    public ComputerDetailsFactory(
        IFactory<ICpuCooler> cpuCoolerFactory,
        IFactory<ICpu> cpuFactory,
        IFactory<IGpu> gpuFactory,
        IFactory<IHdd> hddFactory,
        IFactory<IMotherBoard> motherBoardFactory,
        IFactory<IPcCase> pcCaseFactory,
        IFactory<IPowerSupply> powerSupplyFactory,
        IFactory<IRam> ramFactory,
        IFactory<ISsd> ssdFactory,
        IFactory<IWiFiModule> wiFiModuleFactory)
    {
        _cpuCoolerFactory = cpuCoolerFactory;
        _cpuFactory = cpuFactory;
        _gpuFactory = gpuFactory;
        _hddFactory = hddFactory;
        _motherBoardFactory = motherBoardFactory;
        _pcCaseFactory = pcCaseFactory;
        _powerSupplyFactory = powerSupplyFactory;
        _ramFactory = ramFactory;
        _ssdFactory = ssdFactory;
        _wiFiModuleFactory = wiFiModuleFactory;
    }

    public ICpuCooler? GetCpuCoolerByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _cpuCoolerFactory.GetByName(name);
    }

    public ICpu? GetCpuByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _cpuFactory.GetByName(name);
    }

    public IGpu? GetGpuByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _gpuFactory.GetByName(name);
    }

    public IHdd? GetHddByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _hddFactory.GetByName(name);
    }

    public IMotherBoard? GetMotherBoardByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _motherBoardFactory.GetByName(name);
    }

    public IPcCase? GetPcCaseByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _pcCaseFactory.GetByName(name);
    }

    public IPowerSupply? GetPowerSupplyByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _powerSupplyFactory.GetByName(name);
    }

    public IRam? GetRamByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _ramFactory.GetByName(name);
    }

    public ISsd? GetSsdByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _ssdFactory.GetByName(name);
    }

    public IWiFiModule? GetWiFiModuleByName(string? name)
    {
        if (name == null)
        {
            return null;
        }

        return _wiFiModuleFactory.GetByName(name);
    }
}