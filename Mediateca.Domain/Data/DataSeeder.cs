using Mediateca.Domain.Model;

namespace Mediateca.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция музыкантов
    /// </summary>
    public static readonly List<Musician> Musicians =
        [
            new Musician { Id = 1, Name = "John Lennon", Description = "Член группы Beatles." },
            new Musician { Id = 2, Name = "Freddie Mercury", Description = "Вокалист Queen." },
            new Musician { Id = 3, Name = "David Bowie", Description = "Легендарный рок-музыкант." },
            new Musician { Id = 4, Name = "Amy Winehouse", Description = "Джазовая певица." },
            new Musician { Id = 5, Name = "Kurt Cobain", Description = "Вокалист Nirvana." },
            new Musician { Id = 6, Name = "Michael Jackson", Description = "Король Поп-музыки." },
            new Musician { Id = 7, Name = "Elvis Presley", Description = "Король Рок-н-Ролла." },
            new Musician { Id = 8, Name = "Madonna", Description = "Королева Поп-музыки." },
            new Musician { Id = 9, Name = "Bob Marley", Description = "Легенда рэгги." },
            new Musician { Id = 10, Name = "Adele", Description = "Одна из известнейших певиц Великобритании." }
        ];

    /// <summary>
    /// Коллекция альбомов
    /// </summary>
    public static readonly List<Album> Albums =
        [
            new Album { Id = 1, Name = "Imagine", Year = 1971, MusicianId = 1 },
            new Album { Id = 2, Name = "Double Fantasy", Year = 1980, MusicianId = 1 },
            new Album { Id = 3, Name = "A Night at the Opera", Year = 1975, MusicianId = 2 },
            new Album { Id = 4, Name = "The Game", Year = 1980, MusicianId = 2 },
            new Album { Id = 5, Name = "The Rise and Fall of Ziggy Stardust", Year = 1972, MusicianId = 3 },
            new Album { Id = 6, Name = "Heroes", Year = 1977, MusicianId = 3 },
            new Album { Id = 7, Name = "Back to Black", Year = 2006, MusicianId = 4 },
            new Album { Id = 8, Name = "Frank", Year = 2003, MusicianId = 4 },
            new Album { Id = 9, Name = "Nevermind", Year = 1991, MusicianId = 5 },
            new Album { Id = 10, Name = "In Utero", Year = 1993, MusicianId = 5 },
            new Album { Id = 11, Name = "Thriller", Year = 1982, MusicianId = 6 },
            new Album { Id = 12, Name = "Bad", Year = 1987, MusicianId = 6 },
            new Album { Id = 13, Name = "Elvis Presley", Year = 1956, MusicianId = 7 },
            new Album { Id = 14, Name = "From Elvis in Memphis", Year = 1969, MusicianId = 7 },
            new Album { Id = 15, Name = "Like a Virgin", Year = 1984, MusicianId = 8 },
            new Album { Id = 16, Name = "Ray of Light", Year = 1998, MusicianId = 8 },
            new Album { Id = 17, Name = "Exodus", Year = 1977, MusicianId = 9 },
            new Album { Id = 18, Name = "Legend", Year = 1984, MusicianId = 9 },
            new Album { Id = 19, Name = "21", Year = 2011, MusicianId = 10 },
            new Album { Id = 20, Name = "25", Year = 2015, MusicianId = 10 }
        ];

    /// <summary>
    /// Коллекция треков
    /// </summary>
    public static readonly List<Track> Tracks =
        [
            new Track { Id = 1, Name = "Imagine", TrackNumber = 1, Time = "3:03", AlbumId = 1 },
            new Track { Id = 2, Name = "Jealous Guy", TrackNumber = 2, Time = "4:14", AlbumId = 1 },
            new Track { Id = 3, Name = "Watching the Wheels", TrackNumber = 3, Time = "3:30", AlbumId = 2 },
            new Track { Id = 4, Name = "Beautiful Boy", TrackNumber = 4, Time = "4:05", AlbumId = 2 },
            new Track { Id = 5, Name = "Bohemian Rhapsody", TrackNumber = 1, Time = "5:55", AlbumId = 3 },
            new Track { Id = 6, Name = "You're My Best Friend", TrackNumber = 2, Time = "2:52", AlbumId = 3 },
            new Track { Id = 7, Name = "Another One Bites the Dust", TrackNumber = 1, Time = "3:35", AlbumId = 4 },
            new Track { Id = 8, Name = "Crazy Little Thing Called Love", TrackNumber = 2, Time = "2:43", AlbumId = 4 },
            new Track { Id = 9, Name = "Starman", TrackNumber = 1, Time = "4:16", AlbumId = 5 },
            new Track { Id = 10, Name = "Ziggy Stardust", TrackNumber = 2, Time = "3:13", AlbumId = 5 },
            new Track { Id = 11, Name = "Heroes", TrackNumber = 1, Time = "6:07", AlbumId = 6 },
            new Track { Id = 12, Name = "Beauty and the Beast", TrackNumber = 2, Time = "3:32", AlbumId = 6 },
            new Track { Id = 13, Name = "Rehab", TrackNumber = 1, Time = "3:34", AlbumId = 7 },
            new Track { Id = 14, Name = "You Know I'm No Good", TrackNumber = 2, Time = "4:17", AlbumId = 7 },
            new Track { Id = 15, Name = "Stronger Than Me", TrackNumber = 1, Time = "3:33", AlbumId = 8 },
            new Track { Id = 16, Name = "Take the Box", TrackNumber = 2, Time = "3:20", AlbumId = 8 },
            new Track { Id = 17, Name = "Smells Like Teen Spirit", TrackNumber = 1, Time = "5:01", AlbumId = 9 },
            new Track { Id = 18, Name = "Come as You Are", TrackNumber = 2, Time = "3:39", AlbumId = 9 },
            new Track { Id = 19, Name = "Heart-Shaped Box", TrackNumber = 1, Time = "4:41", AlbumId = 10 },
            new Track { Id = 20, Name = "Rape Me", TrackNumber = 2, Time = "2:50", AlbumId = 10 }
        ];
}
