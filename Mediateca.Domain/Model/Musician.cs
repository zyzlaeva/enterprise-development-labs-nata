using Mediateca.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace Mediateca.Domain.Model;
/// <summary>
/// Музыкант
/// </summary>
public class Musician
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
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public virtual List<Album>? Albums { get; set; }
}
