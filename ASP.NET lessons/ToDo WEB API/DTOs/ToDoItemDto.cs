namespace ToDo_WEB_API.DTOs;

public class ToDoItemDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
}
