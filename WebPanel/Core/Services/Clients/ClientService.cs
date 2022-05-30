using Core.Interfaces.Clients;
using Core.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task AddAsync(Client client)
        {
            await _clientRepository.AddAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _clientRepository.DeleteAsync(entity);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.GetByIdNoTrackingAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            await _clientRepository.UpdateAsync(client);
        }
    }
}
