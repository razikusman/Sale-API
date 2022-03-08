using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Acceptance.Test.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int I_Num { get; set; }
        public DateTime I_Date { get; set; }
        public int I_RefNum { get; set; }
        public String I_Note { get; set; }


        //foriegn key Customer
        public int CustomerID { get; set; }
        /*public virtual Customer Customer { get; set; }*/


        //orders
        public virtual List<Order> Orders { get; set; }
    }
}
