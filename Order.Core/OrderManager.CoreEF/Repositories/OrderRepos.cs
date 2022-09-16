using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.CoreEF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagerDbContext _dbContext;
        public bool DeleteById(object id)
        {
            Order order = GetById(id);
            if (order == null)
                return false;
            _dbContext.Orders.Remove(order);
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Order> Fetch(Func<Order, bool> filter = null)
        {
            if (filter != null)
                return _dbContext.Orders.Where(filter).ToList();
            return _dbContext.Orders.ToList();
        }

        public async Task<IEnumerable<Order>> FetchAsync(Func<Order, bool> filter = null)
        {
            if (filter != null)
                return await _dbContext.Orders.Where(filter).AsQueryable().ToListAsync();
            return await _dbContext.Orders.ToListAsync();
        }


        public Order GetById(object id)
        {
            return _dbContext.Orders.Find(id);
        }

        public bool Insert(Order entity)
        {
            if (entity == null)
                return false;
            _dbContext.Orders.Add(entity);
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Order entity)
        {
            if (entity == null)
                return false;
            _dbContext.Attach(entity).State = EntityState.Modified;
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
