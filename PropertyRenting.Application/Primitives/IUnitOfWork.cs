namespace PropertyRenting.Application.Primitives;

public interface IUnitOfWork : IDisposable
{

    #region Methods :
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    #endregion
}
