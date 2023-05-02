using Mapster;
using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.DTOs;
using PropertyRenting.Application.Models.Read;
using PropertyRenting.Domain.Primitives;
using PropertyRenting.Infrastructure.Persistence.Contexts;
using PropertyRenting.Infrastructure.Persistence.Helpers;
using PropertyRenting.Infrastructure.Persistence.Specifications;

namespace PropertyRenting.Infrastructure.Persistence.Repositories.Read;

internal abstract class ReadRepository<TEntity> where TEntity : BaseReadModel
{
    #region PROPS :
    protected readonly PropertyRentingReadContext Context;
    protected readonly DbSet<TEntity> EntitySet;
    #endregion

    #region CTORS :
    protected ReadRepository(PropertyRentingReadContext context)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        Context = context;
        EntitySet = Context.Set<TEntity>();
    }
    #endregion

    #region Methods :
    public async Task<List<TLookup>> GetLookupAsync<TLookup>(ISpecification<TEntity> specification,
                                                             CancellationToken cancellationToken = default)
    => await ApplySpecification(specification)
           .ProjectToType<TLookup>()
           .ToListAsync(cancellationToken)
           .ConfigureAwait(false);
    public async Task<List<TData>> GetAsync<TData>(ISpecification<TEntity> specification,
                                                   CancellationToken cancellationToken = default)
    => await ApplySpecification(specification)
          .ProjectToType<TData>()
          .ToListAsync(cancellationToken)
          .ConfigureAwait(false);
    public async Task<PagedList<TData>> GetPageAsync<TData>(ISpecification<TEntity> specification,
                                                            int page,
                                                            int pageSize,
                                                            CancellationToken cancellationToken = default)
        => await ApplySpecification(specification)
         .ProjectToType<TData>()
         .ToPagedListAsync(page, pageSize, cancellationToken)
         .ConfigureAwait(false);
    public async Task<TData> GetByIdAsync<TData>(ISpecification<TEntity> specification,
                                                 CancellationToken cancellationToken = default)
        => await ApplySpecification(specification)
          .ProjectToType<TData>()
          .SingleOrDefaultAsync(cancellationToken)
          .ConfigureAwait(false);

    protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        => SpecificationEvaluator.GetQuery(EntitySet.AsQueryable(), specification);
    #endregion
}
