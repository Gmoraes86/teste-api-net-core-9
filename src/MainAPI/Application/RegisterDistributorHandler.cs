using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

namespace MainAPI.Application;

public class RegisterDistributorHandler
{
    private readonly IDistributorRepository _distributorRepository;

    public RegisterDistributorHandler(IDistributorRepository distributorRepository)
    {
        _distributorRepository = distributorRepository;
    }

    public async Task<Distributor> Handle(Distributor distributor)
    {
        if (string.IsNullOrWhiteSpace(distributor.Cnpj))
            throw new ArgumentException("CNPJ is required.");

        if (!IsValidCnpj(distributor.Cnpj))
            throw new ArgumentException("The provided CNPJ is invalid.");
        
        var existingDistributor = await _distributorRepository.GetByCnpjAsync(distributor.Cnpj);
        if (existingDistributor != null)
            throw new InvalidOperationException("A distributor with this CNPJ already exists.");
        
        return await _distributorRepository.AddAsync(distributor);
    }

    private bool IsValidCnpj(string cnpj)
    {
        return cnpj.Length == 14 && cnpj.All(char.IsDigit);
    }
}