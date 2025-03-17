using Mediateca.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Mediateca.Infractructure.EfCore;
public class MediatecaDbContextFactory : IDesignTimeDbContextFactory<MediatecaDbContext>
{
    private const string ConnectionString = "Server=localhost;Username=postgres;Password=postgres;Database=mediatecaDb;Port=5432;";
    public MediatecaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MediatecaDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        return new MediatecaDbContext(optionsBuilder.Options);
    }
}