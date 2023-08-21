using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo_WEB_API.Models;

namespace ToDo_WEB_API.Data;

public class ToDoDbContext:IdentityDbContext
{
	public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
		:base(options)
	{}
	public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
	public DbSet<AppUser> AppUsers => Set<AppUser>();
}
