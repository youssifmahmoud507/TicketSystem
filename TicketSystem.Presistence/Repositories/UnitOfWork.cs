using System;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.IRepositories;
using TicketSystem.Presistence.DbContext;
using TicketSystem.Presistence.Repositories;

namespace TicketSystem.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IGenericRepository<Ticket> _ticketRepository;
        private IGenericRepository<Message> _messageRepository;
        private IGenericRepository<Subject> _subjectRepository;
        private IGenericRepository<Level> _levelRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IGenericRepository<Ticket> Tickets
            => _ticketRepository ??= new GenericRepository<Ticket>(_context);

        public IGenericRepository<Message> Messages
            => _messageRepository ??= new GenericRepository<Message>(_context);

        public IGenericRepository<Subject> Subjects
            => _subjectRepository ??= new GenericRepository<Subject>(_context);

        public IGenericRepository<Level> Levels
            => _levelRepository ??= new GenericRepository<Level>(_context);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
            
        public async Task RollbackAsync()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(x => x.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                await entry.ReloadAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
