namespace DistributorAPI.Presentation.DTOs;

public class CreateOrderDto
{
    public Guid CustomerId { get; set; }
    public List<ProductQuantityDto> Products { get; set; } = new();

    public bool IsValid(out string? errorMessage)
    {
        if (Products == null || Products.Count == 0)
        {
            errorMessage = "At least one product is required.";
            return false;
        }

        if (Products.Any(p => p.Quantity <= 0))
        {
            errorMessage = "Product quantities must be greater than zero.";
            return false;
        }

        errorMessage = null;
        return true;
    }
}

public class ProductQuantityDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; } = string.Empty; 
}
