using AutoMapper;
using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Album;
using Mediateca.Domain.Model;
using Mediateca.Domain.Services;
using Album = Mediateca.Domain.Model.Album;

namespace Mediateca.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции над авто
/// </summary>
public class AlbumCrudService(IRepository<Album, int> repository, IMapper mapper) : ICrudService<AlbumDto, AlbumCreateUpdateDto, int>
{
    public async Task<AlbumDto> Create(AlbumCreateUpdateDto newDto)
    {
        var newAlbum = mapper.Map<Album>(newDto);
        newAlbum.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newAlbum);
        return mapper.Map<AlbumDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);

    public async Task<AlbumDto?> GetById(int id)
    {
        var album = await repository.Get(id);
        return mapper.Map<AlbumDto>(album);
    }

    public async Task<IList<AlbumDto>> GetList() =>
        mapper.Map<List<AlbumDto>>(await repository.GetAll());

    public async Task<AlbumDto> Update(int key, AlbumCreateUpdateDto newDto)
    {
        var newAlbum = mapper.Map<Album>(newDto);
        await repository.Update(newAlbum);
        return mapper.Map<AlbumDto>(newAlbum);
    }
}
