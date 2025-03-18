namespace Mediateca.Application.Contracts.Album;
/// <summary>
/// Dto для создания или изменения
/// </summary>
/// <param name="Name">Название альбома</param>
/// <param name="Year">Год выпуска альбома</param>
/// <param name="MusicianId">Идентификатор музыканта</param>
public record AlbumCreateUpdateDto(string? Name, int? Year, int MusicianId);
