namespace PcConfigurator.Models.Attributes;

public sealed record Sata : Connection
{
    public Sata(string type)
        : base(type)
    {
    }
}