using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Ssds;

namespace PcConfigurator.Entities.Components.Ssds;

public class Ssd : ISsd
{
    public Ssd(Connection? connection, int? capacity, int? minSpeed, int? powerConsumption, string? name)
    {
        Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        MinSpeed = minSpeed ?? throw new ArgumentNullException(nameof(minSpeed));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public Connection Connection { get; private set; }

    public int Capacity { get; private set; }

    public int MinSpeed { get; private set; }

    public int PowerConsumption { get; private set; }

    public ISsdBuilder Direct()
    {
        var builder = new SsdBuilder();
        return builder
            .WithConnection(Connection)
            .WithCapacity(Capacity)
            .WithMinSpeed(MinSpeed)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}