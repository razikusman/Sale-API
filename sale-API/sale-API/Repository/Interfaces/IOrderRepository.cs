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
        Task<Order> GetOrdersByIDAsync(int id);
        Task<Order> PutOrderAsync(int id, Order order);
        Task<Order> PostOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int id);
    }
}
