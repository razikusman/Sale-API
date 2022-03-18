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

            Item inputOrderItem = await this.sale_ApiBroker.GetItemAsync(inputorder.ItemID);
            expectedorder.O_ExclAmount = inputOrderItem.I_Price * inputorder.O_qty;
            expectedorder.O_TaxAmount = expectedorder.O_ExclAmount * inputOrderItem.I_Tax / 100;
            expectedorder.O_InclAmount = expectedorder.O_TaxAmount + expectedorder.O_ExclAmount ;

            /*Invoice inputOrderInvoice = await this.sale_ApiBroker.GetInvoiceAsync(inputorder.InvoiceID);
            expectedorder.Invoice = inputOrderInvoice;*/

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
            //give
            Order randomorder = Createorder();
            Order inputorder = randomorder;
            inputorder.ItemID = 1;
            inputorder.InvoiceID = 1;


            await this.sale_ApiBroker.PostOrderAsync(inputorder);

            Order updateorder = await this.sale_ApiBroker.GetOrderAsync(inputorder.OrderID);

            updateorder.O_qty  = 1 + updateorder.O_qty;


            //when
            Order expectedorder =
                await this.sale_ApiBroker.PutOrderAsync(updateorder.OrderID, updateorder);

            Item inputOrderItem = await this.sale_ApiBroker.GetItemAsync(inputorder.ItemID);
            expectedorder.O_ExclAmount = inputOrderItem.I_Price * inputorder.O_qty;
            expectedorder.O_TaxAmount = expectedorder.O_ExclAmount * inputOrderItem.I_Tax / 100;
            expectedorder.O_InclAmount = expectedorder.O_TaxAmount + expectedorder.O_ExclAmount;

            //then
            expectedorder.Should().BeEquivalentTo(updateorder);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {//give
            Order randomorder = Createorder();
            Order inputorder = randomorder;
            inputorder.ItemID = 1;
            inputorder.InvoiceID = 1;

            await this.sale_ApiBroker.PostOrderAsync(inputorder);

            Order expectedorder = inputorder;
            //when
            Order deletedorder =
                await this.sale_ApiBroker.DeleteOrderAsync(inputorder.OrderID);

            Item inputOrderItem = await this.sale_ApiBroker.GetItemAsync(inputorder.ItemID);
            expectedorder.O_ExclAmount = inputOrderItem.I_Price * inputorder.O_qty;
            expectedorder.O_TaxAmount = expectedorder.O_ExclAmount * inputOrderItem.I_Tax / 100;
            expectedorder.O_InclAmount = expectedorder.O_TaxAmount + expectedorder.O_ExclAmount;

            //then
            expectedorder.Should().BeEquivalentTo(deletedorder);
        }

    }
}
