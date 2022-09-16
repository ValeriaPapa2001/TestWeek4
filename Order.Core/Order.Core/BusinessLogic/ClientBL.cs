using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.BusinessLogic
{
    public class ClientBL : IClientBL
    {
        private readonly IClientRepository _clientRepository;

        public ClientBL(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool DeleteClientById(int id)
        {
            return _clientRepository.DeleteById(id);
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _clientRepository.Fetch();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.FetchAsync();
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public bool InsertClient(Client client)
        {
            return _clientRepository.Insert(client);
        }

        public bool UpdateClient(Client client)
        {
            return _clientRepository.Update(client);
        }
    }
}
