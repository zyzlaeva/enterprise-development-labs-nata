using Mediateca.Domain.Data;
using Mediateca.Domain.Model;
using System.Xml.Linq;

namespace Mediateca.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class AlbumInMemoryRepository : IRepository<Album, int>
{
    private List<Album> _albums;
    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public AlbumInMemoryRepository()
    {
        _albums = DataSeeder.Albums;
    }

    /// <inheritdoc/>
    public Task<Album> Add(Album entity)
    {
        try
        {
            _albums.Add(entity);
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
            var album = await Get(key);
            if (album != null)
                _albums.Remove(album);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<Album?> Get(int key) =>
        Task.FromResult(_albums.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<Album>> GetAll() =>
        Task.FromResult((IList<Album>)_albums);

    /// <inheritdoc/>
    public async Task<Album> Update(Album entity)
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
}
