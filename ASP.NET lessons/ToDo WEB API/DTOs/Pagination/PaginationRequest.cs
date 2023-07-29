using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ToDo_WEB_API.DTOs.Pagination;
///
public class PaginationRequest
{
    /// <summary>
    /// Page number
    /// </summary>
    /// <example>1</example>
    [Range(1, int.MaxValue)]
    [FromQuery(Name ="page")]
    [Required]
    public int Page { get; set; } = 1;

    /// <summary>
    /// Page size - How many items in one page 
    /// </summary>
    /// <example>10</example>
    [Range(1, int.MaxValue)]
    [FromQuery(Name ="pageSize")]
    [Required]
    public int PageSize { get; set; } = 10;
}
