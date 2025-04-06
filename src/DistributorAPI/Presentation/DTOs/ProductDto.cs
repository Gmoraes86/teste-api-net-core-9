namespace DistributorAPI.Presentation.DTOs;

public class ProductDto
{
    public Guid Id { get; set; } // Added Id property
    public string Sku { get; set; } = string.Empty; // Renamed from Name to Sku
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
