namespace Mediateca.Application.Contracts.Musician;
/// <summary>
/// Dto для просмотра сведений о музыканте
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя музыканта</param>
/// <param name="Description">Описание музыканта</param>
public record MusicianDto(int Id, string? Name, string? Description);
