using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OlympicGames.Data;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    [BindProperties(SupportsGet = true)]
    
    public class HomeController : Controller
    {
        private readonly OlympicsContext _context;
        public TeamListViewModel _model { get; set; }
        public HomeController(OlympicsContext context)
        {
            _context = context;
        }

        // GET: Teams
        [HttpGet]

        [Route("{controller=Home}/{action=Index}/{activeGame?}/{activeSport?}")]        
        public IActionResult Index() //string activeGame = "all", string activeSport = "all")
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveGame(_model.ActiveGame);
            session.SetActiveSport(_model.ActiveSport);

            int? count = session.GetMyTeamCount();
            if (count == null)
            {
                var cookies = new OlympicCookies(Request.Cookies);
                string[] ids = cookies.GetMyTeamIds();
                List<Team> myteams = new List<Team>();
                if(ids.Length > 0)
                {
                    myteams = _context.Teams.Include(t => t.Games)
                        .Include(t => t.Sport).Include(t => t.Country)
                        .Where(t => ids.Contains(t.TeamID.ToString())).ToList();
                }
                session.SetTeams(myteams);
            }

            _model.GetComplexMembers(_context);

            IQueryable<Team> query = _context.Teams;
            if(this._model.ActiveGame != "all")
            {
                query = query.Where(t => t.Games.OlympicGameID.ToLower() == this._model.ActiveGame.ToLower());
            }
            if(this._model.ActiveSport != "all")
            {
                query = query.Where(t => t.SportID.ToLower() == this._model.ActiveSport.ToLower());
            }
            _model.Teams = query;
            return View("Index", _model);
        }

        public IActionResult SortGames(string id)
        {
            IEnumerable<Team> items = _context.GetTeamsByGame(id);
            items = items.OrderBy(t => t.Country.Name);
            return View("Index", items);
        }

        public IActionResult SortType(string id)
        {
            bool indoor = false;
            if (id.Equals("indoor"))
            {
                indoor = true;
            }
            IEnumerable<Team> items = _context.GetTeamsByIndoor(indoor);
            items = items.OrderBy(t => t.Country.Name);
            return View("Index", items);
        }
        [HttpGet]
        [Route("{controller=Home}/{action=Details}/{teamID}")]
        public ViewResult Details(int teamId)
        {
            //var model = new TeamListViewModel
            //{
            _model.Team = _context.Teams.FirstOrDefault(t => t.TeamID == teamId);
            _model.Team.GetComplexMembers(_context);        
            //ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all",
            //ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all"
            //};
            return View(_model);
        }
        [HttpPost]
        public RedirectToActionResult Details(TeamViewModel model)
        {
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Team.TeamID });
        }
        
        // GET: Teams/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }            
    } 
}
