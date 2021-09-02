using Microsoft.EntityFrameworkCore;
using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Helper
{
    public class productUpdate : Calculate
    {
        private readonly SalesDBContext _context;

        public productUpdate(SalesDBContext context)
        {
            _context = context;

        }

        //varibles for calculation
        int tax, excl, incl;

        public override async Task<Order> Makeorder(Order order)
        {

            var item = await _context.Items
                                    .Where(itm => itm.ItemID == order.ItemID)
                                    .FirstOrDefaultAsync();

            //calculation
            
            excl = order.O_qty * item.I_Price;
            tax = excl * item.I_Tax / 100;
            incl = excl + tax;

            //asigning
            order.O_ExclAmount = excl;
            order.O_TaxAmount = tax;
            order.O_InclAmount = incl;

            
            return order;
        }

        public override async Task<Order> Makeorder(Order order, Order P_order)
        {
            order.O_ExclAmount = P_order.O_ExclAmount;
            order.O_InclAmount = P_order.O_InclAmount;
            order.O_TaxAmount = P_order.O_TaxAmount;

            return order;
        }

    }
}
