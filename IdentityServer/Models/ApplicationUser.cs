using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual Guid ApplicationUserId { get; set; }
        public virtual UserTypes Type { get; set; }
        public virtual DateTime? LastValidationTime { get; set; }

        public virtual DateTime CreationDate { get; set; }

    }
}
