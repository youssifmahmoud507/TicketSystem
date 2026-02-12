
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Presistence.Identity;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Presistence.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Level> Levels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}