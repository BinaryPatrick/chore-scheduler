using House.Chore.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace House.Chore.Data.Models;

public partial class HouseChoreContext : DbContext
{
    public HouseChoreContext() { }

    public HouseChoreContext(DbContextOptions<HouseChoreContext> options) : base(options) { }

    public virtual DbSet<TaskSchedule> TaskInstances { get; set; }

    public virtual DbSet<TaskTemplate> TaskTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<TaskSchedule>(entity =>
        {
            _ = entity
                .HasNoKey()
                .ToTable("TaskSchedule");

            _ = entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            _ = entity.Property(e => e.TaskDate).HasColumnType("date");
            _ = entity.Property(e => e.TaskId).ValueGeneratedOnAdd();
        });

        _ = modelBuilder.Entity<TaskTemplate>(entity =>
        {
            _ = entity
                .HasNoKey()
                .ToTable("TaskTemplate");

            _ = entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            _ = entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            _ = entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            _ = entity.Property(e => e.Person)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = entity.Property(e => e.TaskTemplateId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
