namespace Mediateca.Application.Contracts;
/// <summary>
/// Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения
/// </summary>
public interface IAnalyticsService
{
    Task<IList<string>> GetMusiciansInfo();
    Task<IList<string>> GetAlbumInfo(int key);
    Task<IList<string>> GetAlbumsByYear(int key);
    Task<IList<string>> GetTop5AlbumsByDuration();
    Task<IList<string>> GetMaxAlbumsArtist();
    Task<IList<string>> GetAlbumsMetrics();
}
