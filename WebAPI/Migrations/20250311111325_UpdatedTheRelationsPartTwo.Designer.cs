﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250311111325_UpdatedTheRelationsPartTwo")]
    partial class UpdatedTheRelationsPartTwo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.EsrbRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EsrbRating");
                });

            modelBuilder.Entity("WebAPI.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "background_image");

                    b.Property<string>("EsrbRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Metacritic")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Released")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Tba")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebAPI.Models.GameDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AchievementsCount")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "achievements_count");

                    b.Property<int>("Added")
                        .HasColumnType("int");

                    b.Property<int>("AdditionsCount")
                        .HasColumnType("int");

                    b.PrimitiveCollection<string>("AlternativeNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "background_image");

                    b.Property<string>("BackgroundImageAdditional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "background_image_additional");

                    b.Property<int>("CreatorsCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EsrbRatingId")
                        .HasColumnType("int");

                    b.Property<int>("GameSeriesCount")
                        .HasColumnType("int");

                    b.Property<int>("Metacritic")
                        .HasColumnType("int");

                    b.Property<string>("MetacriticUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoviesCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentAchievementsCount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentsCount")
                        .HasColumnType("int");

                    b.Property<int>("Playtime")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("RatingTop")
                        .HasColumnType("int");

                    b.Property<int>("RatingsCount")
                        .HasColumnType("int");

                    b.Property<int>("RedditCount")
                        .HasColumnType("int");

                    b.Property<string>("RedditDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedditLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedditName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedditUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Released")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewsTextCount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScreenshotsCount")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuggestionsCount")
                        .HasColumnType("int");

                    b.Property<bool>("Tba")
                        .HasColumnType("bit");

                    b.Property<string>("TwitchCount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Updated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeCount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EsrbRatingId");

                    b.ToTable("GameDetails");
                });

            modelBuilder.Entity("WebAPI.Models.MetacriticPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("Metascore")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameDetailsId");

                    b.ToTable("MetacriticPlatform");
                });

            modelBuilder.Entity("WebAPI.Models.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformId"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleasedAt")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "released_at");

                    b.Property<int?>("RequirementsId")
                        .HasColumnType("int");

                    b.HasKey("PlatformId");

                    b.HasIndex("GameId");

                    b.HasIndex("RequirementsId")
                        .IsUnique()
                        .HasFilter("[RequirementsId] IS NOT NULL");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("WebAPI.Models.PlatformDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("ReleasedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequirementsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameDetailsId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RequirementsId");

                    b.ToTable("PlatformDetails");
                });

            modelBuilder.Entity("WebAPI.Models.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("GameDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameDetailsId");

                    b.HasIndex("GameId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("WebAPI.Models.Requirements", b =>
                {
                    b.Property<int>("RequirementsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementsId"));

                    b.Property<string>("Minimum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recommended")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequirementsId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("WebAPI.Models.GameDetails", b =>
                {
                    b.HasOne("WebAPI.Models.EsrbRating", "EsrbRating")
                        .WithMany()
                        .HasForeignKey("EsrbRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EsrbRating");
                });

            modelBuilder.Entity("WebAPI.Models.MetacriticPlatform", b =>
                {
                    b.HasOne("WebAPI.Models.GameDetails", null)
                        .WithMany("MetacriticPlatforms")
                        .HasForeignKey("GameDetailsId");
                });

            modelBuilder.Entity("WebAPI.Models.Platform", b =>
                {
                    b.HasOne("WebAPI.Models.Game", null)
                        .WithMany("Platforms")
                        .HasForeignKey("GameId");

                    b.HasOne("WebAPI.Models.Requirements", "Requirements")
                        .WithOne()
                        .HasForeignKey("WebAPI.Models.Platform", "RequirementsId");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("WebAPI.Models.PlatformDetails", b =>
                {
                    b.HasOne("WebAPI.Models.GameDetails", null)
                        .WithMany("Platforms")
                        .HasForeignKey("GameDetailsId");

                    b.HasOne("WebAPI.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Requirements", "Requirements")
                        .WithMany()
                        .HasForeignKey("RequirementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("WebAPI.Models.Ratings", b =>
                {
                    b.HasOne("WebAPI.Models.GameDetails", null)
                        .WithMany("Ratings")
                        .HasForeignKey("GameDetailsId");

                    b.HasOne("WebAPI.Models.Game", null)
                        .WithMany("Ratings")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("WebAPI.Models.Game", b =>
                {
                    b.Navigation("Platforms");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("WebAPI.Models.GameDetails", b =>
                {
                    b.Navigation("MetacriticPlatforms");

                    b.Navigation("Platforms");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
