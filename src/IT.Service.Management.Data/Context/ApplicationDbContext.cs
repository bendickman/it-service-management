using IT.Service.Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IT.Service.Management.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Ticket> Tickets { get; init; }

    public DbSet<Comment> Comments { get; init; }

    public ApplicationDbContext(
        DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ticket>();
        modelBuilder.Entity<Comment>();
    }
}
