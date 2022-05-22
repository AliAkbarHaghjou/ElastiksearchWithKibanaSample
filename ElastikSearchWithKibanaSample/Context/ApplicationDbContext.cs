using Microsoft.EntityFrameworkCore;

namespace ElastikSearchWithKibanaSample.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}
