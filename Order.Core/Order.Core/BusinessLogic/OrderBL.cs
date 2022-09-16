using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.BusinessLogic
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBL(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool DeleteOrderByCode(string code)
        {
            return _orderRepository.DeleteById(code);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.Fetch();
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.FetchAsync();
        }


        public Order GetOrderByCode(string code)
        {
            return _orderRepository.GetById(code);
        }

        public bool InsertOrder(Order order)
        {
            return _orderRepository.Insert(order);
        }

        public bool UpdateOrder(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
