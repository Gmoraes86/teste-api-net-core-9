namespace DistributorAPI.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Document { get; set; } = string.Empty; // Renomeado de Cnpj para Document
    public string FullName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
    public List<Order> Orders { get; set; } = new(); // Relacionamento com Order
    public CustomerType CustomerType { get; set; } = CustomerType.Corporate; // Default to Corporate
}

public enum CustomerType
{
    Personal,
    Corporate
}