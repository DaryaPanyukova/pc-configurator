using PcConfigurator.Entities.Components.MotherBoards;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.MotherBoards;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private SocketType? _socket;
    private Dictionary<PcieType, int>? _pсieLanes;
    private int? _sataCount;
    private Sata? _sataType;
    private Chipset? _chipset;
    private DdrStandard? _ddrStandardVersion;
    private int? _ramSlotsCount;
    private FormFactorType? _formFactor;
    private Bios? _bios;
    private string? _name;
    private bool? _hasWiFiModule;

    public IMotherBoardBuilder WithSocket(SocketType socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherBoardBuilder WithPсieLanes(Dictionary<PcieType, int> pсieLanes)
    {
        _pсieLanes = pсieLanes;
        return this;
    }

    public IMotherBoardBuilder WithSataCount(int sataCount)
    {
        _sataCount = sataCount;
        return this;
    }

    public IMotherBoardBuilder WithSataType(Sata sataType)
    {
        _sataType = sataType;
        return this;
    }

    public IMotherBoardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder WithDdrStandardVersion(DdrStandard ddrStandardVersion)
    {
        _ddrStandardVersion = ddrStandardVersion;
        return this;
    }

    public IMotherBoardBuilder WithRamSlotsCount(int ramSlotsCount)
    {
        _ramSlotsCount = ramSlotsCount;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(FormFactorType formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder WithHasWiFiModule(bool hasWiFiModule = true)
    {
        _hasWiFiModule = hasWiFiModule;
        return this;
    }

    public IMotherBoard Build()
    {
        return new MotherBoard(
            _socket,
            _pсieLanes,
            _sataCount,
            _sataType,
            _chipset,
            _ddrStandardVersion,
            _ramSlotsCount,
            _formFactor,
            _bios,
            _name,
            _hasWiFiModule);
    }
}