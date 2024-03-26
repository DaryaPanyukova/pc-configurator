using PcConfigurator.Entities.Components.Rams;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Rams;

public interface IRamBuilder
{
    IRamBuilder WithMemoryCount(int memoryCount);

    IRamBuilder WithJedecProfiles(IReadOnlyCollection<Profile> profiles);

    IRamBuilder WithXmpProfiles(IReadOnlyCollection<Profile> xmpProfiles);

    IRamBuilder WithFormFactor(FormFactorType formFactor);

    IRamBuilder WithStandardVersion(DdrStandard standardVersion);
    IRamBuilder WithPowerConsumption(int powerConsumption);

    IRamBuilder WithName(string name);
    IRam Build();
}