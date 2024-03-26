using PcConfigurator.Entities.Components.WiFiModules;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.WiFiModules;

public interface IWiFiModuleBuilder
{
    IWiFiModuleBuilder WithStandardVersion(WiFiStandard standardVersion);
    IWiFiModuleBuilder WithHasBluetoothModule(bool hasBluetoothModule);
    IWiFiModuleBuilder WithPcie(PcieType pcie);
    IWiFiModuleBuilder WithPowerConsumption(int powerConsumption);
    IWiFiModuleBuilder WithName(string name);
    IWiFiModule Build();
}