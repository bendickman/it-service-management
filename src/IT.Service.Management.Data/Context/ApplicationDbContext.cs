using IT.Service.Management.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IT.Service.Management.Data.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Ticket> Tickets { get; init; }

    public DbSet<Comment> Comments { get; init; }

    public ApplicationDbContext(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    }
}
