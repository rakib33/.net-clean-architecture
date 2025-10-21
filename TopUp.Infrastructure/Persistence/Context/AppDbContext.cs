using Microsoft.EntityFrameworkCore;
using TopUp.Domain.Entities;

namespace TopUp.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
