using Mediateca.Domain.Model;
using Mediateca.Domain.Services;
using Mediateca.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Mediateca.Infractructure.EfCore.Services;
public class MusicianEfCoreRepository(MediatecaDbContext context) : IRepository<Musician, int>
{
    private readonly DbSet<Musician> _musicians = context.Musicians;
    public async Task<Musician> Add(Musician entity)
    {
        var result = await _musicians.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _musicians.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _musicians.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Musician?> Get(int key) =>
        await _musicians.FirstOrDefaultAsync(e => e.Id == key);
    

    public async Task<IList<Musician>> GetAll() =>
        await _musicians.ToListAsync();

    public async Task<Musician> Update(Musician entity)
    {
        _musicians.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}
