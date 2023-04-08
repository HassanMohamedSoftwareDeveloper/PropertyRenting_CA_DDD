namespace PropertyRenting.Domain.Repositories;

public interface IBuildingRepository : IWriteRepository<Building>
{
    Task<Building> GetBuildingAsync(ISpecification<Building> specification, CancellationToken cancellationToken = default);
}
