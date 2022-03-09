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
    }
}
