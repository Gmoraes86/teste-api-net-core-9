namespace DistributorAPI.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string Addressinfo { get; set; } = string.Empty;
    public bool isMain { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}