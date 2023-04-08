using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Primitives;

public interface IReadRepository<TReadModel> where TReadModel : BaseReadModel
{
    Task<List<TLookup>> GetLookupAsync<TLookup>(ISpecification<TReadModel> specification, CancellationToken cancellationToken = default);
    Task<List<TData>> GetAsync<TData>(ISpecification<TReadModel> specification, CancellationToken cancellationToken = default);
    Task<PagedList<TData>> GetPageAsync<TData>(ISpecification<TReadModel> specification, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<TData> GetByIdAsync<TData>(ISpecification<TReadModel> specification, CancellationToken cancellationToken = default);
}
