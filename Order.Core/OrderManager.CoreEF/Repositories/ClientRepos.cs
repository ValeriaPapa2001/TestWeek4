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
    public class ClientRepository : IClientRepository
    {
        private readonly OrderManagerDbContext _dbContext;
        public ClientRepository(OrderManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteById(object id)
        {
            Client client = GetById(id);
            if (client == null)
                return false;
            _dbContext.Clients.Remove(client);
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

        public IEnumerable<Client> Fetch(Func<Client, bool> filter = null)
        {
            if (filter != null)
                return _dbContext.Clients.Where(filter).ToList();
            return _dbContext.Clients.ToList();
        }

        public async Task<IEnumerable<Client>> FetchAsync(Func<Client, bool> filter = null)
        {
            if (filter != null)
                return await _dbContext.Clients.Where(filter).AsQueryable().ToListAsync();
            return await _dbContext.Clients.ToListAsync();
        }

        public Client GetById(object id)
        {
            return _dbContext.Clients.Find(id);
        }

        public bool Insert(Client entity)
        {
            if (entity == null)
                return false;
            _dbContext.Clients.Add(entity);
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

        public bool Update(Client entity)
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
