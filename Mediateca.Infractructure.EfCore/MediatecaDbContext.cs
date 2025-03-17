using Mediateca.Domain.Data;
using Mediateca.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Mediateca.Infrastructure.EfCore;

public class MediatecaDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Musician> Musicians { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musician>(builder =>
        {
            builder.ToTable("Musicians");
            builder.HasKey(b => b.Id);
            builder.HasData(DataSeeder.Musicians);
        });

        modelBuilder.Entity<Album>(builder =>
        {
            builder.ToTable("Albums");
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Musician).WithMany(m => m.Albums).IsRequired();
            builder.HasData(DataSeeder.Albums);
        });
        
        modelBuilder.Entity<Track>(builder =>
        {
            builder.ToTable("Tracks");
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Album).WithMany(m => m.Tracks).IsRequired();
            builder.HasData(DataSeeder.Tracks);
        });
    }
}
