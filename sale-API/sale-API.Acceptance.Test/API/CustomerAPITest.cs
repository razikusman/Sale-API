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
        [Fact]
        public async Task shouldGetAsync()
        {
            //give
            Customer randomcustomer = Createcustomer();
            Customer inputcustomer = randomcustomer;
            
            Customer expectedcustomer =
                await this.sale_ApiBroker.GetCustomersAsync();

            //when
            /* Customer actualcustomer =
                 await this.sale_ApiBroker.PostCustomerAsync(inputcustomer);*/

            //then
            //expectedcustomer.Should().;

        }

        //update - test
        [Fact]
        public async Task shouldPutAsync()
        {
            //give
            Customer randomcustomer = Createcustomer();
            Customer inputcustomer = randomcustomer;
            
            await this.sale_ApiBroker.PostCustomerAsync(inputcustomer);

            Customer updatecustomer= await this.sale_ApiBroker.GetCustomerAsync( inputcustomer.CustomerID);

            updatecustomer.C_Name = "updated " + updatecustomer.C_Name;


            //when
            Customer expectedcustomer =
                await this.sale_ApiBroker.PutCustomerAsync(updatecustomer.CustomerID, updatecustomer);

            //then
            expectedcustomer.Should().BeEquivalentTo(updatecustomer);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            //given
            Customer randomcustomer = Createcustomer();
            Customer inputcustomer = randomcustomer;
            await this.sale_ApiBroker.PostCustomerAsync(inputcustomer);
            
            Customer expectedsustomer = inputcustomer;
            //when
            Customer deletedcustomer = 
                await this.sale_ApiBroker.DeleteCustomerAsync(inputcustomer.CustomerID);

            //then
            expectedsustomer.Should().BeEquivalentTo(deletedcustomer);
        }

    }
}
