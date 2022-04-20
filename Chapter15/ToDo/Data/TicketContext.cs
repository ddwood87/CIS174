using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;
namespace ToDoApp.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime startDate = new DateTime(2022, 3, 15);
            modelBuilder.Entity<Sprint>().HasData(new Sprint() { SprintId = -1, DueDate = null, Name = "No Sprint" });
            for (int i = 0; i < 10; i++) {
                modelBuilder.Entity<Sprint>().HasData(                
                    new Sprint { SprintId = i+1, DueDate = startDate.AddDays(i * 7) });
            }
                modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprog", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance"},
                new Status { StatusId = "done", Name = "Done"}
                );
            for(int i = 0; i < 10; i=i+2)
            {
                Random random = new Random();
                modelBuilder.Entity<Ticket>().HasData(
                    new Ticket
                    {
                        Id = i + 1,
                        Name = "Ticket " + (i+1),
                        Description = "Job Number " + (i+1),
                        Points = random.Next(1, 11),
                        SprintId = (i/2) + 1,
                        StatusId = "todo"
                    },
                    new Ticket
                    {
                        Id = i + 2,
                        Name = "Ticket " + (i + 2),
                        Description = "Job Number " + (i + 2),
                        Points = random.Next(1, 11),
                        SprintId = (i / 2) + 1,
                        StatusId = "inprog"
                    });
            }
        }
    }
}
