using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Data;
using OlympicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly OlympicsContext _context;

        public FavoritesController(OlympicsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Favorites")]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport(),
                Teams = session.GetTeams()
            };            
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult AddFavorite(TeamViewModel model)
        {
            model.Team = _context.Teams
                .Include(t => t.Country)
                .Include(t => t.Games)
                .Include(t => t.Sport)
                .Where(t => t.TeamID == model.Team.TeamID)
                .FirstOrDefault();
            var session = new OlympicSession(HttpContext.Session);
            var teams = session.GetTeams();
            teams = teams.Append(model.Team);
            session.SetTeams(teams);

            var cookies = new OlympicCookies(Response.Cookies);
            cookies.SetMyTeamIds(teams);

            TempData["message"] = $"{model.Team.Country.Name} | {model.Team.Sport.Name} has been added to your favorites";
            return RedirectToAction("Index", "Teams",
                new {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
        [HttpGet]
        [Route("Favorites/DeleteFavorite")]
        public RedirectToActionResult DeleteFavorite()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);
            session.RemoveMyTeams();
            cookies.RemoveMyTeamIds();
            TempData["message"] = "Favorite teams cleared!";
            return RedirectToAction("Index", "Teams",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
        [HttpGet]
        [Route("Favorites/RemoveFavorite/{teamID?}")]
        public RedirectToActionResult RemoveFavorite(int teamID)
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);
            var teams = session.GetTeams();
            Team remove = teams.Where(t => t.TeamID == teamID).First();
            List<Team> teamsList = teams.ToList();
            if (teamsList.Remove(remove))
            {
                session.SetTeams(teamsList);
                cookies.SetMyTeamIds(teamsList);
            }
            return RedirectToAction("Index");
        }
    }
}
