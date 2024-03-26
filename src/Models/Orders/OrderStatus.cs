namespace PcConfigurator.Models.Orders;

public abstract record OrderStatus
{
    public record Success : OrderStatus
    {
        public sealed record WarrantiesDisclaimer : Success; // отказ от гарантии

        public sealed record СapacityNonСompliance : Success; // несоблюдение рекомендуемых мощностей
    }

    public sealed record Fail(string Reason) : OrderStatus;
}