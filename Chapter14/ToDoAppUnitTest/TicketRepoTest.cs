using System;
using Xunit;
using ToDoApp;
using Moq;
using ToDoApp.Service;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ToDoApp.Data;
using ToDoApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ToDoAppUnitTest
{
    public class TicketRepoTest
    {
        public TicketRepository repo;
        public TicketContext context;
        public TicketRepoTest()
        {
            
            DbContextOptions<TicketContext> options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("TicketDb").Options;

            context = new TicketContext(options);
            if (context.Tickets.Count() < 1)
            {
                context.Tickets.Add(new Ticket() { Id = 1, SprintId = 1, StatusId = "done", Points = 5, Name = "First", Description = "First Description" });
                context.Tickets.Add(new Ticket() { Id = 2, SprintId = 2, StatusId = "qa", Points = 8, Name = "Second", Description = "Second Description" });
                context.Tickets.Add(new Ticket() { Id = 3, SprintId = 2, StatusId = "todo", Points = 3, Name = "Third", Description = "Third Description" });
                context.Sprints.Add(new Sprint() { SprintId = 1, DueDate = DateTime.Now.AddDays(3), Name = "Sprint 1", Tickets = context.Tickets.Where(t => t.SprintId == 1).ToList() });
                context.Sprints.Add(new Sprint() { SprintId = 2, DueDate = DateTime.Now.AddDays(5), Name = "Sprint 2", Tickets = context.Tickets.Where(t => t.SprintId == 2).ToList() });
                context.Statuses.Add(new Status() { Name = "To Do", StatusId = "todo" });
                context.Statuses.Add(new Status() { Name = "Quality Assurance", StatusId = "qa" });
                context.Statuses.Add(new Status() { Name = "Done", StatusId = "done" });
                context.SaveChanges();
            }

            repo = new TicketRepository(context);
        }
        [Fact]
        public void GetTicket_Valid()
        {
            int ticketId = 1;
            var ticket = repo.Context.Tickets.Find(ticketId);

            Assert.IsType<Ticket>(ticket);
            Assert.Equal(ticketId, ticket.Id);
        }
        [Fact]
        public void GetSprint_Valid()
        {
            int sprintId = 1;
            var sprint = repo.Context.Sprints.Find(sprintId);

            Assert.IsType<Sprint>(sprint);
            Assert.Equal(sprintId, sprint.SprintId);
        }
        [Fact]
        public void GetTickets_Valid()
        {
            var tickets = repo.Context.Tickets;

            Assert.IsAssignableFrom<IEnumerable<Ticket>>(tickets);
        }

        [Fact]
        public void UpdateTicket_Valid()
        {
            int ticketId = 2;
            var ticket = repo.Context.Tickets.Find(ticketId);

            Assert.Equal(2, ticket.SprintId);

            ticket.SprintId = 1;
            repo.Context.Tickets.Update(ticket);
            repo.Context.SaveChanges();

            Assert.Equal(1, ticket.SprintId);
        }
        [Fact]
        public void AddAndRemoveTicket_Valid()
        {
            int count = repo.Context.Tickets.Count();
            var ticket = new Ticket() { 
                Description = "", 
                Id = 4, 
                Name = "NewTicket", 
                Points = 10, 
                SprintId = 2, 
                StatusId = "" };
            repo.Context.Tickets.Add(ticket);
            repo.Context.SaveChanges();

            Assert.Equal(count + 1, repo.Context.Tickets.Count());

            var query = repo.Context.Tickets.First(t => t.Name == "NewTicket");
            Assert.Equal(4, query.Id);
            repo.Context.Remove(ticket);
            repo.Context.SaveChanges();

            Assert.Equal(count, repo.Context.Tickets.Count());
        }
    }
}
