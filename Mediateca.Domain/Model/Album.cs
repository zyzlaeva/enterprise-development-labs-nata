using System.ComponentModel.DataAnnotations;

namespace Mediateca.Domain.Model;

/// <summary>
/// Альбом
/// </summary>
public class Album
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// Идентификатор Музыкант
    /// </summary>
    public required int MusicianId { get; set; }

    /// <summary>
    /// Навигейшн Музыкант
    /// </summary>
    public virtual Musician? Musician { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public virtual List<Track>? Tracks { get; set; }
}
