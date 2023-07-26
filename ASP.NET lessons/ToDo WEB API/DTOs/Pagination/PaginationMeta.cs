namespace ToDo_WEB_API.DTOs.Pagination;

public class PaginationMeta
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages { get;}

    public PaginationMeta(int page, int pageSize, int totalCount)
    {
        Page = page;
        PageSize = pageSize;
        TotalPages = Convert.ToInt32(Math.Ceiling(1.0 * totalCount / pageSize));
    }
}
