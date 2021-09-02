using Microsoft.EntityFrameworkCore;
using sale_API.Helper;
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

        public OrderRepository(SalesDBContext context )
        {
            _context = context;

        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            try
            {
                var order = await _context.Ordders.FindAsync(id);
                if (order == null)
                {
                    throw new Exception("Order Not Found");
                }

                _context.Ordders.Remove(order);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                var orders = await _context.Ordders.ToListAsync();
                return orders;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Order> GetOrdersByIDAsync(int id)
        {
            try
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
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Order> PostOrderAsync(Order order)
        {
            try
            {
                //get the calculated orede
                productUpdate pr = new productUpdate(_context);

                order = await pr.Makeorder(order);

                //create order
                _context.Ordders.Add(order);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Order> PutOrderAsync(int id, Order order)
        {
            try
            {
                if (OrderExists(id))
                {
                    throw new Exception();
                }

                //get the previous saved Item
                var P_order = await GetOrdersByIDAsync(id);

                if (order.O_qty != P_order.O_qty || order.ItemID != P_order.ItemID)
                {
                    //get the calculated orede
                    productUpdate pr = new productUpdate(_context);

                    order = await pr.Makeorder(order);


                    await _context.SaveChangesAsync();



                    return order;
                }

                else
                {
                    _context.Entry(order).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return order;
                }
                
            }
            catch (Exception)
            {

                throw new Exception ();
            }

           
        }

        //calculating order
        

        private bool OrderExists(int id)
        {
            return _context.Ordders.Any(o => o.OrderID == id);
        }
    }
}
