using Microsoft.EntityFrameworkCore;

namespace ProjectKanbanDesk.Models    
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Story> Stories { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
