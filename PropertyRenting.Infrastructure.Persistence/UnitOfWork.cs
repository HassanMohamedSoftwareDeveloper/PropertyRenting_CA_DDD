using PropertyRenting.Application.Primitives;
using PropertyRenting.Infrastructure.Persistence.Contexts;

namespace PropertyRenting.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    #region Fields :
    private readonly PropertyRentingWriteContext _context;
    #endregion

    #region CTORS :
    public UnitOfWork(PropertyRentingWriteContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods :
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return (await _context.SaveChangesAsync(cancellationToken)) > 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
    #endregion
}
