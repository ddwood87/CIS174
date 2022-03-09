using Microsoft.AspNetCore.Http;
using OlympicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Data
{
    public class OlympicCookies
    {
        private const string MyTeams = "myteams";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public OlympicCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public OlympicCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }
        public void SetMyTeamIds(IEnumerable<Team> myteams)
        {
            List<string> ids = myteams.Select(t => t.TeamID.ToString()).ToList();
            string idsString = string.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyTeamIds();
            responseCookies.Append(MyTeams, idsString, options);
        }
        public string[] GetMyTeamIds()
        {
            string cookie = requestCookies[MyTeams];
            if (string.IsNullOrEmpty(cookie))
            {
                return new string[] { };
            }
            else
            {
                return cookie.Split(Delimiter);
            }
        }
        public void RemoveMyTeamIds()
        {
            responseCookies.Delete(MyTeams);
        }
    }
}
