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
        public Task<List<Customer>> DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> PostCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> PutCustomerAsync(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
