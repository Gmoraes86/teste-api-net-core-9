namespace DistributorAPI.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty; // Renamed from Name to Sku
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<OrderProduct> OrderProducts { get; set; } = new(); // Relacionamento com OrderProduct
}
