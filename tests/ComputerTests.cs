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
using PcConfigurator.Models.Attributes;
using PcConfigurator.Models.Orders;
using PcConfigurator.Services;
using PcConfigurator.Services.Factories;
using Xunit;

namespace PcConfigurator.Tests;

public class ComputerTests
{
    private readonly Shop _shop;

    public ComputerTests()
    {
        // coolers
        var socketTypes1 = new List<SocketType> { new SocketType("LGA 1700"), new SocketType("SP3") };
        ICpuCooler cooler1 = new CpuCooler(
            new Dimensions(200, 120, 87),
            socketTypes1.AsReadOnly(),
            150,
            "Master nr200p");

        var socketTypes2 = new List<SocketType> { new SocketType("LGA 1178"), new SocketType("SP3") };
        ICpuCooler cooler2 = new CpuCooler(
            new Dimensions(210, 100, 74),
            socketTypes2.AsReadOnly(),
            300,
            "Txii3 ms230xx");
        var cpuCoolerFactory = new ComponentFactory<ICpuCooler>(new List<ICpuCooler> { cooler1, cooler2 });

        // cpu
        ICpu cpu1 = new Cpu(3800, 4, new SocketType("LGA 1178"), true, 1866, 95, 100, "AMD FX-4300");
        ICpu cpu2 = new Cpu(2900, 2, new SocketType("SP3"), false, 1500, 170, 170, "Intel Core i5-12400F");
        ICpu cpu3 = new Cpu(2343, 3, new SocketType("LGA 1178"), false, 1665, 100, 170, "AMD iF-2344");
        var cpuFactory = new ComponentFactory<ICpu>(new List<ICpu> { cpu1, cpu2, cpu3 });

        // gpu
        IGpu gpu1 = new Gpu(
            new Dimensions(168, 70, 27),
            1024,
            new PcieType("PCI-E x16"),
            520,
            65,
            "KFA2 GeForce 210");

        IGpu gpu2 = new Gpu(
            new Dimensions(190, 80, 25),
            1536,
            new PcieType("PCI-E x16"),
            500,
            80,
            "NVIDIA GeForce RTX 4060 Ti");
        var gpuFactory = new ComponentFactory<IGpu>(new List<IGpu> { gpu1, gpu2 });

        // hdd
        IHdd hdd1 = new Hdd(2000000, 7200, 37, new Sata("SATA III"), "ST2000DM008");
        IHdd hdd2 = new Hdd(1000000, 7200, 68, new Sata("SATA III"), "WD10EZEX");
        var hddFactory = new ComponentFactory<IHdd>(new List<IHdd> { hdd1, hdd2 });

        // motherboard
        IMotherBoard motherBoard1 = new MotherBoard(
            new SocketType("SP3"),
            new Dictionary<PcieType, int> { { new PcieType("PCI-E x16"), 2 }, { new PcieType("PCI-E x8"), 4 } },
            8,
            new Sata("SATA III"),
            new Chipset(400, true),
            new DdrStandard("DDR3"),
            2,
            new FormFactorType("Micro-ATX"),
            new Bios("RBXA", "xxwe53i", new List<string> { "AMD FX-4300", "Intel Core i5-12400F" }),
            "AFOX A88-MA5");

        IMotherBoard motherBoard2 = new MotherBoard(
            new SocketType("LGA 1178"),
            new Dictionary<PcieType, int>
            {
                { new PcieType("PCI-E x16"), 2 }, { new PcieType("PCI-E x8"), 2 }, { new PcieType("PCI-E x4"), 8 },
                { new PcieType("PCI-E x2"), 2 },
            },
            4,
            new Sata("SATA III"),
            new Chipset(480, true),
            new DdrStandard("DDR3"),
            1,
            new FormFactorType("Micro-ATX"),
            new Bios("RBXA", "xxwe53i", new List<string> { "AMD FX-4300", "Intel Core i5-12400F" }),
            "AFOX IG41-MA7",
            true);

        IMotherBoard motherBoard3 = new MotherBoard(
            new SocketType("SP3"),
            new Dictionary<PcieType, int>
                { { new PcieType("PCI-E x16"), 2 }, { new PcieType("PCI-E x8"), 4 }, { new PcieType("PCI-E x2"), 8 } },
            4,
            new Sata("SATA III"),
            new Chipset(480, true),
            new DdrStandard("DDR3"),
            1,
            new FormFactorType("Standard-ATX"),
            new Bios("RBXA", "c77", new List<string> { "AMD FX-4300", "Intel Core i5-12400F" }),
            "AF54X J774T-MSx");
        var motherBoardFactory = new ComponentFactory<IMotherBoard>(new List<IMotherBoard>
            { motherBoard1, motherBoard2, motherBoard3 });

        // pcCase
        IPcCase pcCase1 = new PcCase(
            new Dimensions(300, 100, 30),
            new List<FormFactorType> { new FormFactorType("Micro-ATX"), new FormFactorType("Standard-ATX") },
            new Dimensions(325, 175, 405),
            "DEXP DC-302R");

        IPcCase pcCase2 = new PcCase(
            new Dimensions(400, 150, 40),
            new List<FormFactorType> { new FormFactorType("Micro-ATX"), new FormFactorType("Mini-ITX") },
            new Dimensions(270, 150, 405),
            "DEXP DC-201M");
        var pcCaseFactory = new ComponentFactory<IPcCase>(new List<IPcCase> { pcCase1, pcCase2 });

        // Power supply
        IPowerSupply powerSupply1 = new PowerSupply(450, 250, "Super Power Winard 450WA");
        IPowerSupply powerSupply2 = new PowerSupply(500, 460, "EX219185RUS");
        var powerSupplyFactory =
            new ComponentFactory<IPowerSupply>(new List<IPowerSupply> { powerSupply1, powerSupply2 });

        // RAM
        IRam ram1 = new Ram(
            new List<Profile> { new Profile(120, 1037, new Timing(18, 18, 36, 54)) },
            new List<Profile> { new Profile(135, 1600, new Timing(16, 18, 35, 49)) },
            4096,
            new FormFactorType("DIMM"),
            new DdrStandard("DDR3"),
            15,
            "AGI160004UD128");

        IRam ram2 = new Ram(
            new List<Profile> { new Profile(115, 1030, new Timing(16, 18, 36, 54)) },
            new List<Profile> { new Profile(135, 1550, new Timing(16, 16, 46, 64)) },
            4096,
            new FormFactorType("DIMM"),
            new DdrStandard("DDR3"),
            15,
            "DL.04G2K.KAM");
        var ramFactory = new ComponentFactory<IRam>(new List<IRam> { ram1, ram2 });

        // SSD
        ISsd ssd1 = new Ssd(new PcieType("PCI-E x2"), 491520, 450, 15, "SA400S37");
        ISsd ssd2 = new Ssd(new PcieType("PCI-E x4"), 1024000, 530, 4, "77E1T0BW");
        var ssdFactory = new ComponentFactory<ISsd>(new List<ISsd> { ssd1, ssd2 });

        // WiFi Modules
        IWiFiModule wiFiModule1 =
            new WiFiModule(new WiFiStandard("4"), false, new PcieType("PCI-E x1"), 4, "DEXP WFA-152");
        IWiFiModule wiFiModule2 =
            new WiFiModule(new WiFiStandard("3.0"), true, new PcieType("PCI-E x2"), 4, "DFG ITRR-6Ts");
        var wiFiModuleFactory = new ComponentFactory<IWiFiModule>(new List<IWiFiModule> { wiFiModule1, wiFiModule2 });

        // Factory
        var factory = new ComputerDetailsFactory(
            cpuCoolerFactory,
            cpuFactory,
            gpuFactory,
            hddFactory,
            motherBoardFactory,
            pcCaseFactory,
            powerSupplyFactory,
            ramFactory,
            ssdFactory,
            wiFiModuleFactory);
        _shop = new Shop(factory);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.Test1), MemberType = typeof(TestDataGenerator))]
    public void AssemblyTest(Specification specification, OrderStatus correctResult)
    {
        Order order = _shop.MakeOrder(specification);
        Assert.Equal(correctResult, order.Status);
    }

    [Fact]
    public void ChangePowerSupplyTest()
    {
        var specification = new Specification(
            cpuCoolerName: "Txii3 ms230xx",
            cpuName: "AMD FX-4300",
            gpuName: "KFA2 GeForce 210",
            hdds: new List<string> { "WD10EZEX" },
            motherBoardName: "AFOX IG41-MA7",
            pcCaseName: "DEXP DC-302R",
            powerSupplyName: "Super Power Winard 450WA",
            ramSticks: new List<string> { "AGI160004UD128" },
            ssds: new List<string> { "SA400S37" },
            wiFiModulesName: null);
        Order order = _shop.MakeOrder(specification);
        IPowerSupply? newPowerSupply = _shop.Factory.GetPowerSupplyByName("EX219185RUS");
        order = order.Computer.Direct().WithPowerSupply(newPowerSupply).Build();
        Assert.Equal(new OrderStatus.Success(), order.Status);
    }

    [Fact]
    public void ChangeWiFiModuleTest()
    {
        var specification = new Specification(
            cpuCoolerName: "Txii3 ms230xx",
            cpuName: "AMD FX-4300",
            gpuName: "KFA2 GeForce 210",
            hdds: new List<string> { "WD10EZEX" },
            motherBoardName: "AFOX IG41-MA7",
            pcCaseName: "DEXP DC-302R",
            powerSupplyName: "EX219185RUS",
            ramSticks: new List<string> { "AGI160004UD128" },
            ssds: new List<string> { "SA400S37" },
            wiFiModulesName: null);
        Order order = _shop.MakeOrder(specification);

        IWiFiModule? wiFiModule = _shop.Factory.GetWiFiModuleByName("DFG ITRR-6Ts");
        order = order.Computer.Direct().WithWiFiModule(wiFiModule).Build();
        Assert.Equal(new OrderStatus.Fail("Unable to connect WiFI module to motherboard"), order.Status);
    }

    [Fact]
    public void UpdateBiosTest()
    {
        var specification = new Specification(
            cpuCoolerName: "Txii3 ms230xx",
            cpuName: "AMD iF-2344",
            gpuName: "KFA2 GeForce 210",
            hdds: new List<string> { "WD10EZEX" },
            motherBoardName: "AFOX IG41-MA7",
            pcCaseName: "DEXP DC-302R",
            powerSupplyName: "EX219185RUS",
            ramSticks: new List<string> { "AGI160004UD128" },
            ssds: new List<string> { "SA400S37" },
            wiFiModulesName: null);
        Order order = _shop.MakeOrder(specification);

        IMotherBoard? motherBoard = order.Computer.MotherBoard;
        var newBios = new Bios("ERYG", "y56", new List<string> { "AMD iF-2344", "Intel Core i5-12400F" });
        motherBoard = motherBoard?.Direct().WithBios(newBios).Build();

        order = order.Computer.Direct().WithMotherBoard(motherBoard).Build();
        Assert.Equal(new OrderStatus.Success(), order.Status);
    }
}