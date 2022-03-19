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
    [BindProperties(SupportsGet = true)]
    
    public class FavoritesController : Controller
    {
        
        private readonly OlympicsContext _context;
        private OlympicSession _session;
        private TeamListViewModel _model { get; set; }
        public FavoritesController(OlympicsContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("Favorites/{action=Index}")]
        public ViewResult Index()
        {
            _session = new OlympicSession(HttpContext.Session);
            _model = new TeamListViewModel
            {
                ActiveGame = _session.GetActiveGame(),
                ActiveSport = _session.GetActiveSport(),
                Teams = _session.GetTeams()
            };            
            return View("Index", _model);
        }
        [HttpGet]
        [Route("Favorites/AddFavorite/{teamID}")]
        public IActionResult AddFavorite(int teamID)
        {
            _model = new TeamListViewModel();
            _model.Team = _context.Teams
                .Include(t => t.Country)
                .Include(t => t.Games)
                .Include(t => t.Sport)
                .Where(t => t.TeamID == teamID)
                .FirstOrDefault();
            _session = new OlympicSession(HttpContext.Session);
            var teams = _session.GetTeams();
            if (!teams.Contains(_model.Team))
            {
                teams = teams.Append(_model.Team);
                _session.SetTeams(teams);
                var cookies = new OlympicCookies(Response.Cookies);
                cookies.SetMyTeamIds(teams);
                TempData["message"] = $"{_model.Team.Country.Name} | {_model.Team.Sport.Name} has been added to your favorites";
            }
            else { TempData["message"] = $"{_model.Team.Country.Name} | {_model.Team.Sport.Name} is already a favorite."; } 

            
            return RedirectToAction("Index", "Home",
                new {
                    ActiveGame = _session.GetActiveGame(),
                    ActiveSport = _session.GetActiveSport()
                });
        }
        
        //Action to aim custom startup.cs endpoint
        [HttpGet]
        public ViewResult MyFavorites()
        {
            return Index();
        }

        [HttpGet]
        [Route("Favorites/{action}")]
        public RedirectToActionResult DeleteFavorites()
        {
            _session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);
            _session.RemoveMyTeams();
            cookies.RemoveMyTeamIds();
            TempData["message"] = "Favorite teams cleared!";
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveGame = _session.GetActiveGame(),
                    ActiveSport = _session.GetActiveSport()
                });
        }
        [HttpGet]
        [Route("Favorites/RemoveFavorite/{teamID?}")]
        public RedirectToActionResult RemoveFavorite(int teamID)
        {
            _session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);
            var teams = _session.GetTeams();
            Team remove = teams.Where(t => t.TeamID == teamID).First();
            List<Team> teamsList = teams.ToList();
            if (teamsList.Remove(remove))
            {
                _session.SetTeams(teamsList);
                cookies.SetMyTeamIds(teamsList);
            }
            return RedirectToAction("Index");
        }
    }
}
