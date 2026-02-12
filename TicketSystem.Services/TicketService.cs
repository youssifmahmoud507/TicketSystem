using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.IRepositories;

namespace TicketSystem.Services
{
    public class TicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTicket(Ticket ticket)
        {
            await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _unitOfWork.Tickets.GetAllAsync();
        }
    }

}
