using ToDo_WEB_API.DTOs;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public interface ITodoService
{
    Task<IEnumerable<ToDoItemDto>>GetToDoItemsAsync();
    Task<ToDoItemDto> GetToDoItemAsync(int id);
    Task<ToDoItemDto> ChangeTodoItemStatusAsync(int id, bool isCompleted);
    Task<ToDoItemDto> CreateTodoItem(CreateToDoItemRequest request);
}
