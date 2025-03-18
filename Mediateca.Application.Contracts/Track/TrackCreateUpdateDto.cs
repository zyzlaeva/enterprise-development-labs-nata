namespace Mediateca.Application.Contracts.Track;
/// <summary>
/// Dto для создания или изменения трека
/// </summary>
/// <param name="Name">Название трека</param>
/// <param name="TrackNumber">Номер трека</param>
/// <param name="Time">Продолжительность трека</param>
/// <param name="AlbumId">Идентификатор альбома</param>
public record TrackCreateUpdateDto(string? Name, int? TrackNumber, string? Time, int AlbumId);