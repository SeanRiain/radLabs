namespace Rad301_2025_Week2_Lab2
{
    using Microsoft.EntityFrameworkCore;

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<ToDo> Todos => Set<ToDo>();
    }
}
