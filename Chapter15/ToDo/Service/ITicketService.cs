using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Repository;

namespace ToDoApp.Service
{
    public interface ITicketService
    {
        public Ticket GetTicket(int id);
        public IEnumerable<Ticket> GetTickets(object filter);
        public Sprint GetSprint(int id);
        public IEnumerable<Sprint> GetSprints();
        public IEnumerable<Status> GetStatuses();
        Status GetStatus(string id);
        void AddTicket(Ticket task);
        void RemoveTicket(Ticket selected);
        void UpdateTicket(Ticket selected);
    }
}
