namespace Mediateca.Application.Contracts.Track;
/// <summary>
/// Dto для просмотра сведений
/// </summary>
public record TrackDto(int Id, string? Name, int? TrackNumber, string? Time, int AlbumId);
