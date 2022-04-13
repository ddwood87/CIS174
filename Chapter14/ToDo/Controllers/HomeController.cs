using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Service;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        //private TicketContext context;

        private ITicketService service;
        public HomeController(ITicketService serv) => service = serv;

        // GET: HomeController
        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Sprints = service.GetSprints().ToList();
            ViewBag.Statuses = service.GetStatuses().ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;
            ViewBag.Points = Ticket.PossPoints;
            var tasks = service.GetTickets(filters);
            tasks = tasks.OrderBy(t => t.Sprint.DueDate).ToList();
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
            ViewBag.Sprints = service.GetSprints().ToList();
            ViewBag.Statuses = service.GetStatuses().ToList();
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
                task.Sprint = service.GetSprint(task.SprintId);
                task.Status = service.GetStatus(task.StatusId);
                if (task.SprintId == -1)
                {
                    task.Sprint.DueDate = DateTime.Today.AddDays(7);
                }


                service.AddTicket(task);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "There are errors in the form.");
                ViewBag.Sprints = service.GetSprints().ToList();
                ViewBag.Statuses = service.GetStatuses().ToList();
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
        public ActionResult EditStatus([FromQuery] string id, Ticket selected)
        {
            if (id == "remove")
            {
                service.RemoveTicket(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = service.GetTicket(selected.Id);
                selected.StatusId = newStatusId;
                service.UpdateTicket(selected);
            }

            return RedirectToAction("Index", new { Id = id });
        }
        public ActionResult Delete([FromQuery] int id, string filter)
        {
            var ticket = service.GetTicket(id);
            service.RemoveTicket(ticket);
            return RedirectToAction("Index", new { Id = filter });
        }
    }
}
