using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Storage.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
