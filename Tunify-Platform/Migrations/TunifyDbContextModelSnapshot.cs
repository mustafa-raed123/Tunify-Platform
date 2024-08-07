﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.Data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    partial class TunifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Data.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("varchar");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            AlbumName = "Thriller",
                            ArtistId = 1,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumId = 2,
                            AlbumName = "The Dark Side of the Moon",
                            ArtistId = 2,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumId = 3,
                            AlbumName = "Abbey Road",
                            ArtistId = 1,
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.HasKey("ArtistId");

                    b.ToTable("artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            ArtistName = "Michael Jackson",
                            Bio = " good"
                        },
                        new
                        {
                            ArtistId = 2,
                            ArtistName = "Pink Floyd",
                            Bio = " good"
                        },
                        new
                        {
                            ArtistId = 3,
                            ArtistName = "The Beatles",
                            Bio = " good"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId");

                    b.HasIndex("UserId");

                    b.ToTable("playlists");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            CreateDate = new DateTime(2011, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Rock Classics"
                        },
                        new
                        {
                            PlaylistId = 2,
                            CreateDate = new DateTime(2013, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Pop Hits",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.PlaylistSong", b =>
                {
                    b.Property<int>("PlaylistSongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongId"));

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistsSongs", (string)null);
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("duration")
                        .HasColumnType("time");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs", (string)null);

                    b.HasData(
                        new
                        {
                            SongId = 1,
                            AlbumId = 1,
                            ArtistId = 1,
                            Genre = "Rock",
                            duration = new TimeSpan(0, 0, 33, 55, 0),
                            title = "Billie Jean"
                        },
                        new
                        {
                            SongId = 2,
                            AlbumId = 2,
                            ArtistId = 2,
                            Genre = "Rock",
                            duration = new TimeSpan(0, 0, 55, 55, 0),
                            title = "Bohemian Rhapsody"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Subscription", b =>
                {
                    b.Property<int>("SubsciptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubsciptionsId"));

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("SubsciptionsType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubsciptionsId");

                    b.ToTable("Subscriptions", (string)null);

                    b.HasData(
                        new
                        {
                            SubsciptionsId = 1,
                            Price = 30m,
                            SubsciptionsType = "Family"
                        },
                        new
                        {
                            SubsciptionsId = 2,
                            Price = 24m,
                            SubsciptionsType = "Free"
                        },
                        new
                        {
                            SubsciptionsId = 3,
                            Price = 43m,
                            SubsciptionsType = "Premium"
                        },
                        new
                        {
                            SubsciptionsId = 4,
                            Price = 12m,
                            SubsciptionsType = "Free"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SubsciptionId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("UserId");

                    b.HasIndex("SubsciptionId")
                        .IsUnique()
                        .HasFilter("[SubsciptionId] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "Mura@gmail.com",
                            Join_Date = new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubsciptionId = 1,
                            UserName = "mustafa"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "mohameda@gmail.com",
                            Join_Date = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubsciptionId = 2,
                            UserName = "mohammed"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "ahmed@gmail.com",
                            Join_Date = new DateTime(2024, 8, 8, 14, 13, 19, 105, DateTimeKind.Local).AddTicks(5573),
                            SubsciptionId = 3,
                            UserName = "ahmed"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Album", b =>
                {
                    b.HasOne("Tunify_Platform.Data.Models.Artist", "artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("artist");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Playlist", b =>
                {
                    b.HasOne("Tunify_Platform.Data.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.PlaylistSong", b =>
                {
                    b.HasOne("Tunify_Platform.Data.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Data.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Song", b =>
                {
                    b.HasOne("Tunify_Platform.Data.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.HasOne("Tunify_Platform.Data.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId");

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.User", b =>
                {
                    b.HasOne("Tunify_Platform.Data.Models.Subscription", "Subsciption")
                        .WithOne("user")
                        .HasForeignKey("Tunify_Platform.Data.Models.User", "SubsciptionId");

                    b.Navigation("Subsciption");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.Subscription", b =>
                {
                    b.Navigation("user")
                        .IsRequired();
                });

            modelBuilder.Entity("Tunify_Platform.Data.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
