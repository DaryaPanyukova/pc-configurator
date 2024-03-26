using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.WiFiModules;

namespace PcConfigurator.Entities.Components.WiFiModules;

public interface IWiFiModule : IWiFiModuleDirector, IComponent
{
    WiFiStandard StandardVersion { get; }
    bool HasBluetoothModule { get; }
    PcieType Pcie { get; }
    int PowerConsumption { get; }
}