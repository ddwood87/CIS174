using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Service;

namespace ToDoApp.Controllers
{
    public class TicketListComponent : ViewComponent
    {
        private ITicketService service { get; set; }
        public TicketListComponent(ITicketService serv) => service = serv;
        public IViewComponentResult Invoke(IEnumerable<Ticket> model) {
            return View("TicketListPartial", model);
        }

    }
}
