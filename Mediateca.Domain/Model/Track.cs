using System.ComponentModel.DataAnnotations;

namespace Mediateca.Domain.Model;
/// <summary>
/// Трек
/// </summary>
public class Track
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
    /// Номер
    /// </summary>
    public int? TrackNumber { get; set; }

    /// <summary>
    /// Длина в мин:сек 
    /// </summary>
    public string? Time { get; set; }

    /// <summary>
    /// Идентификатор Альбом
    /// </summary>
    public required int AlbumId { get; set; }

    /// <summary>
    /// Навигейшн Альбом
    /// </summary>
    public virtual Album? Album { get; set; }
}
