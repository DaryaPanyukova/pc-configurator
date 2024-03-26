using PcConfigurator.Entities.Components.Cpus;
using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.MotherBoards;

namespace PcConfigurator.Entities.Components.MotherBoards;

public interface IMotherBoard : IMotherBoardDirector, IComponent
{
    SocketType Socket { get; }
    Dictionary<PcieType, int> PcieLanes { get; }

    int SataCount { get; }
    Sata SataType { get; }
    Chipset Chipset { get; }
    DdrStandard DdrStandardVersion { get; }
    int RamSlotsCount { get; }
    FormFactorType FormFactor { get; }
    Bios Bios { get; }
    bool HasWiFiModule { get; }

    bool IsSupported(ICpu cpu);

    bool IsSupported(Profile profile);
    bool IsSupported(Connection connection);
    bool IsXmpSupported();
}