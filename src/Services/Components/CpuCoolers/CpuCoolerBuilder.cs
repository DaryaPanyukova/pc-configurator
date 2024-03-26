using PcConfigurator.Entities.Components.CpuCoolers;
using PcConfigurator.Models.Attributes;

namespace PcConfigurator.Services.Components.CpuCoolers;

public class CpuCoolerBuilder : ICpuCoolerBuilder
{
    private Dimensions? _size;
    private IReadOnlyCollection<SocketType>? _sockets;
    private int? _maxTdp;
    private string? _name;

    public ICpuCoolerBuilder WithSize(Dimensions size)
    {
        _size = size;
        return this;
    }

    public ICpuCoolerBuilder WithSockets(IReadOnlyCollection<SocketType> sockets)
    {
        _sockets = sockets;
        return this;
    }

    public ICpuCoolerBuilder WithMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public ICpuCoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuCooler Build()
    {
        return new CpuCooler(_size, _sockets, _maxTdp, _name);
    }
}