using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Presistence.Identity
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
    }

}
