using PcConfigurator.Entities.Components.MotherBoards;
using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.PcCases;

namespace PcConfigurator.Entities.Components.PcCases;

public class PcCase : IPcCase
{
    private readonly List<FormFactorType> _formFactorSupported;

    public PcCase(
        Dimensions? maxGpuSize,
        IReadOnlyCollection<FormFactorType>? formFactorSupported,
        Dimensions? size,
        string? name)
    {
        MaxGpuSize = maxGpuSize ?? throw new ArgumentNullException(nameof(maxGpuSize));
        _formFactorSupported = formFactorSupported == null
            ? new List<FormFactorType>()
            : new List<FormFactorType>(formFactorSupported);
        Size = size ?? throw new ArgumentNullException(nameof(size));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public Dimensions MaxGpuSize { get; private set; }
    public IReadOnlyCollection<FormFactorType> FormFactorSupported => _formFactorSupported;
    public Dimensions Size { get; private set; }

    public IPcCaseBuilder Direct()
    {
        var builder = new PcCaseBuilder();
        return builder
            .WithMaxGpuSize(MaxGpuSize)
            .WithFormFactorSupported(FormFactorSupported)
            .WithSize(Size)
            .WithName(Name);
    }

    public bool IsSupported(IMotherBoard motherBoard)
    {
        return FormFactorSupported.Contains(motherBoard.FormFactor);
    }
}