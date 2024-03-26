using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Rams;

namespace PcConfigurator.Entities.Components.Rams;

public class Ram : IRam
{
    private readonly List<Profile> _profiles;

    private readonly List<Profile> _xmpProfiles;

    public Ram(
        IReadOnlyCollection<Profile>? profiles,
        IReadOnlyCollection<Profile>? xmpProfiles,
        int? memoryCount,
        FormFactorType? formFactor,
        DdrStandard? standardVersion,
        int? powerConsumption,
        string? name)
    {
        _profiles = profiles == null ? new List<Profile>() : new List<Profile>(profiles);
        _xmpProfiles = xmpProfiles == null ? new List<Profile>() : new List<Profile>(xmpProfiles);
        MemoryCount = memoryCount ?? throw new ArgumentNullException(nameof(memoryCount));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        StandardVersion = standardVersion ?? throw new ArgumentNullException(nameof(standardVersion));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }

    public int MemoryCount { get; private set; }

    public IReadOnlyCollection<Profile> JedecProfiles => _profiles;

    public IReadOnlyCollection<Profile> XmpProfiles => _xmpProfiles;

    public FormFactorType FormFactor { get; private set; }

    public DdrStandard StandardVersion { get; private set; }

    public int PowerConsumption { get; private set; }

    public IRamBuilder Direct()
    {
        var builder = new RamBuilder();
        return builder
            .WithMemoryCount(MemoryCount)
            .WithJedecProfiles(JedecProfiles)
            .WithXmpProfiles(XmpProfiles)
            .WithFormFactor(FormFactor)
            .WithStandardVersion(StandardVersion)
            .WithPowerConsumption(PowerConsumption)
            .WithName(Name);
    }
}