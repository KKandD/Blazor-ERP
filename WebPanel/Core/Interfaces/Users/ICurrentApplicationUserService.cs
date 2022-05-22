using Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Users
{
    public interface ICurrentApplicationUserService
    {
        Task<ApplicationUser> GetCurrentUserAsync();
        ApplicationUser GetCurrentUser();
    }
}
