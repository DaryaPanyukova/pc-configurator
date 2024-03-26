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
using PcConfigurator.Services.Computers;

namespace PcConfigurator.Entities.Computers;

public class Computer
{
    private readonly List<IRam>? _rams;

    private readonly List<ISsd>? _ssds;

    private readonly List<IHdd>? _hdds;

    private Computer(
        IMotherBoard? motherBoard,
        ICpu? cpu,
        ICpuCooler? cooler,
        IReadOnlyCollection<IRam>? rams,
        IGpu? gpu,
        IReadOnlyCollection<ISsd>? ssds,
        IReadOnlyCollection<IHdd>? hdds,
        IPcCase? pcCase,
        IPowerSupply? powerSupply,
        IWiFiModule? wiFiModule)
    {
        MotherBoard = motherBoard;
        Cpu = cpu;
        Cooler = cooler;
        _rams = rams == null ? new List<IRam>() : new List<IRam>(rams);
        Gpu = gpu;
        _ssds = ssds == null ? new List<ISsd>() : new List<ISsd>(ssds);
        _hdds = hdds == null ? new List<IHdd>() : new List<IHdd>(hdds);
        PcCase = pcCase;
        PowerSupply = powerSupply;
        WiFiModule = wiFiModule;
    }

    public static IPcCaseSelector Builder => new OrderedAssemblyBuilder();
    public IMotherBoard? MotherBoard { get; private set; }
    public ICpu? Cpu { get; private set; }
    public ICpuCooler? Cooler { get; private set; }
    public IReadOnlyCollection<IRam>? Ram => _rams;
    public IGpu? Gpu { get; private set; }

    public IReadOnlyCollection<ISsd>? Ssd => _ssds;
    public IReadOnlyCollection<IHdd>? Hdd => _hdds;
    public IPcCase? PcCase { get; private set; }
    public IPowerSupply? PowerSupply { get; private set; }
    public IWiFiModule? WiFiModule { get; private set; }

    public UnorderedAssemblyBuilder Direct()
    {
        var builder = new UnorderedAssemblyBuilder();
        return builder
            .WithMotherBoard(MotherBoard)
            .WithCpu(Cpu)
            .WithCooler(Cooler)
            .WithRams(_rams)
            .WithGpu(Gpu)
            .WithSsds(_ssds)
            .WithHdds(_hdds)
            .WithPcCase(PcCase)
            .WithPowerSupply(PowerSupply)
            .WithWiFiModule(WiFiModule);
    }

    private class OrderedAssemblyBuilder : IComputerSelector, IPcCaseSelector, IMotherBoardSelector, ICpuSelector,
        IRamSelector, ISsdSelector, IHddSelector, ICpuCoolerSelector, IPowerSupplySelector
    {
        private IMotherBoard? _motherBoard;
        private ICpu? _cpu;
        private IGpu? _gpu;
        private ICpuCooler? _cooler;
        private List<IRam>? _rams;
        private List<ISsd>? _ssds;
        private List<IHdd>? _hdds;
        private IPcCase? _pcCase;
        private IPowerSupply? _powerSupply;
        private IWiFiModule? _wiFiModule;
        private OrderStatus _status = new OrderStatus.Success();

        public IMotherBoardSelector WithPcCase(IPcCase? pcCase)
        {
            if (pcCase == null)
            {
                _status = new OrderStatus.Fail("Case required");
                return this;
            }

            _pcCase = pcCase;
            return this;
        }

        public ICpuSelector WithMotherBoard(IMotherBoard? motherBoard)
        {
            _motherBoard = motherBoard;

            if (_status is not OrderStatus.Success || _pcCase == null)
            {
                return this;
            }

            if (motherBoard == null)
            {
                _status = new OrderStatus.Fail("Motherboard required");
                return this;
            }

            if (!_pcCase.IsSupported(motherBoard))
            {
                _status = new OrderStatus.Fail("The case does not support form factor of the motherboard");
            }

            return this;
        }

        public IRamSelector WithCpu(ICpu? cpu)
        {
            _cpu = cpu;
            if (_status is not OrderStatus.Success || _motherBoard == null)
            {
                return this;
            }

            if (_cpu == null)
            {
                _status = new OrderStatus.Fail("Cpu required");
                return this;
            }

            if (!_motherBoard.IsSupported(_cpu))
            {
                _status = new OrderStatus.Fail("CPU is not supported by motherboard");
            }

            return this;
        }

        public ISsdSelector WithRams(IReadOnlyCollection<IRam>? rams)
        {
            _rams = rams == null ? new List<IRam>() : new List<IRam>(rams);
            if (_status is not OrderStatus.Success || _motherBoard == null || _cpu == null)
            {
                return this;
            }

            if (_rams.Count == 0)
            {
                _status = new OrderStatus.Fail("RAM required");
                return this;
            }

            if (_rams.Count > _motherBoard.RamSlotsCount)
            {
                _status = new OrderStatus.Fail("Motherboard does not have enough slots for RAMs");
                return this;
            }

            foreach (IRam curRam in _rams)
            {
                if (curRam.StandardVersion != _motherBoard.DdrStandardVersion)
                {
                    _status = new OrderStatus.Fail("The motherboard does not support DDR version of RAM");
                    return this;
                }

                bool profileFound = curRam.JedecProfiles.Any(jedec => _motherBoard.IsSupported(jedec))
                                    || (_motherBoard.IsXmpSupported() && curRam.XmpProfiles.Any(xmp =>
                                        _motherBoard.IsSupported(xmp) && xmp.Frequency <= _cpu.MaxMemoryFrequency));

                if (!profileFound)
                {
                    _status = new OrderStatus.Fail("no supported XMP or JEDEC found ");
                    return this;
                }
            }

            return this;
        }

        public IHddSelector WithSsds(IReadOnlyCollection<ISsd>? ssds)
        {
            _ssds = ssds == null ? new List<ISsd>() : new List<ISsd>(ssds);
            if (_status is not OrderStatus.Success || _motherBoard == null)
            {
                return this;
            }

            if (_ssds.Any(ssd => !_motherBoard.IsSupported(ssd.Connection)))
            {
                _status = new OrderStatus.Fail("Unable to connect SSD with motherboard");
            }

            return this;
        }

        public ICpuCoolerSelector WithHdds(IReadOnlyCollection<IHdd>? hdds)
        {
            _hdds = hdds == null ? new List<IHdd>() : new List<IHdd>(hdds);
            if (_status is not OrderStatus.Success || _motherBoard == null)
            {
                return this;
            }

            if (_hdds.Count == 0 && (_ssds == null || _ssds.Count == 0))
            {
                _status = new OrderStatus.Fail("Computer must have an SSD or HDD");
                return this;
            }

            if (_hdds.Any(hdd => !_motherBoard.IsSupported(hdd.SataType)))
            {
                _status = new OrderStatus.Fail("Unable to connect HDD with motherboard");
            }

            return this;
        }

        public IPowerSupplySelector WithCooler(ICpuCooler? cpuCooler)
        {
            _cooler = cpuCooler;
            if (_status is not OrderStatus.Success || _cpu == null || _pcCase == null)
            {
                return this;
            }

            if (_cooler == null)
            {
                _status = new OrderStatus.Fail("Computer must have a cooler");
                return this;
            }

            if (!_cooler.IsSupported(_cpu.Socket))
            {
                _status = new OrderStatus.Fail("The cooler can not be connected to CPU");
                return this;
            }

            if (_cooler.MaxTdp < _cpu.Tdp)
            {
                _status = new OrderStatus.Success.WarrantiesDisclaimer();
            }

            if (_cooler.Size.Depth > _pcCase.Size.Width)
            {
                _status = new OrderStatus.Fail("Cooler with smaller size required for this computer case");
                return this;
            }

            return this;
        }

        public IComputerSelector WithPowerSupply(IPowerSupply? powerSupply)
        {
            _powerSupply = powerSupply;
            if (_status is not OrderStatus.Success)
            {
                return this;
            }

            if (_powerSupply == null)
            {
                _status = new OrderStatus.Fail("Computer must have a power supply");
            }

            return this;
        }

        public IComputerSelector WithGpu(IGpu? gpu)
        {
            _gpu = gpu;
            if (_gpu == null)
            {
                return this;
            }

            if (_status is not OrderStatus.Success || _motherBoard == null || _pcCase == null)
            {
                return this;
            }

            if (_gpu.Size.Height > _pcCase.Size.Height)
            {
                _status = new OrderStatus.Fail("GPU with smaller size required for this computer case");
            }

            return this;
        }

        public IComputerSelector WithWiFiModule(IWiFiModule? wiFiModule)
        {
            _wiFiModule = wiFiModule;
            if (_wiFiModule == null)
            {
                return this;
            }

            if (_status is not OrderStatus.Success || _motherBoard == null)
            {
                return this;
            }

            if (!_motherBoard.IsSupported(_wiFiModule.Pcie) || _motherBoard.HasWiFiModule)
            {
                _status = new OrderStatus.Fail("Unable to connect WiFI module to motherboard");
            }

            return this;
        }

        public Order Build()
        {
            if (_status is OrderStatus.Success)
            {
                if (_cpu is { HasVideoCore: false } && _gpu is null)
                {
                    _status = new OrderStatus.Fail("GPU required");
                }
                else
                {
                    int sumPowerConsumption = (_cpu?.PowerConsumption ?? 0) + (_gpu?.PowerConsumption ?? 0) +
                                              (_wiFiModule?.PowerConsumption ?? 0) +
                                              (_ssds?.Sum(ssd => ssd.PowerConsumption) ?? 0) +
                                              (_hdds?.Sum(hdd => hdd.PowerConsumption) ?? 0) +
                                              (_rams?.Sum(ram => ram.PowerConsumption) ?? 0);
                    if (sumPowerConsumption > (_powerSupply?.MaxWattage ?? 0))
                    {
                        _status = new OrderStatus.Fail("Higher rating power supply required");
                    }
                    else if (sumPowerConsumption > (_powerSupply?.RecommendedWattage ?? 0))
                    {
                        _status = new OrderStatus.Success.СapacityNonСompliance();
                    }
                }
            }

            var computer = new Computer(
                _motherBoard,
                _cpu,
                _cooler,
                _rams,
                _gpu,
                _ssds,
                _hdds,
                _pcCase,
                _powerSupply,
                _wiFiModule);
            return new Order(computer, _status);
        }
    }
}