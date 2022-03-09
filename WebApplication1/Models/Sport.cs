using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class Sport
    {
        [Key]
        public string SportID { get; set; }
        public string Name { get; set; }
        public Boolean Indoor { get; set; }
    }
}
