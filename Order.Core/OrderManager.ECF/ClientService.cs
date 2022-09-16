using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using OrderManager.CoreEF.Repositories;
using OrderManager.Core.BusinessLogic;
using OrderManager.CoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.WCF
{
    public class ClientService : IClientService
    {
        private readonly IClientBL _logic;
        public ClientService()
        {
            var dbContext = new OrderManagerDbContext();
            IClientRepository clientRepository = new ClientRepository(dbContext);
            _logic = new ClientBL(clientRepository);

        }

        public bool CreateClient(Client client)
        {
            return _logic.InsertClient(client);
        }

        public bool DeleteClientById(int id)
        {
            return _logic.DeleteClientById(id);
        }

        public IEnumerable<Client> FetchClients()
        {
            return _logic.GetAllClient();
        }

        public bool UpdateClient(Client client)
        {
            return _logic.UpdateClient(client);
        }
    }
}
