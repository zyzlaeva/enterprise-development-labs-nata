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
    [InlineData(1991, 1)]
    [InlineData(1971, 1)]
    public async Task GetAlbumsByYear_Success(int year, int expectedCount)
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetAlbumsByYear(year);
        Assert.Equal(expectedCount, info.Count);
    }

    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetAlbumsMetrics_Success()
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetAlbumsMetrics();
        Assert.Equal(3, info.Count);
    }

    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetMusiciansInfo_Success()
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetMusiciansInfo();
        Assert.Equal(20, info.Count);
    }

    /// <summary>
    /// Параметризованный тест метода
    /// </summary>
    [Theory]
    [InlineData(5, 2)]
    [InlineData(8, 2)]
    [InlineData(11, 0)]
    public async Task GetAlbumInfo_Success(int key, int expectedCount)
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetAlbumInfo(key);
        Assert.Equal(expectedCount, info.Count);
    }

    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetTop5AlbumsByDuration()
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetTop5AlbumsByDuration();
        Assert.Equal(5, info.Count);
    }

    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetMaxAlbumsArtist_Success()
    {
        var repo = new TrackInMemoryRepository();
        var info = await repo.GetMaxAlbumsArtist();
        Assert.Equal(5, info.Count);
    }
}
