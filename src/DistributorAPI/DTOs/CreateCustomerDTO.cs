using DistributorAPI.Domain.Entities;

public class CreateCustomerDTO
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required CustomerType Type { get; set; } 
}