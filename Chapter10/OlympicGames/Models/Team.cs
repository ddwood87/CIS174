using OlympicGames.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        public string OlympicGameID {get;set;}
        [ForeignKey("OlympicGameID")]
        public OlympicGame Games { get; set; }

        public string SportID { get; set; }
        [ForeignKey("SportID")]
        public Sport Sport { get; set; }

        public string CountryID { get; set; }
        [ForeignKey("CountryID")]
        public Country Country { get; set; }

        internal void GetComplexMembers(OlympicsContext context)
        {
            this.Games = context.Games.First(g => g.OlympicGameID == this.OlympicGameID);
            this.Sport = context.Sports.First(s => s.SportID == this.SportID);
            this.Country = context.Countries.First(c => c.CountryID == this.CountryID);
        }
    }
}
