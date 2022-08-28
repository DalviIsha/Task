using Microsoft.EntityFrameworkCore;
using TestMS.API.Controllers;
using TestMS.Domain.Context;

namespace TestMS.Domain.Configuration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<WriteTestMSContext> options)
        : base(options)
        {
        }

        public DbSet<RefUser> RefUser { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}