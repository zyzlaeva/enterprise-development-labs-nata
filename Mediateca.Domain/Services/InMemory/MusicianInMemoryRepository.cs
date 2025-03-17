using Mediateca.Domain.Model;
using Mediateca.Domain.Data;

namespace Mediateca.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class MusicianInMemoryRepository : IRepository<Musician, int>
{
    private List<Musician> _musicians;
    private List<Album> _albums;
    private List<Track> _tracks;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public MusicianInMemoryRepository()
    {
        _musicians = DataSeeder.Musicians;
        _albums = DataSeeder.Albums;
        _tracks = DataSeeder.Tracks;

        foreach (var a in _musicians)
        {
            a.Albums = [];
            a.Albums?.AddRange(_albums.Where(ba => ba.MusicianId == a.Id));
        }

        foreach (var b in _albums)
        {
            b.Musician = _musicians.FirstOrDefault(a => a.Id == b.MusicianId);
            b.Tracks = [];
            b.Tracks?.AddRange(_tracks.Where(ba => ba.AlbumId == b.Id));
        }

        foreach (var b in _tracks)
        {
            b.Album = _albums.FirstOrDefault(a => a.Id == b.AlbumId);
        }
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

    public async Task<IList<string>> GetMusiciansInfo()
    {
        var musicians = await GetAll();
        return musicians
            .Select(x => $"Имя: {x.Name}, о музыканте: {x.Description}")
            .ToList();
    }
}
