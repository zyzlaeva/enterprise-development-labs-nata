namespace Mediateca.Application.Contracts.Album;
/// <summary>
/// Dto для создания или изменения
/// </summary>
public record AlbumCreateUpdateDto(string? Name, int? Year, int MusicianId);
