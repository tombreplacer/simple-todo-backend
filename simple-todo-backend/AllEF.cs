using Microsoft.EntityFrameworkCore;

namespace simple_todo_backend;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public string DbPath { get; }

    public TodoContext(DbContextOptions options): base(options)
    {
    }
}

public class Todo
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime Date { get; set; }
}
