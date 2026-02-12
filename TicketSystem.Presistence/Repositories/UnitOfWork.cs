using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.IRepositories;
using TicketSystem.Presistence.DbContext;
using TicketSystem.Presistence.Intrfaces;

namespace TicketSystem.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Tickets = new GenericRepository<Ticket>(_context);
            // لو عندك Repositories تانية تبقى هنا
        }

        public IGenericRepository<Ticket> Tickets { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
