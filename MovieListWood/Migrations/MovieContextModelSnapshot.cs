﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieListWood.Data;

namespace MovieListWood.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieListWood.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = "A",
                            Name = "Action"
                        },
                        new
                        {
                            Id = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            Id = "H",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = "M",
                            Name = "Musical"
                        },
                        new
                        {
                            Id = "R",
                            Name = "RomCom"
                        },
                        new
                        {
                            Id = "S",
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("MovieListWood.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = "D",
                            Name = "Casablanca",
                            Rating = 5,
                            Year = 1942
                        },
                        new
                        {
                            Id = 2,
                            GenreId = "A",
                            Name = "Wonder Woman",
                            Rating = 3,
                            Year = 2017
                        },
                        new
                        {
                            Id = 3,
                            GenreId = "R",
                            Name = "Moonstruck",
                            Rating = 4,
                            Year = 1988
                        });
                });

            modelBuilder.Entity("MovieListWood.Models.Movie", b =>
                {
                    b.HasOne("MovieListWood.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
