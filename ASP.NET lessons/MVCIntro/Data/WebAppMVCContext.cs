using Microsoft.EntityFrameworkCore;
using MVCIntro.Models;

namespace MVCIntro.Data;

public class WebAppMVCContext: DbContext
{
    public WebAppMVCContext(DbContextOptions options) 
        : base(options)
    {}
    public DbSet<Product> Products => Set<Product>();
}
