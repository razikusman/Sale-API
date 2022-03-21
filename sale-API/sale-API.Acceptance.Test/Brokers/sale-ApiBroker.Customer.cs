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
        private readonly string CustomerRelativeURL = "api/Customers";

        //create
        public async ValueTask<Customer> PostCustomerAsync(Customer customer) =>
            await this.apiFactoryClient.PostContentAsync($"{CustomerRelativeURL}/PostCustomer", customer);

        //retrive
        public async ValueTask<Customer> GetCustomerAsync(int customerID) =>
            await this.apiFactoryClient.GetContentAsync<Customer>($"{CustomerRelativeURL}/GetCustomer/{customerID}");

        //retrive - Post
        public async ValueTask<List<Customer>> GetCustomersAsync() =>
            await this.apiFactoryClient.PostContentAsync<List<Customer>>($"{CustomerRelativeURL}/GetCustomers" , null);

        //update
        public async ValueTask<Customer> PutCustomerAsync(int customerID , Customer customer) =>
            await this.apiFactoryClient.PutContentAsync<Customer>($"{CustomerRelativeURL}/PutCustomer/{customerID}", customer);

        //delete
        public async ValueTask<Customer> DeleteCustomerAsync(int customerID) =>
            await this.apiFactoryClient.DeleteContentAsync<Customer>($"{CustomerRelativeURL}/DeleteCustomer/{customerID}");

    }
}
