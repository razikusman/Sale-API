using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String C_Name { get; set; }
        public String C_Address1 { get; set; }
        public String C_Address2 { get; set; }
        public String C_Address3 { get; set; }
        public String C_Suburb { get; set; }
        public String C_State { get; set; }
        public String C_Postcode { get; set; }

        //invices
        public virtual List<Invoice> invoices { get; set; }

        
    }
}
