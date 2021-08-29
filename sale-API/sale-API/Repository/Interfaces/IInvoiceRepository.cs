using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoicesByIDAsync(int id);
        Task<Invoice> PutInvoiceAsync(int id, Invoice invoice);
        Task<Invoice> PostInvoiceAsync(Invoice invoice);
        Task<Invoice> DeleteInvoiceAsync(int id);
    }
}
