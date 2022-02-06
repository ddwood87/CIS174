using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWood.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Name = "Bill",
                    Email = "bill@billshouse.org",
                    Note = "This is Bill."
                },
                new Contact
                {
                    Id = 2,
                    Name = "Ken Micheals",
                    Phone = "515-555-8765",
                    Email = "ken@mikesplace.net",
                    Note = "Best Friend"
                }
            );
        }
    }
}
