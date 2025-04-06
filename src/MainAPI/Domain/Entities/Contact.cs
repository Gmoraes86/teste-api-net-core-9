namespace MainAPI.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid DistributorId { get; set; }
    public Distributor Distributor { get; set; } = null!;
}