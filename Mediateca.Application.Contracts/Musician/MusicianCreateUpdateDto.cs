namespace Mediateca.Application.Contracts.Musician;
/// <summary>
/// Dto для создания или изменения
/// </summary>
public record MusicianCreateUpdateDto(string? Name, string? Description);