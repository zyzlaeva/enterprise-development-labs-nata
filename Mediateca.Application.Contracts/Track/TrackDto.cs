namespace Mediateca.Application.Contracts.Track;
/// <summary>
/// Dto для просмотра сведений о треке
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название трека</param>
/// <param name="TrackNumber">Номер трека</param>
/// <param name="Time">Продолжительность трека</param>
/// <param name="AlbumId">Идентификатор альбома</param>
public record TrackDto(int Id, string? Name, int? TrackNumber, string? Time, int AlbumId);
