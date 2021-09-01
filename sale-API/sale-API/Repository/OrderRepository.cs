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
                order = await this.MakeOrder(order);

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
                if (id != order.OrderID)
                {
                    throw new Exception();
                }

                //get the previous saved Item
                /*var P_order = await _context.Ordders
                                    .Where(pord => pord.OrderID == id)
                                    .FirstOrDefaultAsync();
                int qty = P_order.O_qty;

                if (order.O_qty == qty)
                {
                    _context.Entry(order).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return order;
                }*/

                //get the calculated orede
                order = await MakeOrder(order);

                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception)
            {

                throw new Exception ();
            }

           
        }

        //calculating order
        public async Task<Order> MakeOrder(Order order) 
        {

            var item = await _context.Items
                                    .Where(itm => itm.ItemID == order.ItemID)
                                    .FirstOrDefaultAsync();

            //calculation
            int excl, tax, incl;

            excl = order.O_qty * item.I_Price;
            tax = excl * item.I_Tax / 100;
            incl = excl + tax;

            //asigning
            order.O_ExclAmount = excl;
            order.O_TaxAmount = tax;
            order.O_InclAmount = incl;

            return order;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
