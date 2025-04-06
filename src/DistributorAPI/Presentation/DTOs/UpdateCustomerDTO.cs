using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Presentation.DTOs;

public class UpdateCustomerDto
{
    public string FullName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> Contacts { get; set; } = [];
    public List<string> Addresses { get; set; } = [];
    public CustomerType CustomerType { get; set; } = CustomerType.Corporate; // Default to Corporate
}