using sale_API.Models;
using sale_API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<List<Order>> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> PostOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> PutOrderAsync(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
