using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mediateca.Infractructure.EfCore.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Musicians",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                Description = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Musicians", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Albums",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                Year = table.Column<int>(type: "integer", nullable: true),
                MusicianId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Albums", x => x.Id);
                table.ForeignKey(
                    name: "FK_Albums_Musicians_MusicianId",
                    column: x => x.MusicianId,
                    principalTable: "Musicians",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tracks",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                TrackNumber = table.Column<int>(type: "integer", nullable: true),
                Time = table.Column<string>(type: "text", nullable: true),
                AlbumId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tracks", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tracks_Albums_AlbumId",
                    column: x => x.AlbumId,
                    principalTable: "Albums",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Musicians",
            columns: new[] { "Id", "Description", "Name" },
            values: new object[,]
            {
                { 1, "Член группы Beatles.", "John Lennon" },
                { 2, "Вокалист Queen.", "Freddie Mercury" },
                { 3, "Легендарный рок-музыкант.", "David Bowie" },
                { 4, "Джазовая певица.", "Amy Winehouse" },
                { 5, "Вокалист Nirvana.", "Kurt Cobain" },
                { 6, "Король Поп-музыки.", "Michael Jackson" },
                { 7, "Король Рок-н-Ролла.", "Elvis Presley" },
                { 8, "Королева Поп-музыки.", "Madonna" },
                { 9, "Легенда рэгги.", "Bob Marley" },
                { 10, "Одна из известнейших певиц Великобритании.", "Adele" }
            });

        migrationBuilder.InsertData(
            table: "Albums",
            columns: new[] { "Id", "MusicianId", "Name", "Year" },
            values: new object[,]
            {
                { 1, 1, "Imagine", 1971 },
                { 2, 1, "Double Fantasy", 1980 },
                { 3, 2, "A Night at the Opera", 1975 },
                { 4, 2, "The Game", 1980 },
                { 5, 3, "The Rise and Fall of Ziggy Stardust", 1972 },
                { 6, 3, "Heroes", 1977 },
                { 7, 4, "Back to Black", 2006 },
                { 8, 4, "Frank", 2003 },
                { 9, 5, "Nevermind", 1991 },
                { 10, 5, "In Utero", 1993 },
                { 11, 6, "Thriller", 1982 },
                { 12, 6, "Bad", 1987 },
                { 13, 7, "Elvis Presley", 1956 },
                { 14, 7, "From Elvis in Memphis", 1969 },
                { 15, 8, "Like a Virgin", 1984 },
                { 16, 8, "Ray of Light", 1998 },
                { 17, 9, "Exodus", 1977 },
                { 18, 9, "Legend", 1984 },
                { 19, 10, "21", 2011 },
                { 20, 10, "25", 2015 }
            });

        migrationBuilder.InsertData(
            table: "Tracks",
            columns: new[] { "Id", "AlbumId", "Name", "Time", "TrackNumber" },
            values: new object[,]
            {
                { 1, 1, "Imagine", "3:03", 1 },
                { 2, 1, "Jealous Guy", "4:14", 2 },
                { 3, 2, "Watching the Wheels", "3:30", 3 },
                { 4, 2, "Beautiful Boy", "4:05", 4 },
                { 5, 3, "Bohemian Rhapsody", "5:55", 1 },
                { 6, 3, "You're My Best Friend", "2:52", 2 },
                { 7, 4, "Another One Bites the Dust", "3:35", 1 },
                { 8, 4, "Crazy Little Thing Called Love", "2:43", 2 },
                { 9, 5, "Starman", "4:16", 1 },
                { 10, 5, "Ziggy Stardust", "3:13", 2 },
                { 11, 6, "Heroes", "6:07", 1 },
                { 12, 6, "Beauty and the Beast", "3:32", 2 },
                { 13, 7, "Rehab", "3:34", 1 },
                { 14, 7, "You Know I'm No Good", "4:17", 2 },
                { 15, 8, "Stronger Than Me", "3:33", 1 },
                { 16, 8, "Take the Box", "3:20", 2 },
                { 17, 9, "Smells Like Teen Spirit", "5:01", 1 },
                { 18, 9, "Come as You Are", "3:39", 2 },
                { 19, 10, "Heart-Shaped Box", "4:41", 1 },
                { 20, 10, "Rape Me", "2:50", 2 }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Albums_MusicianId",
            table: "Albums",
            column: "MusicianId");

        migrationBuilder.CreateIndex(
            name: "IX_Tracks_AlbumId",
            table: "Tracks",
            column: "AlbumId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tracks");

        migrationBuilder.DropTable(
            name: "Albums");

        migrationBuilder.DropTable(
            name: "Musicians");
    }
}
