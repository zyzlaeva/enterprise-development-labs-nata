using Mediateca.Domain.Services.InMemory;

namespace Mediateca.Domain.Tests;

/// <summary>
///  Класс с юнит-тестами репозитория с авторами
/// </summary>
public class MediatecaTests
{
    /// <summary>
    /// Параметризованный тест метода
    /// </summary>
    /// <param name="authorId"></param>
    /// <param name="expectedCount"></param>
    [Theory]
    [InlineData(1980, 2)]
    public async Task GetAlbumsByYear_Success(int year, int expectedCount)
    {
        var repo = new TrackInMemoryRepository();
        var albums = await repo.GetAlbumsByYear(year);
        Assert.Equal(expectedCount, albums.Count);
    }
    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetAlbumsMetrics_Success()
    {
        var repo = new TrackInMemoryRepository();
        var metrics = await repo.GetAlbumsMetrics();
        Assert.Equal(3, metrics.Count);
    }
}
