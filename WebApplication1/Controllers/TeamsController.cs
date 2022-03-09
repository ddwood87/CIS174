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
    public class TeamsController : Controller
    {
        private readonly OlympicsContext _context;

        public TeamsController(OlympicsContext context)
        {
            _context = context;
        }

        // GET: Teams
        [HttpGet]
        [Route("{activeGame?}/{activeSport?}")]
        public IActionResult Index(string activeGame = "all", string activeSport = "all")
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);

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

            var model = new TeamListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                Countries = _context.Countries,
                Games = _context.Games,
                Sports = _context.Sports
            };
            IQueryable<Team> query = _context.Teams;
            if(activeGame != "all")
            {
                query = query.Where(t => t.Games.OlympicGameID.ToLower() == activeGame.ToLower());
            }
            if(activeSport != "all")
            {
                query = query.Where(t => t.SportID.ToLower() == activeSport.ToLower());
            }
            model.Teams = query;
            return View("Flags", model);
        }

        public IActionResult SortGames(string id)
        {
            IEnumerable<Team> items = _context.GetTeamsByGame(id);
            items = items.OrderBy(t => t.Country.Name);
            return View("Flags", items);
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
            return View("Flags", items);
        }
        [HttpPost]
        public RedirectToActionResult Details(TeamViewModel model)
        {
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Team.TeamID });
        }
        [HttpGet]
        public ViewResult Details(int id)
        {
            var model = new TeamViewModel
            {
                Team = _context.Teams
                .Include(t => t.Games)
                .Include(t => t.Sport)
                .Include(t => t.Country)
                .FirstOrDefault(t => t.TeamID == id),
                ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all",
                ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all"
            };
            return View(model);
        }
        // GET: Teams/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID")] Team team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }            
    } 
}
