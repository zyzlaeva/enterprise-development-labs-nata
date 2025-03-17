using AutoMapper;
using Mediateca.Application.Contracts;
using Mediateca.Application.Contracts.Musician;
using Mediateca.Domain.Model;
using Mediateca.Domain.Services;

namespace Mediateca.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции
/// </summary>
public class MusicianCrudService(IRepository<Musician, int> repository, IMapper mapper) : ICrudService<MusicianDto, MusicianCreateUpdateDto, int>
{
    public async Task<MusicianDto> Create(MusicianCreateUpdateDto newDto)
    {
        var newMusician = mapper.Map<Musician>(newDto);
        newMusician.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newMusician);
        return mapper.Map<MusicianDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);

    public async Task<MusicianDto?> GetById(int id)
    {
        var musician = await repository.Get(id);
        return mapper.Map<MusicianDto>(musician);
    }

    public async Task<IList<MusicianDto>> GetList() =>
        mapper.Map<List<MusicianDto>>(await repository.GetAll());

    public async Task<MusicianDto> Update(int key, MusicianCreateUpdateDto newDto)
    {
        var newMusician = mapper.Map<Musician>(newDto);
        await repository.Update(newMusician);
        return mapper.Map<MusicianDto>(newMusician);
    }
}
