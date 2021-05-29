using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyTest.Migrations
{
    public partial class fixTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetMovie_Genres_Genres_GenreId",
                table: "GetMovie_Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_GetMovie_Genres_Movies_MovieId",
                table: "GetMovie_Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetMovie_Genres",
                table: "GetMovie_Genres");

            migrationBuilder.RenameTable(
                name: "GetMovie_Genres",
                newName: "Movie_Genres");

            migrationBuilder.RenameIndex(
                name: "IX_GetMovie_Genres_GenreId",
                table: "Movie_Genres",
                newName: "IX_Movie_Genres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Genres",
                table: "Movie_Genres",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genres_Genres_GenreId",
                table: "Movie_Genres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genres_Movies_MovieId",
                table: "Movie_Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_Genres_GenreId",
                table: "Movie_Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genres_Movies_MovieId",
                table: "Movie_Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Genres",
                table: "Movie_Genres");

            migrationBuilder.RenameTable(
                name: "Movie_Genres",
                newName: "GetMovie_Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Genres_GenreId",
                table: "GetMovie_Genres",
                newName: "IX_GetMovie_Genres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetMovie_Genres",
                table: "GetMovie_Genres",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GetMovie_Genres_Genres_GenreId",
                table: "GetMovie_Genres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GetMovie_Genres_Movies_MovieId",
                table: "GetMovie_Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
