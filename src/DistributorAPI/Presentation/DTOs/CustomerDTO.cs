namespace DistributorAPI.Presentation.DTOs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string CorporateName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> ContactNames { get; set; } = new();
    public List<string> DeliveryAddresses { get; set; } = new();
}