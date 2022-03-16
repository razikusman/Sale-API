using FluentAssertions;
using sale_API.Acceptance.Test.Brokers;
using sale_API.Acceptance.Test.Models;
using sale_API.Helper;
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
    public class OrderAPITest
    {
        private readonly sale_ApiBroker sale_ApiBroker;

        public OrderAPITest(sale_ApiBroker sale_ApiBroker) =>
            this.sale_ApiBroker = sale_ApiBroker;

        private Order Createorder() =>
            new Filler<Order>().Create();
        
        //create - test
        [Fact]
        public async Task shouldPostAsync()
        {
            //give
            Order randomorder = Createorder();
            Order inputorder = randomorder;
            inputorder.ItemID = 1;
            inputorder.InvoiceID = 1;

            Order expectedorder =  inputorder;

            //when
            Order actualorder =
                await this.sale_ApiBroker.PostOrderAsync(inputorder);

            //then
            actualorder.Should().BeEquivalentTo(expectedorder);

        }

        //retrieve - test
       /* [Fact]
        public async Task shouldGetAsync()
        {
            //give
            Order randomorder = Createorder();
            Order inputorder = randomorder;
            
            int orderID = 5;
            Order expectedorder =
                await this.sale_ApiBroker.GetOrderAsync(orderID);

            //when
            Order actualorder =
                await this.sale_ApiBroker.PostOrderAsync(inputorder);

            //then
            actualorder.Should().BeEquivalentTo(expectedorder);

        }*/

        //update - test
        [Fact]
        public async Task shouldPutAsync()
        {
            int orderID = 4;
            
            //give
            Order updateorder =
                await this.sale_ApiBroker.GetOrderAsync(orderID);

            updateorder.O_qty = 000 + updateorder.O_qty; //updated

            Order expectedsustomer = updateorder;

            //when
            Order actualorder =
                await this.sale_ApiBroker.PutOrderAsync(orderID , updateorder);

            //then
            actualorder.Should().BeEquivalentTo(expectedsustomer);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            int orderID = 5;

            //given
            Order actualorder = 
                await this.sale_ApiBroker.GetOrderAsync(orderID);

            //when
            Order deletedorder = 
                await this.sale_ApiBroker.DeleteOrderAsync(orderID);

            //then
            actualorder.Should().BeEquivalentTo(deletedorder);
        }

    }
}
