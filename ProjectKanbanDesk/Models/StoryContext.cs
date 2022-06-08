using Microsoft.EntityFrameworkCore;

namespace ProjectKanbanDesk.Models    
{
    public class StoryContext : DbContext
    {
        public DbSet<Story> Stories { get; set; } = null!;
        public StoryContext(DbContextOptions<StoryContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
