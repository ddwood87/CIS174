using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Repository;

namespace ToDoApp.Service
{
    public class TicketService : ITicketService
    {
        private ITicketRepository repo;
        public TicketService(ITicketRepository r) => repo = r;
        public Ticket GetTicket(int id) => repo.Context.Tickets.Find(id);
        public IEnumerable<Ticket> GetTickets(object filter)
        {
            Filters filters = (Filters)filter;
            IQueryable<Ticket> query = repo.Context.Tickets.Include(t => t.Sprint).Include(t => t.Status);
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
            return query;
        }

        public Sprint GetSprint(int id)
        {
            return repo.Context.Sprints.Find(id);
        }

        public IEnumerable<Sprint> GetSprints()
        {
            return repo.Context.Sprints;
        }

        public IEnumerable<Status> GetStatuses()
        {
            return repo.Context.Statuses;
        }

        public Status GetStatus(string id)
        {
            return repo.Context.Statuses.Find(id);
        }

        public void AddTicket(Ticket ticket)
        {
            repo.Context.Tickets.Add(ticket);
            repo.Context.SaveChanges();
        }

        public void RemoveTicket(Ticket ticket)
        {
            repo.Context.Remove(ticket);
            repo.Context.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            repo.Context.Update(ticket);
            repo.Context.SaveChanges();
        }
    }
}
