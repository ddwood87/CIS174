using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassWebApp.Models;
using ClassWebApp.Areas.Admin.Models;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
namespace ClassWebApp.Data
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options) : base(options){ }
        public ClassContext() : base() { }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
