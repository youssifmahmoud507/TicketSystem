using System;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Ticket> Tickets { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<Subject> Subjects { get; }
        IGenericRepository<Level> Levels { get; }

        Task<int> SaveChangesAsync();

        Task RollbackAsync();
    }
}
