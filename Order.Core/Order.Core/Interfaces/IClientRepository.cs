using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrderManager.Core.Entities;

namespace OrderManager.Core.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> FetchAsync(Func<Client, bool> filter = null);
    }

}

