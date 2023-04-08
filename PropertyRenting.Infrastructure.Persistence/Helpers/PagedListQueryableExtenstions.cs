using Microsoft.EntityFrameworkCore;
using PropertyRenting.Application.DTOs;

namespace PropertyRenting.Infrastructure.Persistence.Helpers;

public static class PagedListQueryableExtenstions
{
    private const int _default_Page = 1;
    private const int _default_Page_Size = 50;
    public static async Task<PagedList<TData>> ToPagedListAsync<TData>(this IQueryable<TData> source,
                                                                       int page,
                                                                       int pageSize,
                                                                       CancellationToken cancellationToken = default)
    {
        page = page <= 0 ? _default_Page : page;
        pageSize = pageSize <= 0 ? _default_Page_Size : pageSize;
        int skipped = (page - 1) * pageSize;

        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        if (count == 0)
            return new(Enumerable.Empty<TData>(), 0, 0, 0);
        var items = await source
            .Skip(skipped)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false); ;
        return new(items, count, page, pageSize);
    }

    public static PagedList<TData> ToPagedList<TData>(this IEnumerable<TData> source,
                                                      int page,
                                                      int pageSize)
    {
        page = page <= 0 ? _default_Page : page;
        pageSize = pageSize <= 0 ? _default_Page_Size : pageSize;
        int skipped = (page - 1) * pageSize;

        var count = source.Count();
        if (count == 0)
            return new(Enumerable.Empty<TData>(), 0, 0, 0);
        var items = source
            .Skip(skipped)
            .Take(pageSize)
            .ToList();
        return new(items, count, page, pageSize);
    }
}
