using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FirstResponsiveWebAppWood.Models
{
    public class UserAge
    {
        private const int MIN_AGE = 0;
        private const int MAX_AGE = 125;

        [Required(ErrorMessage = "You must enter a name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must enter a birth year.")]
        public int? BirthYear { get; set; }

        [Range(MIN_AGE, MAX_AGE, ErrorMessage = "The birth year must be between {2} years ago and this year.")]
        public int? AgeThisYear
        {
            get{ return ThisYear - BirthYear; }
        }

        private static int ThisYear
        {
            get { return DateTime.Now.Year; }
        }
    }
}
