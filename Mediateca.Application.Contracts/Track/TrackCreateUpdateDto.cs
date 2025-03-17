namespace Mediateca.Application.Contracts.Track;
/// <summary>
/// Dto для создания или изменения
/// </summary>
public record TrackCreateUpdateDto(string? Name, int? TrackNumber, string? Time, int AlbumId);