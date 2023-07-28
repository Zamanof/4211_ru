using Microsoft.EntityFrameworkCore;
using ToDo_WEB_API.Data;
using ToDo_WEB_API.DTOs;
using ToDo_WEB_API.DTOs.Pagination;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Services;

public class TodoService : ITodoService
{
    //private readonly Dictionary<int, ToDoItem> _items = new();
    //private int _nextId = 1;

    private readonly ToDoDbContext _dbContext;

    public TodoService(ToDoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ToDoItemDto?> ChangeTodoItemStatusAsync(int id, bool isCompleted)
    {
        var item = await _dbContext.ToDoItems.FindAsync(id);
        if (item is null)
        {
            return null;
        }
        item.IsCompleted = isCompleted;
        item.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();

        return ConvertToDoItemDto(item);
    }

    public async Task<ToDoItemDto> CreateTodoItem(CreateToDoItemRequest request)
    {
        var now = DateTime.UtcNow;
        var item = new ToDoItem()
        {
            Text = request.Text,
            CreatedAt = now,
            UpdatedAt = now,
            IsCompleted = false
        };

        item = _dbContext.ToDoItems.Add(item).Entity;
        await _dbContext.SaveChangesAsync();
        return ConvertToDoItemDto(item);
    }

    public async Task<ToDoItemDto?> GetToDoItemAsync(int id)
    {
        var item = await _dbContext.ToDoItems.FindAsync(id);
        return item is not null ?
            ConvertToDoItemDto(item) :
            null;
    }

    public async Task<PaginationListDto<ToDoItemDto>> GetToDoItemsAsync(
        int page,
        int pageSize,
        string? search,
        bool? isCompleted
        )
    {
        IQueryable<ToDoItem> query = _dbContext.ToDoItems;
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(item => item.Text.Contains(search));
        }

        if (isCompleted.HasValue)
        {
            query = query.Where(item => item.IsCompleted == isCompleted);
        }

        var totalCount = await query.CountAsync();

        var items = await query.
            Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginationListDto<ToDoItemDto>(
            items.Select(item => ConvertToDoItemDto(item)),
            new PaginationMeta(page, pageSize, totalCount)
            );

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
