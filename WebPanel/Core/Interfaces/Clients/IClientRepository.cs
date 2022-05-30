using Core.Entities.Clients;
using Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Clients
{
    public interface IClientRepository : IRepository<Client>
    {
    }
}
