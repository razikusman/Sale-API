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

        public async ValueTask<Customer> PostCustomerAsync(Customer customer) =>
            await this.apiFactoryClient.PostContentAsync(CustomerRelativeURL, customer);
    }
}
