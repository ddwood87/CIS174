using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ITicketRepository
    {
        public TicketContext Context { get; set; }
    }
}
