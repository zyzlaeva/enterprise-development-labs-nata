namespace Mediateca.Application.Contracts.Musician;
/// <summary>
/// Dto для создания или изменения музыканта
/// </summary>
/// <param name="Name">Имя музыканта</param>
/// <param name="Description">Описание музыканта</param>
public record MusicianCreateUpdateDto(string? Name, string? Description);