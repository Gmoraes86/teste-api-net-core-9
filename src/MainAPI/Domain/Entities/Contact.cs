namespace MainAPI.Domain.Entities;

public class Contact
{
    public int Guid { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DistributorId { get; set; }
    public Distributor Distributor { get; set; } = null!;
}