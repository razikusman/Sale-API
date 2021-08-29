using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> GetOrdersByIDAsync(int id);
        Task<List<Order>> PutOrderAsync(int id, Order order);
        Task<List<Order>> PostOrderAsync(Order order);
        Task<List<Order>> DeleteOrderAsync(int id);
    }
}
