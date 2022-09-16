using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;
using OrderManager.Core.Entities;

namespace OrderManager.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FetchAsync(Func<Order, bool> filter = null);
    }
}
