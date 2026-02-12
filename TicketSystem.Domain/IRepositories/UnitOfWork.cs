using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;
using TicketSystem.Presistence.Intrfaces;

namespace TicketSystem.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Ticket> Tickets { get; }

        Task<int> SaveChangesAsync();
    }

}
