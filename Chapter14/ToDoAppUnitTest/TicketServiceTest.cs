using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Repository;
using ToDoApp.Service;
using Xunit;
using ToDoAppUnitTest;

namespace ToDoAppUnitTest
{
    public class TicketServiceTest
    {
        private TicketService service;
        private Mock<Filters> filters;
        public TicketServiceTest()
        {
            TicketRepoTest testRepo = new TicketRepoTest();
            TicketContext context = testRepo.context;

            Mock<ITicketRepository> repo = new Mock<ITicketRepository>();
            repo.Setup(r => r.Context).Returns(context);
            
            //repo.Setup(r => r.Context.Tickets.ToList()).Returns(new List<Ticket>());
            //repo.Setup(r => r.Context.Sprints.Find()).Returns(new Sprint());
            //repo.Setup(r => r.Context.Sprints.ToList()).Returns(new List<Sprint>());

            filters = new Mock<Filters>("all-all-all-all-all");
            
            service = new TicketService(repo.Object);
        }
        [Fact]
        public void GetTicket_Valid()
        {
            int id = 1;
            var ticket = service.GetTicket(id);
            Assert.IsType<Ticket>(ticket);
        }
        //This test throws an exception in TestService on DbSet<>.Include()
        //The in-memory context doesn't seem to let .Include() work properly.
        [Fact]
        public void GetTickets_Valid()
        {
            var tickets = service.GetTickets(filters.Object);
            Assert.IsAssignableFrom<IEnumerable<Ticket>>(tickets);
        }
        [Fact]
        public void GetSprint_Valid()
        {
            int id = 1;
            var sprint = service.GetSprint(id);
            Assert.IsType<Sprint>(sprint);
        }
        [Fact]
        public void GetSprints_Valid()
        {
            var sprints = service.GetSprints();
            Assert.IsAssignableFrom< IEnumerable<Sprint>>(sprints);
        }
        [Fact]
        public void GetStatus_Valid()
        {
            string id = "todo";
            var status = service.GetStatus(id);
            Assert.IsType<Status>(status);
        }
        [Fact]
        public void GetStatuses_Valid()
        {
            var statuses = service.GetStatuses();
            Assert.IsAssignableFrom<IEnumerable<Status>>(statuses);
        }
    }
}
