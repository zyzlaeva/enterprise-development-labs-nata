using Mediateca.Domain.Data;
using Mediateca.Domain.Model;

namespace Mediateca.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class TrackInMemoryRepository : ITrackRepository
{
    private List<Musician> _musicians;
    private List<Album> _albums;
    private List<Track> _tracks;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public TrackInMemoryRepository()
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
    public Task<Track> Add(Track entity)
    {
        try
        {
            _tracks.Add(entity);
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
            var track = await Get(key);
            if (track != null)
                _tracks.Remove(track);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<Track?> Get(int key) =>
        Task.FromResult(_tracks.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<Track>> GetAll() =>
        Task.FromResult((IList<Track>)_tracks);

    /// <inheritdoc/>
    public async Task<Track> Update(Track entity)
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

    public async Task<IList<string>> GetMusiciansInfo()
    {
        var tracks = await GetAll();
        return tracks
            .Select(x => x.Album)
            .Select(x => x.Musician)
            .Select(x => $"Имя: {x.Name}, о музыканте: {x.Description}")
            .ToList();
    }

    public async Task<IList<string>> GetAlbumInfo(int key)
    {
        var tracks = await GetAll();
        return tracks
            .Where(x => x.AlbumId == key)
            .OrderBy(x => x.TrackNumber)
            .Select(x => $"Номер трека: {x.TrackNumber}, название: {x.Name}, длительность: {x.Time}")
            .ToList();
    }

    public async Task<IList<string>> GetAlbumsByYear(int year)
    {
        var tracks = await GetAll();
        return tracks
            .Select(x => x.Album)
            .Where(a => a.Year == year)
            .Select(a => new
            {
                Album = a,
                TrackCount = tracks.Count(t => t.AlbumId == a.Id)
            })
            .DistinctBy(x => x.Album)
            .Select(x => $"Альбом: {x.Album.Name}, " +
                $"Музыкант: {x.Album.Musician?.Name}, " +
                $"Количество треков: {x.TrackCount}")
            .ToList();
    }

    public async Task<IList<string>> GetTop5AlbumsByDuration()
    {
        var tracks = await GetAll();
        return tracks
            .Select(x => x.Album)
            .Select(a => new
            {
                Album = a,
                TotalDuration = tracks
                    .Where(t => t.AlbumId == a.Id)
                    .Sum(t => ParseTimeToMinutes(t.Time))
            })
            .OrderByDescending(a => a.TotalDuration)
            .Take(5)
            .Select(x => $"Альбом: {x.Album.Name}, " +
                $"Музыкант: {x.Album.Musician?.Name}, " +
                $"Общая продолжительность: {x.TotalDuration} минут")
            .ToList();
    }

    public async Task<IList<string>> GetMaxAlbumsArtist()
    {
        var tracks = await GetAll();
        var musicians = tracks
            .Select(x => x.Album)
            .Select(x => x.Musician);

        var musicianAlbumCount = tracks
            .Where(x => x.Album != null)
            .Select(x => x.Album)
            .GroupBy(a => a.MusicianId)
            .Select(x => new
            {
                MusicianId = x.Key,
                AlbumCount = x.Count(),
                Musician = musicians.FirstOrDefault(m => m.Id == x.Key)
            })
            .ToList();

        var maxAlbumCount = musicianAlbumCount.Max(a => a.AlbumCount);

        return musicianAlbumCount
            .Where(x => x.AlbumCount == maxAlbumCount)
            .Select(x => $"Артист: {x.Musician?.Name}, " +
                    $"Описание: {x.Musician?.Description}, " +
                    $"Количество альбомов: {x.AlbumCount}")
            .ToList();
    }

    public async Task<IList<string>> GetAlbumsMetrics()
    {
        var tracks = await GetAll();

        var albumsWithDuration = tracks
            .Select(a => new
            {
                Album = a,
                TotalDuration = tracks
                    .Where(t => t.AlbumId == a.Id)
                    .Sum(t => ParseTimeToMinutes(t.Time))
            })
            .ToList();

        var minDuration = albumsWithDuration.Min(a => a.TotalDuration);
        var avgDuration = albumsWithDuration.Average(a => a.TotalDuration);
        var maxDuration = albumsWithDuration.Max(a => a.TotalDuration);

        return
            [
                $"Минимальная продолжительность: {minDuration} минут",
                $"Средняя продолжительность: {avgDuration} минут",
                $"Максимальная продолжительность: {maxDuration} минут"
            ];
    }

    private static int ParseTimeToMinutes(string time)
    {
        if (string.IsNullOrEmpty(time) || !time.Contains(':'))
            return 0;

        var parts = time.Split(':');
        if (parts.Length != 2 || !int.TryParse(parts[0], out var minutes) || !int.TryParse(parts[1], out var seconds))
            return 0;

        return minutes + (seconds > 0 ? 1 : 0);
    }
}
