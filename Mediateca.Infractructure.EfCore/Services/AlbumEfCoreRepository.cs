using Mediateca.Domain.Model;
using Mediateca.Domain.Services;
using Mediateca.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Mediateca.Infractructure.EfCore.Services;
public class AlbumEfCoreRepository(MediatecaDbContext context) : IRepository<Album, int>
{
    private readonly DbSet<Album> _albums = context.Albums;
    public async Task<Album> Add(Album entity)
    {
        var result = await _albums.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _albums.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _albums.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Album?> Get(int key) =>
        await _albums.FirstOrDefaultAsync(e => e.Id == key);
    
    public async Task<IList<Album>> GetAll() =>
        await _albums.ToListAsync();

    public async Task<Album> Update(Album entity)
    {
        _albums.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}
