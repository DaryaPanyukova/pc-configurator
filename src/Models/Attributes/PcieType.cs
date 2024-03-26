namespace PcConfigurator.Models.Attributes;
public sealed record PcieType : Connection
{
    public PcieType(string type)
        : base(type)
    {
    }
}