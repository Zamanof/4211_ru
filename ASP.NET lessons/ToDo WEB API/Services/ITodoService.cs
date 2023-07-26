using ToDo_WEB_API.DTOs;
using ToDo_WEB_API.DTOs.Pagination;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public interface ITodoService
{
    Task<PaginationListDto<ToDoItemDto>>GetToDoItemsAsync(
        int page,
        int pageSize,
        string? search,
        bool? isCompleted
        );
    Task<ToDoItemDto> GetToDoItemAsync(int id);
    Task<ToDoItemDto> ChangeTodoItemStatusAsync(int id, bool isCompleted);
    Task<ToDoItemDto> CreateTodoItem(CreateToDoItemRequest request);
}
