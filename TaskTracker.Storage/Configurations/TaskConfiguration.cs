using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Storage.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
