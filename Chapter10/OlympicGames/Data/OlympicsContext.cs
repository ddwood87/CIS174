using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OlympicGames.Models;

namespace OlympicGames.Data
{
    public class OlympicsContext : DbContext
    {
        public OlympicsContext() : base() { }
        public OlympicsContext(DbContextOptions<OlympicsContext> options) : base(options)
        {
        }
        public DbSet<OlympicGame> Games { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }

        internal IEnumerable<Team> GetTeamsByIndoor(bool indoor)
        {
            return this.Teams.Where(t => t.Sport.Indoor.Equals(indoor))
                .Include(t => t.Country).Include(t => t.Sport).Include(t => t.Games).ToList();
        }

        internal IEnumerable<Team> GetTeamsByGame(string id)
        {
            return this.Teams.Where(t => t.OlympicGameID == id)
                .Include(t => t.Country).Include(t=> t.Sport).Include(t=> t.Games).ToList();
        }
        
        internal IEnumerable<Team> GetTeams()
        {
            return Teams.Include(t => t.Country).Include(t => t.Sport).Include(t => t.Games);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OlympicGame>().HasData(
                new OlympicGame { OlympicGameID = "winter", Name = "Winter Olympics" },
                new OlympicGame { OlympicGameID = "summer", Name = "Summer Olympics" },
                new OlympicGame { OlympicGameID = "para", Name = "Paralympics" },
                new OlympicGame { OlympicGameID = "youth", Name = "Youth Olympics" });

            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportID = "curl", Name = "Curling", Indoor = true },
                new Sport { SportID = "sled", Name = "Bobsleigh", Indoor = false },
                new Sport { SportID = "dive", Name = "Diving", Indoor = true },
                new Sport { SportID = "cycle", Name = "Road Cycling", Indoor = false },
                new Sport { SportID = "arch", Name = "Archery", Indoor = true },
                new Sport { SportID = "canoe", Name = "Canoe Sprint", Indoor = false },
                new Sport { SportID = "dance", Name = "Breakdancing", Indoor = true },
                new Sport { SportID = "skate", Name = "Skateboarding", Indoor = false });

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "ca", Name = "Canada" },
                new Country { CountryID = "se", Name = "Sweden" },
                new Country { CountryID = "gb", Name = "United Kingdom" },
                new Country { CountryID = "jm", Name = "Jamaica" },
                new Country { CountryID = "it", Name = "Italy" },
                new Country { CountryID = "jp", Name = "Japan" },
                new Country { CountryID = "de", Name = "Germany" },
                new Country { CountryID = "cn", Name = "China" },
                new Country { CountryID = "mx", Name = "Mexico" },
                new Country { CountryID = "br", Name = "Brazil" },
                new Country { CountryID = "nl", Name = "Netherlands" },
                new Country { CountryID = "us", Name = "United States of America" },
                new Country { CountryID = "th", Name = "Thailand" },
                new Country { CountryID = "uy", Name = "Uruguay" },
                new Country { CountryID = "ua", Name = "Ukraine" },
                new Country { CountryID = "at", Name = "Austria" },
                new Country { CountryID = "pk", Name = "Pakistan" },
                new Country { CountryID = "zw", Name = "Zimbabwe" },
                new Country { CountryID = "fr", Name = "France" },
                new Country { CountryID = "cy", Name = "Cyprus" },
                new Country { CountryID = "ru", Name = "Russia" },
                new Country { CountryID = "fi", Name = "Finland" },
                new Country { CountryID = "sk", Name = "Slovakia" },
                new Country { CountryID = "pt", Name = "Portugal" });

            modelBuilder.Entity<Team>().HasData(
                new Team { TeamID = 1, CountryID = "ca", SportID = "curl", OlympicGameID = "winter" },
                new Team { TeamID = 2, CountryID = "se", SportID = "curl", OlympicGameID = "winter" },
                new Team { TeamID = 3, CountryID = "gb", SportID = "curl", OlympicGameID = "winter" },
                new Team { TeamID = 4, CountryID = "jm", SportID = "sled", OlympicGameID = "winter" },
                new Team { TeamID = 5, CountryID = "it", SportID = "sled", OlympicGameID = "winter" },
                new Team { TeamID = 6, CountryID = "jp", SportID = "sled", OlympicGameID = "winter" },
                new Team { TeamID = 7, CountryID = "de", SportID = "dive", OlympicGameID = "summer" },
                new Team { TeamID = 8, CountryID = "cn", SportID = "dive", OlympicGameID = "summer" },
                new Team { TeamID = 9, CountryID = "mx", SportID = "dive", OlympicGameID = "summer" },
                new Team { TeamID = 10, CountryID = "br", SportID = "cycle", OlympicGameID = "summer" },
                new Team { TeamID = 11, CountryID = "nl", SportID = "cycle", OlympicGameID = "summer" },
                new Team { TeamID = 12, CountryID = "us", SportID = "cycle", OlympicGameID = "summer" },
                new Team { TeamID = 13, CountryID = "th", SportID = "arch", OlympicGameID = "para" },
                new Team { TeamID = 14, CountryID = "uy", SportID = "arch", OlympicGameID = "para" },
                new Team { TeamID = 15, CountryID = "ua", SportID = "arch", OlympicGameID = "para" },
                new Team { TeamID = 16, CountryID = "at", SportID = "canoe", OlympicGameID = "para" },
                new Team { TeamID = 17, CountryID = "pk", SportID = "canoe", OlympicGameID = "para" },
                new Team { TeamID = 18, CountryID = "zw", SportID = "canoe", OlympicGameID = "para" },
                new Team { TeamID = 19, CountryID = "fr", SportID = "dance", OlympicGameID = "youth" },
                new Team { TeamID = 20, CountryID = "cy", SportID = "dance", OlympicGameID = "youth" },
                new Team { TeamID = 21, CountryID = "ru", SportID = "dance", OlympicGameID = "youth" },
                new Team { TeamID = 22, CountryID = "fi", SportID = "skate", OlympicGameID = "youth" },
                new Team { TeamID = 23, CountryID = "sk", SportID = "skate", OlympicGameID = "youth" },
                new Team { TeamID = 24, CountryID = "pt", SportID = "skate", OlympicGameID = "youth" });
        }

    }
}
