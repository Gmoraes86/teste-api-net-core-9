namespace MainAPI.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public string Addressinfo { get; set; } = string.Empty;
    public bool isMain { get; set; }
    public int DistributorId { get; set; }
    public Distributor Distributor { get; set; } = null!;
}