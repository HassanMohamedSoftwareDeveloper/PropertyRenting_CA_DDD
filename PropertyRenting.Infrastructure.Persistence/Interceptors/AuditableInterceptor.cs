using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Infrastructure.Persistence.Interceptors;

internal sealed class AutidableInterceptor : SaveChangesInterceptor
{
    //#region Fields :
    //private readonly IHttpContextAccessor _httpContextAccessor;
    //#endregion

    //#region CTORS :
    //public AutidableInterceptor(IHttpContextAccessor httpContextAccessor)
    //{
    //    _httpContextAccessor = httpContextAccessor;
    //}
    //#endregion

    #region Methods :
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                  InterceptionResult<int> result,
                                                                  CancellationToken cancellationToken = default)
    {
        DbContext dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        var entries = dbContext.ChangeTracker.Entries<Entity>();

        string userId = null;// _httpContextAccessor.HttpContext?.User?.UserId();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                if (userId != null) entityEntry.Property(x => x.CreatedBy).CurrentValue = userId;
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                if (userId != null) entityEntry.Property(x => x.UpdatedBy).CurrentValue = userId;
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    #endregion
}