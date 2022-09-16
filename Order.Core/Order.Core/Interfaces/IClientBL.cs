using OrderManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface IClientBL
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        IEnumerable<Client> GetAllClient();
        Client GetClientById(int id);

        bool InsertClient(Client client);

        bool UpdateClient(Client client);

        bool DeleteClientById(int id);
    }
}
