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
        public TicketRepository(TicketContext ctx) => context = ctx;

        public TicketContext Context { get { return context; } set { context = value; } }
        public void AddTicket(Ticket ticket)
        {
            
        }

    }
}
