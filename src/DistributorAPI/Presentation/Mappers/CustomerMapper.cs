using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

namespace DistributorAPI.Presentation.Mappers;

public class CustomerMapper
{
    public static Customer ToEntity(CreateCustomerDto dto)
    {
        return new Customer
        {
            Document = dto.Document,
            FullName = dto.FullName,
            TradeName = dto.TradeName,
            Email = dto.Email,
            Phone = dto.Phone,
            Contacts = dto.Contacts.Select(name => new Contact { Name = name }).ToList(),
            Addresses = dto.Addresses.Select(address => new Address { Addressinfo = address }).ToList(),
            CustomerType = dto.CustomerType
        };
    }

    public static Customer ToEntity(UpdateCustomerDto dto, Guid id)
    {
        return new Customer
        {
            Id = id,
            FullName = dto.FullName,
            TradeName = dto.TradeName,
            Email = dto.Email,
            Phone = dto.Phone,
            Contacts = dto.Contacts.Select(name => new Contact { Name = name }).ToList(),
            Addresses = dto.Addresses.Select(address => new Address { Addressinfo = address }).ToList(),
            CustomerType = dto.CustomerType
        };
    }

    public static CustomerDto ToDto(Customer entity)
    {
        return new CustomerDto
        {
            Id = entity.Id,
            Document = entity.Document,
            FullName = entity.FullName,
            TradeName = entity.TradeName,
            Email = entity.Email,
            Phone = entity.Phone,
            ContactNames = entity.Contacts.Select(cn => cn.Name).ToList(),
            DeliveryAddresses = entity.Addresses.Select(da => da.Addressinfo).ToList(),
            CustomerType = entity.CustomerType
        };
    }

    public static List<CustomerDto> ToDtoList(IEnumerable<Customer> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}