using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Presentation.DTOs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Document { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> ContactNames { get; set; } = new();
    public List<string> DeliveryAddresses { get; set; } = new();
    public CustomerType CustomerType { get; set; }
}