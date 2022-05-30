using Core.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Clients
{
    public interface IClientService
    {
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
    }
}
