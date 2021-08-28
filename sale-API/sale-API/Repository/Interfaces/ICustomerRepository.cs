using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> GetCustomersByIDAsync(int id);
        Task<List<Customer>> PutCustomerAsync(int id , Customer customer);
        Task<List<Customer>> PostCustomerAsync(Customer customer);
        Task<List<Customer>> DeleteCustomerAsync(int id);
    }
}
