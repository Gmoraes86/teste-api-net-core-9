using DistributorAPI.Domain.Entities;


public class CreateCustomerDTO
{
    public string Name { get; set; }
    public string Document { get; set; }
    public CustomerType Type { get; set; } 
}