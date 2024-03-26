using PcConfigurator.Entities.Components.Cpus;
using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.MotherBoards;

namespace PcConfigurator.Entities.Components.MotherBoards;

public class MotherBoard : IMotherBoard
{
    public MotherBoard(
        SocketType? socket,
        Dictionary<PcieType, int>? pcieLanes,
        int? sataCount,
        Sata? sataType,
        Chipset? chipset,
        DdrStandard? ddrStandardVersion,
        int? ramSlotsCount,
        FormFactorType? formFactor,
        Bios? bios,
        string? name,
        bool? hasWiFiModule = false)
    {
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        PcieLanes = pcieLanes ?? throw new ArgumentNullException(nameof(pcieLanes));
        SataType = sataType ?? throw new ArgumentNullException(nameof(sataType));
        SataCount = sataCount ?? throw new ArgumentNullException(nameof(sataCount));
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        DdrStandardVersion = ddrStandardVersion ?? throw new ArgumentNullException(nameof(ddrStandardVersion));
        RamSlotsCount = ramSlotsCount ?? throw new ArgumentNullException(nameof(ramSlotsCount));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        HasWiFiModule = hasWiFiModule ?? throw new ArgumentNullException(nameof(hasWiFiModule));
    }

    public string Name { get; private set; }
    public SocketType Socket { get; private set; }
    public Dictionary<PcieType, int> PcieLanes { get; private set; }
    public int SataCount { get; private set; }
    public Sata SataType { get; private set; }
    public Chipset Chipset { get; private set; }
    public DdrStandard DdrStandardVersion { get; private set; }
    public int RamSlotsCount { get; private set; }
    public FormFactorType FormFactor { get; private set; }
    public Bios Bios { get; private set; }
    public bool HasWiFiModule { get; private set; }

    public bool IsSupported(ICpu cpu)
    {
        return Socket == cpu.Socket && Bios.IsSupported(cpu);
    }

    public bool IsSupported(Profile profile)
    {
        return profile.Frequency >= Chipset.MaxFrequency;
    }

    public bool IsSupported(Connection connection)
    {
        if (connection is PcieType pcie)
        {
            return PcieLanes.GetValueOrDefault(pcie) != 0;
        }
        else
        {
            return SataCount != 0 && connection == SataType;
        }
    }

    public bool IsXmpSupported() => Chipset.XmpSupported;

    public IMotherBoardBuilder Direct()
    {
        var builder = new MotherBoardBuilder();
        return builder
            .WithSocket(Socket)
            .WithPсieLanes(PcieLanes)
            .WithSataCount(SataCount)
            .WithSataType(SataType)
            .WithChipset(Chipset)
            .WithDdrStandardVersion(DdrStandardVersion)
            .WithRamSlotsCount(RamSlotsCount)
            .WithFormFactor(FormFactor)
            .WithBios(Bios)
            .WithName(Name)
            .WithHasWiFiModule(HasWiFiModule);
    }
}