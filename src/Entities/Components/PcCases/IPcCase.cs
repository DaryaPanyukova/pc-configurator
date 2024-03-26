using PcConfigurator.Entities.Components.MotherBoards;
using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.PcCases;

namespace PcConfigurator.Entities.Components.PcCases;

public interface IPcCase : IPcCaseDirector, IComponent
{
    Dimensions MaxGpuSize { get; }
    IReadOnlyCollection<FormFactorType> FormFactorSupported { get; }
    Dimensions Size { get; }

    bool IsSupported(IMotherBoard motherBoard);
}