using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

namespace DistributorAPI.Presentation.Mappers;

public class CustomerMapper
{
    public static Customer ToEntity(CreateCustomerDto dto)
    {
        return new Customer
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

    // Converter UpdateCustomerDTO para Customer
    public static Customer ToEntity(UpdateCustomerDto dto, Guid id)
    {
        return new Customer
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

    // Converter Customer para CustomerDTO
    public static CustomerDto ToDto(Customer entity)
    {
        return new CustomerDto
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

    public static List<CustomerDto> ToDtoList(IEnumerable<Customer> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}