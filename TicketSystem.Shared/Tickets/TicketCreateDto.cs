using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Shared.Tickets
{

    public class TicketCreateDto
    {
        public Guid StudentId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid SubjectId { get; set; }
        public int LevelId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
