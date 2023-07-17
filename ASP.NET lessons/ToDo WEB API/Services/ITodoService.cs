using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public interface ITodoService
{
    Task<IEnumerable<ToDoItem>>GetToDoItemsAsync();
    Task<ToDoItem> GetToDoItemAsync(int id);
    Task<ToDoItem> ChangeTodoItemStatusAsync(int id, bool isCompleted);
    Task<ToDoItem> CreateTodoItem(ToDoItem item);
}
