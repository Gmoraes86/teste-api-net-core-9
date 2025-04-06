namespace DistributorAPI.Domain.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderProduct> OrderProducts { get; set; } = new(); // Relacionamento com OrderProduct
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending; // Default status
}

public class OrderProduct
{
    public Guid OrderId { get; set; } // Chave estrangeira para Order
    public Order Order { get; set; } = null!;
    public Guid ProductId { get; set; } // Chave estrangeira para Product
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processed
}
