using sale_API.Models;
using sale_API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task<List<Invoice>> DeleteInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetInvoicesByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> PostInvoiceAsync(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> PutInvoiceAsync(int id, Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
