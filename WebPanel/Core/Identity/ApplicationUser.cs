using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastTimeChangedPassword { get; set; }
        public decimal Salary { get; set; }
    }
}
