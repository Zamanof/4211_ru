using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public class TodoService : ITodoService
{
    private readonly Dictionary<int, ToDoItem> _items = new();
    private int _nextId = 1;
    public Task<ToDoItem> ChangeTodoItemStatusAsync(int id, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> CreateTodoItem(ToDoItem item)
    {
        item.Id = _nextId++;
        _items.Add(item.Id, item);
        return Task.FromResult(item);
    }

    public Task<ToDoItem?> GetToDoItemAsync(int id)
    {
        return Task.FromResult(_items.GetValueOrDefault(id));
    }

    public Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
    {
        return Task.FromResult<IEnumerable<ToDoItem>>(_items.Values);
    }
}
