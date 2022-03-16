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
    public class InvoiceAPITest
    {
        private readonly sale_ApiBroker sale_ApiBroker;

        public InvoiceAPITest(sale_ApiBroker sale_ApiBroker) =>
            this.sale_ApiBroker = sale_ApiBroker;

        private Invoice Createinvoice() =>
            new Filler<Invoice>().Create();
        
        //create - test
        [Fact]
        public async Task shouldPostAsync()
        {
            //give
            Invoice randominvoice = Createinvoice();
            Invoice inputinvoice = randominvoice;
            inputinvoice.CustomerID = 1;

            Invoice expectedinvoice = inputinvoice;

            //when
            Invoice actualinvoice =
                await this.sale_ApiBroker.PostInvoiceAsync(inputinvoice);

            //then
            actualinvoice.Should().BeEquivalentTo(expectedinvoice);

        }

        //retrieve - test
        /*[Fact]
        public async Task shouldGetAsync()
        {
            //give
            Invoice randominvoice = Createinvoice();
            Invoice inputinvoice = randominvoice;
            
            int invoiceID = 5;
            Invoice expectedinvoice =
                await this.sale_ApiBroker.GetInvoiceAsync(invoiceID);

            //when
            Invoice actualinvoice =
                await this.sale_ApiBroker.PostInvoiceAsync(inputinvoice);

            //then
            actualinvoice.Should().BeEquivalentTo(expectedinvoice);

        }*/

        //update - test
        [Fact]
        public async Task shouldPutAsync()
        {
            int invoiceID = 4;
            
            //give
            Invoice updateinvoice =
                await this.sale_ApiBroker.GetInvoiceAsync(invoiceID);

            updateinvoice.I_Note = "updated " + updateinvoice.I_Note; //updated
            updateinvoice.CustomerID = 1;

            Invoice expectedsustomer = updateinvoice;

            //when
            Invoice actualinvoice =
                await this.sale_ApiBroker.PutInvoiceAsync(invoiceID , updateinvoice);

            //then
            actualinvoice.Should().BeEquivalentTo(expectedsustomer);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            int invoiceID = 5;

            //given
            Invoice actualinvoice = 
                await this.sale_ApiBroker.GetInvoiceAsync(invoiceID);

            //when
            Invoice deletedinvoice = 
                await this.sale_ApiBroker.DeleteInvoiceAsync(invoiceID);

            //then
            actualinvoice.Should().BeEquivalentTo(deletedinvoice);
        }

    }
}
