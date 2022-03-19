using Microsoft.AspNetCore.Mvc;
using OlympicGames.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    [BindProperties(SupportsGet = true)]
    public class TeamListViewModel: TeamViewModel
    {
        public IEnumerable<Team> Teams { get; set; }

        private IEnumerable<OlympicGame> games;
        public IEnumerable<OlympicGame> Games
        {
            get => games;
            set { 
                games = value;
                games.Prepend(new OlympicGame { OlympicGameID = "all", Name = "all" });
            }
        }
        private IEnumerable<Sport> sports;
        public IEnumerable<Sport> Sports
        {
            get => sports;
            set
            {
                sports = value;
                sports.Prepend(new Sport { SportID = "all", Name = "All" });
            }
        }
        private IEnumerable<Country> countries;
        public IEnumerable<Country> Countries
        {
            get => countries;
            set
            {
                countries = value;
                countries.Prepend(new Country { CountryID = "all", Name = "All" });
            }
        }
        public string CheckActiveGames(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveSports(string s) =>
            s.ToLower() == ActiveSport.ToLower() ? "active" : "";
        public void GetComplexMembers(OlympicsContext context)
        {
            this.Countries = context.Countries;
            this.Games = context.Games;
            this.Sports = context.Sports;
        }
    }
}
