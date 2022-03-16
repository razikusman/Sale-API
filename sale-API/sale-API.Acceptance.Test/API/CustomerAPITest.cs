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
        
        //create - test
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

        //retrieve - test
       // [Fact]
        /*public async Task shouldGetAsync()
        {
            //give
            Customer randomcustomer = Createcustomer();
            Customer inputcustomer = randomcustomer;
            
            int customerID = 1;
            Customer expectedcustomer =
                await this.sale_ApiBroker.GetCustomerAsync(customerID);

            //when
            Customer actualcustomer =
                await this.sale_ApiBroker.PostCustomerAsync(inputcustomer);

            //then
            actualcustomer.Should().BeEquivalentTo(expectedcustomer);

        }*/

        //update - test
        [Fact]
        public async Task shouldPutAsync()
        {
            int customerID = 4;
            
            //give
            Customer updatecustomer =
                await this.sale_ApiBroker.GetCustomerAsync(customerID);

            updatecustomer.C_Name = "updated " + updatecustomer.C_Name; //updated

            Customer expectedcustomer = updatecustomer;

            //when
            Customer actualcustomer =
                await this.sale_ApiBroker.PutCustomerAsync(customerID , updatecustomer);

            //then
            actualcustomer.Should().BeEquivalentTo(expectedcustomer);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            int customerID = 7;

            //given
            Customer actualcustomer = 
                await this.sale_ApiBroker.GetCustomerAsync(customerID);

            //when
            Customer deletedcustomer = 
                await this.sale_ApiBroker.DeleteCustomerAsync(customerID);

            //then
            actualcustomer.Should().BeEquivalentTo(deletedcustomer);
        }

    }
}
