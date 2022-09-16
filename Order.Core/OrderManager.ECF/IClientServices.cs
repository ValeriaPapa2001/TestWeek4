using OrderManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.WCF
{
    [ServiceContract]
    public interface IClientService
    {
        
        [OperationContract]
        IEnumerable<Client> FetchClients();

        [OperationContract]
        bool CreateClient(Client client);

        [OperationContract]
        bool UpdateClient(Client client);

        [OperationContract]
        bool DeleteClientById(int id);
    }
}
