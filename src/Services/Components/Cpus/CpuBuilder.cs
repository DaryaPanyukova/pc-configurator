using PcConfigurator.Entities.Components.Cpus;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.Cpus;

public class CpuBuilder : ICpuBuilder
{
    private int? _coreFrequency;
    private int? _coreCount;
    private SocketType? _socket;
    private bool? _hasVideoCore;
    private int? _maxMemoryFrequency;
    private int? _tdp;
    private int? _powerConsumption;
    private string? _name;

    public ICpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;
        return this;
    }

    public ICpuBuilder WithSocket(SocketType socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithHasVideoCore(bool hasVideoCore)
    {
        _hasVideoCore = hasVideoCore;
        return this;
    }

    public ICpuBuilder WithMaxMemoryFrequency(int maxMemoryFrequency)
    {
        _maxMemoryFrequency = maxMemoryFrequency;
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpu Build()
    {
        return new Cpu(
            _coreFrequency,
            _coreCount,
            _socket,
            _hasVideoCore,
            _maxMemoryFrequency,
            _tdp,
            _powerConsumption,
            _name);
    }
}