using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.Enums;
using TicketSystem.Services;
using TicketSystem.Shared.Tickets;

namespace TicketSystem.Presentation.Tickets
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
        }

        /// <summary>
        /// Create a new ticket.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                StudentId = dto.StudentId,
                DoctorId = dto.DoctorId,
                SubjectId = dto.SubjectId,
                LevelId = dto.LevelId,
                Title = dto.Title,
                Description = dto.Description,
                Group = dto.Group,
                Status = TicketStatus.New,
                CreatedAt = DateTime.UtcNow
            };

            await _ticketService.CreateTicket(ticket);

            var response = new TicketDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            };

            return Created($"api/tickets/{ticket.Id}", response);

        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetStudentTickets(Guid studentId)
        {
            if (studentId == Guid.Empty)
                return BadRequest("Invalid student id");

            var tickets = await _ticketService.GetTicketsByStudentAsync(studentId);

            return Ok(tickets);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _ticketService.GetAllTicketsAsync(pageNumber, pageSize);
            return Ok(result);
        }


    }
}
