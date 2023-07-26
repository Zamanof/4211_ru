namespace ToDo_WEB_API.DTOs.Pagination;

public class PaginationListDto<TModel>
{
    public IEnumerable<TModel> Items { get;}
    public PaginationMeta Meta { get;}

    public PaginationListDto(IEnumerable<TModel> items, PaginationMeta meta)
    {
        Items = items;
        Meta = meta;
    }
}
