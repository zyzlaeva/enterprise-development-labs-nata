namespace Mediateca.Application.Contracts.Album;
/// <summary>
/// Dto для просмотра сведений об альбоме
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название альбома</param>
/// <param name="Year">Год выпуска альбома</param>
/// <param name="MusicianId">Идентификатор музыканта</param>
public record AlbumDto(int Id, string? Name, int? Year, int MusicianId);
