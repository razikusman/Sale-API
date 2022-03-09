using FluentAssertions;
using sale_API.Acceptance.Test.Brokers;
using sale_API.Acceptance.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace sale_API.Acceptance.Test.API
{
    [Collection(nameof(ApiTestCollection))]
    public class CustomerAPITest
    {
        private readonly sale_ApiBroker sale_ApiBroker;

        public CustomerAPITest(sale_ApiBroker sale_ApiBroker) =>
            this.sale_ApiBroker = sale_ApiBroker;

        private Customer Createcustomer() =>
            new Filler<Customer>().Create();

        [Fact]
        public async Task shouldPostAsync()
        {
            //give
            Customer randomcustomer = Createcustomer();
            Customer inputcustomer = randomcustomer;
            Customer expectedsustomer = inputcustomer;

            //when
            Customer actualcustomer =
                await this.sale_ApiBroker.PostCustomerAsync(inputcustomer);

            //then
            actualcustomer.Should().BeEquivalentTo(expectedsustomer);

        }

        //testdelete
        [Fact]
        public async Task shouldDeleteAsync()
        {
            //delete
            int customerID = 5;
            await this.sale_ApiBroker.DeleteCustomerAsync(customerID);
        }

    }
}
