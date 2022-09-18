using Microsoft.EntityFrameworkCore;
using YB.ToDoAPI.Models;

namespace YB.ToDoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItem { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer();
        }

    }
}
