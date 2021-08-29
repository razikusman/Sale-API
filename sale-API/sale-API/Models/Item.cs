using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public String I_Code { get; set; }
        public String I_Description { get; set; }
        public String I_Note { get; set; }
        public int I_Price { get; set; }
        public int I_qty { get; set; }
        public int I_Tax { get; set; }
        public int I_ExclAmount { get; set; }
        public int I_TaxAmount { get; set; }
        public int I_InclAmount { get; set; }

        //foreign key invoice
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
