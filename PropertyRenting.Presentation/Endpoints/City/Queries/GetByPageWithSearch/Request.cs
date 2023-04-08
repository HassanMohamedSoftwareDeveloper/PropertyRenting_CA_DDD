namespace PropertyRenting.Presentation.Endpoints.City.Queries.GetByPageWithSearch;

public class Request
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
