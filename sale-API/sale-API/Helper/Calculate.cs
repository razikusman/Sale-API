using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Helper
{
    public abstract class Calculate
    {
        public abstract Task<Order> Makeorder(Order order, Order P_order);
        public abstract Task<Order> Makeorder(Order order);
    }
}
