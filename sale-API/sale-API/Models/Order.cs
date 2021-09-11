using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int O_qty { get; set; }
        public int O_ExclAmount { get; set; }
        public int O_TaxAmount { get; set; }
        public int O_InclAmount { get; set; }


        //foreign key invoice
        public int InvoiceID { get; set; }
        //public virtual Invoice Invoice { get; set; }
    }
}
