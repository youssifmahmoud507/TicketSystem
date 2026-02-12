using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Domain.Common;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.IRepositories;
using TicketSystem.Shared.Tickets;

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

        public async Task<Ticket> GetTicketByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
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

        public async Task DeleteTicketAsync(string id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            if (ticket == null)
                throw new InvalidOperationException("Ticket not found");

            _unitOfWork.Tickets.Delete(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(int status)
            => await _unitOfWork.Tickets.FindAsync(t => (int)t.Status == status);
        public async Task<IEnumerable<TicketDto>> GetTicketsByStudentAsync(Guid studentId)
        {
            var tickets = await _unitOfWork.Tickets
                .FindAsync(t => t.StudentId == studentId);

            return tickets.Select(t => new TicketDto
            {
                Id = t.Id,
                Title = t.Title,
                Status = t.Status,
                CreatedAt = t.CreatedAt
            });
        }


    }
}
