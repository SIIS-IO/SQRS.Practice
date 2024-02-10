using Microsoft.EntityFrameworkCore;
using SQRS.Practice.Domain;

namespace SQRS.Practice.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
