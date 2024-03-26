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
using PcConfigurator.Services.Factories;

namespace PcConfigurator.Services;

public class Shop
{
    public Shop(ComputerDetailsFactory factory)
    {
        Factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public ComputerDetailsFactory Factory { get; private set; }

    public Order MakeOrder(Specification specification)
    {
        if (specification == null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        ICpuCooler? cpuCooler = Factory.GetCpuCoolerByName(specification.CpuCoolerName);
        ICpu? cpu = Factory.GetCpuByName(specification.CpuName);
        IGpu? gpu = Factory.GetGpuByName(specification.GpuName);

        var hdds = new List<IHdd>();
        if (specification.Hdds != null)
        {
            foreach (string? name in specification.Hdds)
            {
                IHdd? hdd = Factory.GetHddByName(name);
                if (hdd != null)
                {
                    hdds.Add(hdd);
                }
            }
        }

        IMotherBoard? motherBoard = Factory.GetMotherBoardByName(specification.MotherBoardName);
        IPcCase? pcCase = Factory.GetPcCaseByName(specification.PcCaseName);
        IPowerSupply? powerSupply = Factory.GetPowerSupplyByName(specification.PowerSupplyName);

        var rams = new List<IRam>();
        if (specification.RamSticks != null)
        {
            foreach (string? name in specification.RamSticks)
            {
                IRam? ram = Factory.GetRamByName(name);
                if (ram != null)
                {
                    rams.Add(ram);
                }
            }
        }

        var ssds = new List<ISsd>();
        if (specification.Ssds != null)
        {
            foreach (string? name in specification.Ssds)
            {
                ISsd? ssd = Factory.GetSsdByName(name);
                if (ssd != null)
                {
                    ssds.Add(ssd);
                }
            }
        }

        IWiFiModule? wiFiModule = Factory.GetWiFiModuleByName(specification.WiFiModulesName);

        return Computer.Builder
            .WithPcCase(pcCase)
            .WithMotherBoard(motherBoard)
            .WithCpu(cpu)
            .WithRams(rams)
            .WithSsds(ssds)
            .WithHdds(hdds)
            .WithCooler(cpuCooler)
            .WithPowerSupply(powerSupply)
            .WithWiFiModule(wiFiModule)
            .WithGpu(gpu)
            .Build();
    }
}