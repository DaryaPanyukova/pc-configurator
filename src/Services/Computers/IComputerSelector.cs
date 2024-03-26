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
using PcConfigurator.Models.Orders;

namespace PcConfigurator.Services.Computers;

public interface IComputerSelector
{
    IComputerSelector WithGpu(IGpu? gpu);
    IComputerSelector WithWiFiModule(IWiFiModule? wiFiModule);
    Order Build();
}

public interface IPcCaseSelector
{
    IMotherBoardSelector WithPcCase(IPcCase? pcCase);
}

public interface IMotherBoardSelector
{
    ICpuSelector WithMotherBoard(IMotherBoard? motherBoard);
}

public interface ICpuSelector
{
    IRamSelector WithCpu(ICpu? cpu);
}

public interface IRamSelector
{
    ISsdSelector WithRams(IReadOnlyCollection<IRam>? ram);
}

public interface ISsdSelector
{
    IHddSelector WithSsds(IReadOnlyCollection<ISsd>? ssd);
}

public interface IHddSelector
{
    ICpuCoolerSelector WithHdds(IReadOnlyCollection<IHdd>? hdd);
}

public interface ICpuCoolerSelector
{
    IPowerSupplySelector WithCooler(ICpuCooler? cpuCooler);
}

public interface IPowerSupplySelector
{
    IComputerSelector WithPowerSupply(IPowerSupply? powerSupply);
}