using Mediateca.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Mediateca.Server.Controllers;

/// <summary>
/// Контроллер для выполнения аналитических запросов
/// </summary>
/// <param name="service">Служба для выполнения аналитических запросов</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service): ControllerBase
{
    /// <summary>
    /// Вывести информацию обо всех артистах
    /// </summary>
    [HttpGet("GetMusiciansInfo")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetMusiciansInfo() =>
        Ok(await service.GetMusiciansInfo());
    
    /// <summary>
    /// Вывести информацию обо всех треках в указанном альбоме, упорядочить по номеру
    /// </summary>
    [HttpGet("GetAlbumInfo/{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetAlbumInfo(int id) =>
        Ok(await service.GetAlbumInfo(id));
    
    /// <summary>
    /// Вывести информацию обо всех альбомах с указанием количества треков в альбоме, выпущенных в указанный год
    /// </summary>
    [HttpGet("GetAlbumsByYear/{year}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetAlbumsByYear(int year) =>
        Ok(await service.GetAlbumsByYear(year));

    /// <summary>
    /// Вывести топ 5 альбомов по продолжительности
    /// </summary>
    [HttpGet("GetTop5AlbumsByDuration")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetTop5AlbumsByDuration() =>
        Ok(await service.GetTop5AlbumsByDuration());

    /// <summary>
    /// Вывести артистов с максимальным количеством альбомов
    /// </summary>
    [HttpGet("GetMaxAlbumsArtist")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetMaxAlbumsArtist() =>
        Ok(await service.GetMaxAlbumsArtist());
    
    /// <summary>
    /// Вывести информацию о минимальной, средней и максимальной продолжительности альбомов
    /// </summary>
    [HttpGet("GetAlbumsMetrics")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetAlbumsMetrics() =>
        Ok(await service.GetAlbumsMetrics());
}
