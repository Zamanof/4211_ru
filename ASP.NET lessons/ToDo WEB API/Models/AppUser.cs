using Microsoft.AspNetCore.Identity;

namespace ToDo_WEB_API.Models;

public class AppUser: IdentityUser
{
    public string? RefreshToken { get; set; }
    public virtual ICollection<ToDoItem> ToDoItems { get; set; } 
        = new List<ToDoItem>();
}
