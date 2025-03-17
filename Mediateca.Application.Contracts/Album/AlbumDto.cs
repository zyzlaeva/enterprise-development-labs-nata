namespace Mediateca.Application.Contracts.Album;
/// <summary>
/// Dto для просмотра сведений
/// </summary>
public record AlbumDto(int Id, string? Name, int? Year, int MusicianId);
