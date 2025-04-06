namespace DistributorAPI.Presentation.DTOs;

public class UpdateCustomerDto
{
    public string CorporateName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> Contacts { get; set; } = [];
    public List<string> Addresses { get; set; } = [];
}