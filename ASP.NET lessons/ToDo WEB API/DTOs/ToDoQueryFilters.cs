using Microsoft.AspNetCore.Mvc;

namespace ToDo_WEB_API.DTOs;

public class ToDoQueryFilters
{
    [FromQuery(Name ="search")]
    public string? Search { get; set; }

    [FromQuery(Name = "completed")]
    public bool? IsCompleted { get; set; }
}
