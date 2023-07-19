using ToDo_WEB_API.DTOs;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public class TodoService : ITodoService
{
    private readonly Dictionary<int, ToDoItem> _items = new();
    private int _nextId = 1;
    public Task<ToDoItemDto> ChangeTodoItemStatusAsync(int id, bool isCompleted)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemDto> CreateTodoItem(CreateToDoItemRequest request)
    {
        var item = new ToDoItemDto()
        {
            Id = _nextId++,
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };

        _items.Add(item.Id, ConvertToDoItem(item));
        return Task.FromResult(item);
    }

    public Task<ToDoItemDto?> GetToDoItemAsync(int id)
    {
        var item = _items.GetValueOrDefault(id);
        if (item is null) 
            return null;
        else
            return Task.FromResult(ConvertToDoItemDto(item))!;
    }

    public Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync()
    {
        return Task.FromResult<IEnumerable<ToDoItemDto>>(
            _items.Values.Select(item =>
            ConvertToDoItemDto(item)));
    }

    private ToDoItem ConvertToDoItem(ToDoItemDto item)
    {
        var todoItem = new ToDoItem()
        {
            Id = item.Id,
            Text = item.Text,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.CreatedAt,
            IsCompleted = item.IsCompleted
        };
        return todoItem;
    }

    private ToDoItemDto ConvertToDoItemDto(ToDoItem item)
    {
        var todoItemDto = new ToDoItemDto()
        {
            Id = item.Id,
            Text = item.Text,
            CreatedAt = item.CreatedAt,
            IsCompleted = item.IsCompleted
        };
        return todoItemDto;
    }
}
