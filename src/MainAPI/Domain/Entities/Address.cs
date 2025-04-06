namespace MainAPI.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string Addressinfo { get; set; } = string.Empty;
    public bool isMain { get; set; }
    public Guid DistributorId { get; set; }
    public Distributor Distributor { get; set; } = null!;
}