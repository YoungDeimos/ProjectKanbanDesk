using Microsoft.EntityFrameworkCore;

namespace ProjectKanbanDesk.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Email = "Bibop@gmail.com", Password = "12345" }
            );
        }
    }
}
