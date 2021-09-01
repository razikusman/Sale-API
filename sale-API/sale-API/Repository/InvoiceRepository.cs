using Microsoft.EntityFrameworkCore;
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
        private readonly SalesDBContext _context;

        public InvoiceRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<Invoice> DeleteInvoiceAsync(int id)
        {
            try
            {
                var invoice = await _context.Invoices.FindAsync(id);
                if (invoice == null)
                {
                    return null;
                }

                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();

                return invoice;
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            try
            {
                var invoices = await _context.Invoices
                                                .Include(inv => inv.Orders)
                                                .ToListAsync();
                return invoices;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Invoice> GetInvoicesByIDAsync(int id)
        {
            try
            {
                var invoice = await _context.Invoices
                                                 .Include(inv => inv.Orders)
                                                 .Where(inv => inv.InvoiceID == id)
                                                 .FirstOrDefaultAsync();
                if (invoice == null)
                {
                    return null;
                }

                return invoice;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Invoice> PostInvoiceAsync(Invoice invoice)
        {
            try
            {
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                return invoice;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Invoice> PutInvoiceAsync(int id, Invoice invoice)
        {
            try
            {
                if (id != invoice.InvoiceID)
                {
                    throw new Exception();
                }

                _context.Entry(invoice).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return invoice;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
    }
}
