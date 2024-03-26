using PcConfigurator.Entities.Computers;

namespace PcConfigurator.Models.Orders;

public record Order(Computer Computer, OrderStatus Status);