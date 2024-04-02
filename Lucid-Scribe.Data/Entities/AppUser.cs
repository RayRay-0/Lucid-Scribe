using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid_Scribe.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Dreams = new HashSet<Dream>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Dream>? Dreams { get; set; }
    }
}
