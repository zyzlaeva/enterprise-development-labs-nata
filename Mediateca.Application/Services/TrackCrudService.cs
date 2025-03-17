using AutoMapper;
using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Track;
using Mediateca.Domain.Model;
using Mediateca.Domain.Services;

namespace Mediateca.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции над маршрутами
/// </summary>
public class TrackCrudService(ITrackRepository repository, IMapper mapper) : ICrudService<TrackDto, TrackCreateUpdateDto, int>, IAnalyticsService
{
    public async Task<TrackDto> Create(TrackCreateUpdateDto newDto)
    {
        var newTrack = mapper.Map<Track>(newDto);
        newTrack.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newTrack);
        return mapper.Map<TrackDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);

    public async Task<TrackDto?> GetById(int id)
    {
        var track = await repository.Get(id);
        return mapper.Map<TrackDto>(track);
    }

    public async Task<IList<TrackDto>> GetList() =>
        mapper.Map<List<TrackDto>>(await repository.GetAll());

    public async Task<TrackDto> Update(int key, TrackCreateUpdateDto newDto)
    {
        var newTrack = mapper.Map<Track>(newDto);
        await repository.Update(newTrack);
        return mapper.Map<TrackDto>(newTrack);
    }

    public async Task<IList<string>> GetMusiciansInfo() =>
        await repository.GetMusiciansInfo();
    
    public async Task<IList<string>> GetAlbumInfo(int key) =>
        await repository.GetAlbumInfo(key);
    
    public async Task<IList<string>> GetAlbumsByYear(int key) =>
        await repository.GetAlbumsByYear(key);
    
    public async Task<IList<string>> GetTop5AlbumsByDuration() =>
        await repository.GetTop5AlbumsByDuration();
    
    public async Task<IList<string>> GetMaxAlbumsArtist() =>
        await repository.GetMaxAlbumsArtist();
    
    public async Task<IList<string>> GetAlbumsMetrics() =>
        await repository.GetAlbumsMetrics();
}
