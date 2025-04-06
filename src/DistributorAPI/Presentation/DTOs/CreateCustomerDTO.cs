using DistributorAPI.Domain.Entities;
using DistributorAPI.Helpers;

namespace DistributorAPI.Presentation.DTOs;

public class CreateCustomerDto
{
    private string _document = string.Empty;

    public string Document
    {
        get => _document; // Renomeado de Cnpj para Document
        set => _document = StringUtils.RemoveFormatting(value);
    }

    public string FullName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> Contacts { get; set; } = [];
    public List<string> Addresses { get; set; } = [];
    public CustomerType CustomerType { get; set; } = CustomerType.Corporate; // Default to Corporate
}