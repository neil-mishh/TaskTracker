using System.Data.Entity;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Models.Task> Tasks { get; set; }
    }
}
