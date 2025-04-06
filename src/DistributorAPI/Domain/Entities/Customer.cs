namespace DistributorAPI.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string CorporateName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
}