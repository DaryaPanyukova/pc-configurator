using PcConfigurator.Models.Attributes;
using PcConfigurator.Services.Components.CpuCoolers;

namespace PcConfigurator.Entities.Components.CpuCoolers;

public class CpuCooler : ICpuCooler
{
    private readonly List<SocketType> _sockets;

    public CpuCooler(Dimensions? size, IReadOnlyCollection<SocketType>? sockets, int? maxTdp, string? name)
    {
        Size = size ?? throw new ArgumentNullException(nameof(size));
        _sockets = sockets == null ? new List<SocketType>() : new List<SocketType>(sockets);
        MaxTdp = maxTdp ?? throw new ArgumentNullException(nameof(maxTdp));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }
    public Dimensions Size { get; private set; }
    public IReadOnlyCollection<SocketType> Sockets => _sockets;
    public int MaxTdp { get; private set; }

    public bool IsSupported(SocketType socket)
    {
        return Sockets.Contains(socket);
    }

    public ICpuCoolerBuilder Direct()
    {
        var builder = new CpuCoolerBuilder();
        return builder
            .WithSize(Size)
            .WithSockets(Sockets)
            .WithMaxTdp(MaxTdp)
            .WithName(Name);
    }
}