using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data.Context;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {
        
    }

    public void MigrateDatabase()
    {
        
    }
}
