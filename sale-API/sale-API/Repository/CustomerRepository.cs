using Microsoft.EntityFrameworkCore;
using sale_API.Models;
using sale_API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDBContext _context;

        public CustomerRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
            {
                return null;
            }

            _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _context.Customers
                                                    .Include(cus => cus.Orders)
                                                    .Include(cus => cus.invoices)
                                                    .ToListAsync();
            return customers;

        }

        public async Task<Customer> GetCustomersByIDAsync(int id)
        {
            var customers = await _context.Customers
                                             .Include(cus => cus.Orders)
                                             .Include(cus => cus.invoices)
                                             .Where(cus => cus.CustomerID == id)
                                             .FirstOrDefaultAsync();
            if (customers == null)
            {
                return null;
            }

            return customers ;
        }

        public async Task<Customer> PostCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> PutCustomerAsync(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            
            return customer;
        }
    }
}
