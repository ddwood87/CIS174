using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class OlympicGame
    {
        [Key]
        public string OlympicGameID { get; set; }
        public string Name { get; set; }
    }
}
