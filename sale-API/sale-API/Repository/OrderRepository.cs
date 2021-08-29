using Microsoft.EntityFrameworkCore;
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
        private readonly SalesDBContext _context;

        public OrderRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            var order = await _context.Ordders.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            _context.Ordders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _context.Ordders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrdersByIDAsync(int id)
        {
            var order = await _context.Ordders
                                             .Where(ord => ord.OrderID == id)
                                             .FirstOrDefaultAsync();
            if (order == null)
            {
                return null;
            }

            return order;
        }

        public async Task<Order> PostOrderAsync(Order order)
        {
            _context.Ordders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> PutOrderAsync(int id, Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return order;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
