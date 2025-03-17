using AutoMapper;
using Mediateca.Application.Contracts.Musician;
using Mediateca.Application.Contracts.Album;
using Mediateca.Application.Contracts.Track;
using Mediateca.Domain.Model;

namespace Mediateca.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Musician, MusicianDto>();
        CreateMap<MusicianCreateUpdateDto, Musician>();

        CreateMap<Album, AlbumDto>();
        CreateMap<AlbumCreateUpdateDto, Album>();

        CreateMap<Track, TrackDto>();
        CreateMap<TrackCreateUpdateDto, Track>();
    }
}
