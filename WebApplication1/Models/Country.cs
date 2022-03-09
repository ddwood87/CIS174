using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class Country
    {   
        [Key]
        public string CountryID { get; set; }
        public string Name { get; set; }
        public string FlagClass { 
            get {
                string flag = "flag-" + ToSlug(Name);
                return flag;
            } 
        }
        public string NameSlug
        {
            get { return ToSlug(Name); }
        }
        public string ToSlug(string inStr)
        { 
            string outStr = inStr.ToLower();
            
            if(outStr.Contains(' '))
            {
                outStr = outStr.Replace(' ', '-');                    
            }
            return outStr;
        }
    }
}
