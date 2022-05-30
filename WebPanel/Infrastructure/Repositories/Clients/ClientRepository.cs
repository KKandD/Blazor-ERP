using Core.Entities.Clients;
using Core.Interfaces.Clients;
using Core.Interfaces.Users;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Clients
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IDbContextFactory<AppDbContext> dbContextFactory, ICurrentApplicationUserService currentApplicationUserService)
            : base(dbContextFactory, currentApplicationUserService)
        {

        }
    }
}
