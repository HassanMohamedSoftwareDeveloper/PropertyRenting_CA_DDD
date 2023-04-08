namespace PropertyRenting.Domain.Repositories;

public interface ICountryRepository : IWriteRepository<Country>
{
    Task<Country> GetCountryAsync(ISpecification<Country> specification, CancellationToken cancellationToken = default);
}
