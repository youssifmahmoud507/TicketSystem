using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Entities
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public int DoctorID { get; set; }

        public string SubjectId { get; set; }

        public int LevelID { get; set; }
       public  string Title { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public  TicketStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }






    }
}
