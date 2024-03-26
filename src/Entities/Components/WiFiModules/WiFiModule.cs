using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.WiFiModules;

namespace PcConfigurator.Entities.Components.WiFiModules;

public class WiFiModule : IWiFiModule
{
    public WiFiModule(
        WiFiStandard? standardVersion,
        bool? hasBluetoothModule,
        PcieType? pcie,
        int? powerConsumption,
        string? name)
    {
        StandardVersion = standardVersion ?? throw new ArgumentNullException(nameof(standardVersion));
        HasBluetoothModule = hasBluetoothModule ?? throw new ArgumentNullException(nameof(hasBluetoothModule));
        Pcie = pcie ?? throw new ArgumentNullException(nameof(pcie));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public WiFiStandard StandardVersion { get; private set; }
    public bool HasBluetoothModule { get; private set; }
    public PcieType Pcie { get; private set; }
    public int PowerConsumption { get; private set; }

    public IWiFiModuleBuilder Direct()
    {
        var builder = new WiFiModuleBuilder();
        return builder
            .WithStandardVersion(StandardVersion)
            .WithHasBluetoothModule(HasBluetoothModule)
            .WithPcie(Pcie)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}