using PcConfigurator.Entities.Components.PcCases;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.PcCases;

public class PcCaseBuilder : IPcCaseBuilder
{
    private Dimensions? _maxGpuSize;
    private IReadOnlyCollection<FormFactorType>? _formFactorSupported;
    private Dimensions? _size;
    private string? _name;

    public IPcCaseBuilder WithMaxGpuSize(Dimensions maxGpuSize)
    {
        _maxGpuSize = maxGpuSize;
        return this;
    }

    public IPcCaseBuilder WithFormFactorSupported(IReadOnlyCollection<FormFactorType> formFactorSupported)
    {
        _formFactorSupported = formFactorSupported;
        return this;
    }

    public IPcCaseBuilder WithSize(Dimensions size)
    {
        _size = size;
        return this;
    }

    public IPcCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPcCase Build()
    {
        return new PcCase(_maxGpuSize, _formFactorSupported, _size, _name);
    }
}