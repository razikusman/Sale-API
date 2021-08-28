using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<List<Invoice>> GetInvoicesByIDAsync(int id);
        Task<List<Invoice>> PutInvoiceAsync(int id, Invoice invoice);
        Task<List<Invoice>> PostInvoiceAsync(Invoice invoice);
        Task<List<Invoice>> DeleteInvoiceAsync(int id);
    }
}
