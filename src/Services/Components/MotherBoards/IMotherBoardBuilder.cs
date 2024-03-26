using PcConfigurator.Entities.Components.MotherBoards;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.MotherBoards;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithSocket(SocketType socket);
    IMotherBoardBuilder WithPсieLanes(Dictionary<PcieType, int> pсieLanes);
    IMotherBoardBuilder WithSataCount(int sataCount);
    IMotherBoardBuilder WithSataType(Sata sataType);
    IMotherBoardBuilder WithChipset(Chipset chipset);
    IMotherBoardBuilder WithDdrStandardVersion(DdrStandard ddrStandardVersion);
    IMotherBoardBuilder WithRamSlotsCount(int ramSlotsCount);
    IMotherBoardBuilder WithFormFactor(FormFactorType formFactor);
    IMotherBoardBuilder WithBios(Bios bios);
    IMotherBoardBuilder WithName(string name);
    IMotherBoardBuilder WithHasWiFiModule(bool hasWiFiModule = true);

    IMotherBoard Build();
}