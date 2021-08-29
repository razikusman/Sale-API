using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    public interface ICustomerRepository 
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomersByIDAsync(int id);
        Task<Customer> PutCustomerAsync(int id , Customer customer);
        Task<Customer> PostCustomerAsync(Customer customer);
        Task<Customer> DeleteCustomerAsync(int id);
    }
}
