using PcConfigurator.Entities.Components.Rams;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Rams;

public class RamBuilder : IRamBuilder
{
    private int? _memoryCount;
    private List<Profile>? _profiles;
    private List<Profile>? _xmpProfiles;
    private FormFactorType? _formFactor;
    private DdrStandard? _standardVersion;
    private int? _powerConsumption;
    private string? _name;

    public IRamBuilder WithMemoryCount(int memoryCount)
    {
        _memoryCount = memoryCount;
        return this;
    }

    public IRamBuilder WithJedecProfiles(IReadOnlyCollection<Profile> profiles)
    {
        _profiles = new List<Profile>(profiles);
        return this;
    }

    public IRamBuilder WithXmpProfiles(IReadOnlyCollection<Profile> xmpProfiles)
    {
        _xmpProfiles = new List<Profile>(xmpProfiles);
        return this;
    }

    public IRamBuilder WithFormFactor(FormFactorType formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithStandardVersion(DdrStandard standardVersion)
    {
        _standardVersion = standardVersion;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRam Build()
    {
        return new Ram(_profiles, _xmpProfiles, _memoryCount, _formFactor, _standardVersion, _powerConsumption, _name);
    }
}