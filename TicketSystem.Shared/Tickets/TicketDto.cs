using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Shared.Tickets
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
