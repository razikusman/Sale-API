using sale_API.Acceptance.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_API.Acceptance.Test.Brokers
{
    public partial class sale_ApiBroker
    {
        private readonly string InvoiceRelativeURl = "Invoices";

        //create
        public async ValueTask<Invoice> PostInvoiceAsync(Invoice invoice) =>
            await this.apiFactoryClient.PostContentAsync(InvoiceRelativeURl, invoice);

        //retrive
        public async ValueTask<Invoice> GetInvoiceAsync(int invoiceID) =>
            await this.apiFactoryClient.GetContentAsync<Invoice>($"{InvoiceRelativeURl}/{invoiceID}");

        //update
        public async ValueTask<Invoice> PutInvoiceAsync(int invoiceID, Invoice invoice) =>
            await this.apiFactoryClient.PutContentAsync<Invoice>($"{InvoiceRelativeURl}/{invoiceID}", invoice);

        //delete
        public async ValueTask<Invoice> DeleteInvoiceAsync(int invoiceID) =>
            await this.apiFactoryClient.DeleteContentAsync<Invoice>($"{InvoiceRelativeURl}/{invoiceID}");
    }
}
