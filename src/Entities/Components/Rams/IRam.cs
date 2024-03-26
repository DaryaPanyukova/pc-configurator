using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.Rams;

namespace PcConfigurator.Entities.Components.Rams;

public interface IRam : IRamDirector, IComponent
{
    int MemoryCount { get; }

    IReadOnlyCollection<Profile> JedecProfiles { get; }

    IReadOnlyCollection<Profile> XmpProfiles { get; }

    FormFactorType FormFactor { get; }

    DdrStandard StandardVersion { get; }

    int PowerConsumption { get; }
}