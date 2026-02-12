using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public Guid DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public TicketStatus Status { get; set; } = TicketStatus.New;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
