using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGameDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EsrbRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsrbRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metacritic = table.Column<int>(type: "int", nullable: false),
                    Released = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tba = table.Column<bool>(type: "bit", nullable: false),
                    Updated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImageAdditional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingTop = table.Column<int>(type: "int", nullable: false),
                    Added = table.Column<int>(type: "int", nullable: false),
                    Playtime = table.Column<int>(type: "int", nullable: false),
                    ScreenshotsCount = table.Column<int>(type: "int", nullable: false),
                    MoviesCount = table.Column<int>(type: "int", nullable: false),
                    CreatorsCount = table.Column<int>(type: "int", nullable: false),
                    AchievementsCount = table.Column<int>(type: "int", nullable: false),
                    ParentAchievementsCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedditUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedditName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedditDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedditLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedditCount = table.Column<int>(type: "int", nullable: false),
                    TwitchCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewsTextCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingsCount = table.Column<int>(type: "int", nullable: false),
                    SuggestionsCount = table.Column<int>(type: "int", nullable: false),
                    AlternativeNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetacriticUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentsCount = table.Column<int>(type: "int", nullable: false),
                    AdditionsCount = table.Column<int>(type: "int", nullable: false),
                    GameSeriesCount = table.Column<int>(type: "int", nullable: false),
                    EsrbRatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDetails_EsrbRating_EsrbRatingId",
                        column: x => x.EsrbRatingId,
                        principalTable: "EsrbRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetacriticPlatform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metascore = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetacriticPlatform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetacriticPlatform_GameDetails_GameDetailsId",
                        column: x => x.GameDetailsId,
                        principalTable: "GameDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlatformDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ReleasedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequirementsId = table.Column<int>(type: "int", nullable: false),
                    GameDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformDetails_GameDetails_GameDetailsId",
                        column: x => x.GameDetailsId,
                        principalTable: "GameDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlatformDetails_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformDetails_Requirements_RequirementsId",
                        column: x => x.RequirementsId,
                        principalTable: "Requirements",
                        principalColumn: "RequirementsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    GameDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_GameDetails_GameDetailsId",
                        column: x => x.GameDetailsId,
                        principalTable: "GameDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_EsrbRatingId",
                table: "GameDetails",
                column: "EsrbRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_MetacriticPlatform_GameDetailsId",
                table: "MetacriticPlatform",
                column: "GameDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDetails_GameDetailsId",
                table: "PlatformDetails",
                column: "GameDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDetails_PlatformId",
                table: "PlatformDetails",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDetails_RequirementsId",
                table: "PlatformDetails",
                column: "RequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_GameDetailsId",
                table: "Rating",
                column: "GameDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetacriticPlatform");

            migrationBuilder.DropTable(
                name: "PlatformDetails");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "GameDetails");

            migrationBuilder.DropTable(
                name: "EsrbRating");
        }
    }
}
