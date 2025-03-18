using Mediateca.Domain.Model;

namespace Mediateca.Domain.Services;
/// <summary>
/// Наследник обобщенного интерфейса с дополнительной функциональностью 
/// </summary>
public interface ITrackRepository : IRepository<Track, int>
{
    /// <summary>
    /// Получить информацию обо всех музыкантах
    /// </summary>
    /// <returns>Список с информацией обо всех музыкантах</returns>
    Task<IList<string>> GetMusiciansInfo();

    /// <summary>
    /// Получить информацию о треках в альбоме по ID
    /// </summary>
    /// <param name="key">Идентификатор</param>
    /// <returns>Список с информацией о треках в альбоме</returns>
    Task<IList<string>> GetAlbumInfo(int key);

    /// <summary>
    /// Получить информацию об альбомах по году
    /// </summary>
    /// <param name="key">Год выпуска</param>
    /// <returns>Список с информацией об альбомах, вышедших в введенном году</returns>
    Task<IList<string>> GetAlbumsByYear(int key);

    /// <summary>
    /// Получить топ 5 альбомов по продолжительности
    /// </summary>
    /// <returns>Список с информацией о 5 самых длинных альбомах</returns>
    Task<IList<string>> GetTop5AlbumsByDuration();

    /// <summary>
    /// Получить музыканта(-ов) с наибольшим количеством альбомов
    /// </summary>
    /// <returns>Список с информацией о музыканте(-ах) и количестве его (их) альбомов</returns>
    Task<IList<string>> GetMaxAlbumsArtist();

    /// <summary>
    /// Получить минимальную, максимальную и среднюю продолжительность альбомов
    /// </summary>
    /// <returns>Список с продолжительностью самого короткого, среднего и самого длинного альбомов</returns>
    Task<IList<string>> GetAlbumsMetrics();
}
