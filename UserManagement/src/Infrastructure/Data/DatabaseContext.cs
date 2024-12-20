using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Family).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.NationalCode).HasMaxLength(12).IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Birthday).IsRequired();
    }
}