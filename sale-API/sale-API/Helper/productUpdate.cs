using Microsoft.EntityFrameworkCore;
using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Helper
{
    public class productUpdate
    {
        private readonly SalesDBContext _context;

        public productUpdate(SalesDBContext context)
        {
            _context = context;

        }

        public async Task<Order> Makeorder(Order order)
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
        
    }
}
