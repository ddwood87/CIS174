using Microsoft.EntityFrameworkCore;
using MovieListWood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieListWood.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) 
            : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"");
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = "A", Name = "Action" },
                new Genre { Id = "C", Name = "Comedy" },
                new Genre { Id = "D", Name = "Drama" },
                new Genre { Id = "H", Name = "Horror" },
                new Genre { Id = "M", Name = "Musical" },
                new Genre { Id = "R", Name = "RomCom" },
                new Genre { Id = "S", Name = "SciFi" }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie {
                    Id = 1,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreId = "D"
                },
                new Movie {
                    Id = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A"
                },
                new Movie {
                    Id = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R"
                }
            );
        }
    }
}
