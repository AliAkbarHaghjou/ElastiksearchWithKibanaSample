using ElastikSearchWithKibanaSample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElastikSearchWithKibanaSample.Context
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(m => m.ID).UseIdentityColumn().IsRequired();
            builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(500).IsRequired();
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.ToTable("ToDo", "dbo");
        }
    }
}