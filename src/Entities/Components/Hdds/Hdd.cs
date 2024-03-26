using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Hdds;

namespace PcConfigurator.Entities.Components.Hdds;

public class Hdd : IHdd
{
    public Hdd(int? capacity, int? speed, int? powerConsumption, Sata? sataType, string? name)
    {
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        Speed = speed ?? throw new ArgumentNullException(nameof(speed));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        SataType = sataType ?? throw new ArgumentNullException(nameof(sataType));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public int Capacity { get; private set; }
    public int Speed { get; private set; }
    public int PowerConsumption { get; private set; }

    public Sata SataType { get; private set; }

    public IHddBuilder Direct()
    {
        var builder = new HddBuilder();
        return builder
            .WithCapacity(Capacity)
            .WithSpeed(Speed)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}