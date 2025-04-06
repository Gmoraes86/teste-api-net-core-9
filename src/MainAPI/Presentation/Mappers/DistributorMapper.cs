using MainAPI.Domain.Entities;
using MainAPI.Presentation.DTOs;

namespace MainAPI.Presentation.Mappers;

public class DistributorMapper
{
    public static Distributor ToEntity(CreateDistributorDto dto)
    {
        return new Distributor
        {
            Cnpj = dto.Cnpj,
            CorporateName = dto.CorporateName,
            TradeName = dto.TradeName,
            Email = dto.Email,
            Phone = dto.Phone,
            Contacts = dto.Contacts.Select(name => new Contact { Name = name }).ToList(),
            Addresses = dto.Addresses.Select(address => new Address { Addressinfo = address }).ToList()
        };
    }

    // Converter UpdateDistributorDTO para Distributor
    public static Distributor ToEntity(UpdateDistributorDto dto, Guid id)
    {
        return new Distributor
        {
            Id = id,
            CorporateName = dto.CorporateName,
            TradeName = dto.TradeName,
            Email = dto.Email,
            Phone = dto.Phone,
            Contacts = dto.Contacts.Select(name => new Contact { Name = name }).ToList(),
            Addresses = dto.Addresses.Select(address => new Address { Addressinfo = address }).ToList()
        };
    }

    // Converter Distributor para DistributorDTO
    public static DistributorDto ToDto(Distributor entity)
    {
        return new DistributorDto
        {
            Id = entity.Id,
            Cnpj = entity.Cnpj,
            CorporateName = entity.CorporateName,
            TradeName = entity.TradeName,
            Email = entity.Email,
            Phone = entity.Phone,
            ContactNames = entity.Contacts.Select(cn => cn.Name).ToList(),
            DeliveryAddresses = entity.Addresses.Select(da => da.Addressinfo).ToList()
        };
    }
    
    public static List<DistributorDto> ToDtoList(IEnumerable<Distributor> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}