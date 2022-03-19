using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    [BindProperties(SupportsGet = true)]
    public class TeamViewModel
    {
        
        public Team Team { get; set; }
        [BindProperty]
        public string ActiveGame { get; set; } = "all";
        [BindProperty]
        public string ActiveSport { get; set; } = "all";
        public int FavoriteCount { get; set; }
    }
}
