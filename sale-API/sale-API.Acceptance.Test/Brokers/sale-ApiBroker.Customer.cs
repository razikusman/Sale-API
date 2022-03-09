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
        private readonly string CustomerRelativeURL = "Customers";

        //create
        public async ValueTask<Customer> PostCustomerAsync(Customer customer) =>
            await this.apiFactoryClient.PostContentAsync(CustomerRelativeURL, customer);

        //retrive
        public async ValueTask<Customer> GetCustomerAsync(int customerID) =>
            await this.apiFactoryClient.GetContentAsync<Customer>($"{CustomerRelativeURL}/{customerID}");

        //update
        public async ValueTask<Customer> PutCustomerAsync(int customerID , Customer customer) =>
            await this.apiFactoryClient.PutContentAsync<Customer>($"{CustomerRelativeURL}/{customerID}", customer);

        //delete
        public async ValueTask<Customer> DeleteCustomerAsync(int customerID) =>
            await this.apiFactoryClient.DeleteContentAsync<Customer>($"{CustomerRelativeURL}/{customerID}");

    }
}
