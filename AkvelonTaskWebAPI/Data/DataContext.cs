using Microsoft.EntityFrameworkCore;

namespace AkvelonTaskWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskClass> Tasks { get; set; }

    }
}
