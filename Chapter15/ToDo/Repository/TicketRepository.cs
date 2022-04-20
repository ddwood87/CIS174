using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private TicketContext context;
        public TicketRepository(TicketContext ctx) => Context = ctx;

        public TicketContext Context { get; set; }
        public IEnumerable<Ticket> GetTickets()
        {
            IQueryable<Ticket> query =  Context.Tickets.Include(t => t.Status).Include(t => t.Sprint);
            return query.ToList();
        }

    }
}
