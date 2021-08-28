using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime O_date { get; set; }


        //foriegn key Customer
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
