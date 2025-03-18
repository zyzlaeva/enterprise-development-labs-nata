using Mediateca.Domain.Model;
using Mediateca.Domain.Data;

namespace Mediateca.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class MusicianInMemoryRepository : IRepository<Musician, int>
{
    private List<Musician> _musicians;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public MusicianInMemoryRepository()
    {
        _musicians = DataSeeder.Musicians;
    }

    /// <inheritdoc/>
    public Task<Musician> Add(Musician entity)
    {
        try
        {
            _musicians.Add(entity);
        }
        catch
        {
            return null!;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        try
        {
            var musician = await Get(key);
            if (musician != null)
                _musicians.Remove(musician);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public async Task<Musician> Update(Musician entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <inheritdoc/>
    public Task<Musician?> Get(int key) =>
        Task.FromResult(_musicians.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<Musician>> GetAll() =>
        Task.FromResult((IList<Musician>)_musicians);
}
