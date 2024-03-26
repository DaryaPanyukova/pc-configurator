using PcConfigurator.Entities.Components.PcCases;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.PcCases;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxGpuSize(Dimensions maxGpuSize);
    IPcCaseBuilder WithFormFactorSupported(IReadOnlyCollection<FormFactorType> formFactorSupported);
    IPcCaseBuilder WithSize(Dimensions size);
    IPcCaseBuilder WithName(string name);
    IPcCase Build();
}