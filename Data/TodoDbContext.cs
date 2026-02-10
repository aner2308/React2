using Microsoft.EntityFrameworkCore;
using React2.Models;

namespace React2.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    public DbSet<TodoModel> Todos { get; set ; }
}