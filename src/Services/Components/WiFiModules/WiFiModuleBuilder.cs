using PcConfigurator.Entities.Components.WiFiModules;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.WiFiModules;

public class WiFiModuleBuilder : IWiFiModuleBuilder
{
    private WiFiStandard? _standardVersion;
    private bool? _hasBluetoothModule;
    private PcieType? _pcie;
    private int? _powerConsumption;
    private string? _name;

    public IWiFiModuleBuilder WithStandardVersion(WiFiStandard standardVersion)
    {
        _standardVersion = standardVersion;
        return this;
    }

    public IWiFiModuleBuilder WithHasBluetoothModule(bool hasBluetoothModule)
    {
        _hasBluetoothModule = hasBluetoothModule;
        return this;
    }

    public IWiFiModuleBuilder WithPcie(PcieType pcie)
    {
        _pcie = pcie;
        return this;
    }

    public IWiFiModuleBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IWiFiModuleBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiModule Build()
    {
        return new WiFiModule(_standardVersion, _hasBluetoothModule, _pcie, _powerConsumption, _name);
    }
}