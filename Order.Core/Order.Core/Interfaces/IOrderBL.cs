using OrderManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface IOrderBL
    {
        
        IEnumerable<Order> GetAllOrders();
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Order GetOrderByCode(string code);

        bool InsertOrder(Order order);

        bool UpdateOrder(Order order);

        bool DeleteOrderByCode(string code);
    }
}
