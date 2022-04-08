using Films.Core.Domain.Model;
using Films.Core.Domain.SharedKernel.Repository;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.Database;
#pragma warning disable CS1591
public class FilmDbContext : DbContext, IUnitOfWork
{
    public DbSet<Film> Films { get; set; }
    public FilmDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }
    public FilmDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    
}
#pragma warning restore CS1591