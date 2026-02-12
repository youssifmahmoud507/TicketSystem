using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Domain.Common;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.IRepositories;

namespace TicketSystem.Services
{
    public class TicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task CreateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResult<Ticket>> GetAllTicketsAsync(int pageNumber = 1, int pageSize = 10)
            => await _unitOfWork.Tickets.GetAllAsync(pageNumber, pageSize);

        public async Task<Ticket> GetTicketByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ticket id", nameof(id));

            return await _unitOfWork.Tickets.GetByIdAsync(id);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            _unitOfWork.Tickets.Update(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(Guid id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            if (ticket == null)
                throw new InvalidOperationException("Ticket not found");

            _unitOfWork.Tickets.Delete(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(int status)
            => await _unitOfWork.Tickets.FindAsync(t => (int)t.Status == status);
    }
}
