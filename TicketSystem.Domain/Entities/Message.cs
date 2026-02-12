using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Entities
{
        public class Message
        {
            public Guid Id { get; set; }

            public Guid TicketId { get; set; }

            public Guid SenderId { get; set; }

            public string Content { get; set; }

            public DateTime SentAt { get; set; }
        }

    }
