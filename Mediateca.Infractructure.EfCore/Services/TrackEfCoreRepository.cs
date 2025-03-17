using Mediateca.Domain.Model;
using Mediateca.Domain.Services;
using Mediateca.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Mediateca.Infractructure.EfCore.Services;
public class TrackEfCoreRepository(MediatecaDbContext context) : ITrackRepository
{
    private readonly DbSet<Track> _tracks = context.Tracks;
    public async Task<Track> Add(Track entity)
    {
        var result = await _tracks.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _tracks.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _tracks.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Track?> Get(int key) =>
        await _tracks.FirstOrDefaultAsync(e => e.Id == key);
    

    public async Task<IList<Track>> GetAll() =>
        await _tracks.ToListAsync();

    public async Task<Track> Update(Track entity)
    {
        _tracks.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
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
