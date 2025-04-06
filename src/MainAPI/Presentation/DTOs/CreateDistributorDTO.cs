using MainAPI.Helpers;

namespace MainAPI.Presentation.DTOs;

public class CreateDistributorDto
{
    private string _cnpj = string.Empty;

    public string Cnpj
    {
        get => _cnpj;
        set => _cnpj = StringUtils.RemoveFormatting(value);
    }

    public string CorporateName { get; set; } = string.Empty;
    public string TradeName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<string> Contacts { get; set; } = [];
    public List<string> Addresses { get; set; } = [];
}