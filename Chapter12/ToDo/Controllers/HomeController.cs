using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        // GET: HomeController
        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;
            ViewBag.Points = Ticket.PossPoints;

            IQueryable<Models.Ticket> query = context.Tickets
                .Include(t => t.Sprint).Include(t => t.Status);
            if (filters.HasSprint)
            {
                query = query.Where(t => t.SprintId == filters.SprintId);
            }
            if (filters.HasMinPoints)
            {
                query = query.Where(t => t.Points >= filters.MinPoints);
            }
            if (filters.HasMaxPoints)
            {
                query = query.Where(t => t.Points <= filters.MaxPoints);
            }
            if (filters.HasStatus) 
            { 
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                {
                    query = query.Where(t => t.Sprint.DueDate < today);
                }
                if (filters.IsFuture)
                {
                    query = query.Where(t => t.Sprint.DueDate > today);
                }
                if (filters.IsToday)
                {
                    query = query.Where(t => t.Sprint.DueDate == today);
                }
            }
            var tasks = query.OrderBy(t => t.Sprint.DueDate).ToList();
            return View(tasks);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Add
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.Points = Ticket.PossPoints;
            return View();
        }


        // POST: HomeController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Ticket task)
        {
            if (ModelState.IsValid) 
            {
                task.Sprint = context.Sprints.First(s => s.SprintId == task.SprintId);
                task.Status = context.Statuses.First(s => s.StatusId == task.StatusId);
                if(task.SprintId == -1)
                {
                    task.Sprint.DueDate = DateTime.Today.AddDays(7);
                }
                
           
                    context.Tickets.Add(task);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "There are errors in the form.");
                    ViewBag.Sprints = context.Sprints.ToList();
                    ViewBag.Statuses = context.Statuses.ToList();
                    ViewBag.Points = Ticket.PossPoints;
                    return View(task);
                }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        public ActionResult Edit([FromQuery] string id, Ticket selected)
        {
            if(selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Tickets.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { Id = id });
        }
    }
}
