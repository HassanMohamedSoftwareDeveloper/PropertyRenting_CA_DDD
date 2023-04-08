namespace PropertyRenting.Application.DTOs;

public record BaseLookupDTO(Guid Value, string Description);
public record PagingDTO<TData>(int PageNumber, int PageSize, int TotalCount, List<TData> Data);
public record PagedList<TData> //: IReadOnlyList<TData>
{
    private readonly IList<TData> _subset;
    public PagedList(IEnumerable<TData> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalCount = count;
        TotalPages = count == 0 ? 0 : (int)Math.Ceiling(count / (double)pageSize);
        _subset = items as IList<TData> ?? new List<TData>(items);
    }
    public int PageNumber { get; init; }
    public int TotalPages { get; init; }
    public int TotalCount { get; init; }
    public bool IsFirstPage => PageNumber == 1;
    public bool IsLastPage => PageNumber == TotalPages;
    public int Count => _subset.Count;
    public IList<TData> Data => _subset;
    //public TData this[int index] => _subset[index];
    //public IEnumerator<TData> GetEnumerator() => _subset.GetEnumerator();
    //IEnumerator IEnumerable.GetEnumerator() => _subset.GetEnumerator();
}