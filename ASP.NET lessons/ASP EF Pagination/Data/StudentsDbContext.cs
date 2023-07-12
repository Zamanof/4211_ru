using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_EF_Pagination.Models;

    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext (DbContextOptions<StudentsDbContext> options)
            : base(options)
        { 
        }

        public DbSet<ASP_EF_Pagination.Models.Student> Student { get; set; } = default!;
    }
