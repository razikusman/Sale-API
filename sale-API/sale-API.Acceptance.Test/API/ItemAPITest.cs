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
    public class ItemAPITest
    {
        private readonly sale_ApiBroker sale_ApiBroker;

        public ItemAPITest(sale_ApiBroker sale_ApiBroker) =>
            this.sale_ApiBroker = sale_ApiBroker;

        private Item Createitem() =>
            new Filler<Item>().Create();
        
        //create - test
        [Fact]
        public async Task shouldPostAsync()
        {
            //give
            Item randomitem = Createitem();
            Item inputitem = randomitem;
            Item expectedsustomer = inputitem;

            //when
            Item actualitem =
                await this.sale_ApiBroker.PostItemAsync(inputitem);

            //then
            actualitem.Should().BeEquivalentTo(expectedsustomer);

        }

        //retrieve - test
      /*  [Fact]
        public async Task shouldGetAsync()
        {
            //give
            Item randomitem = Createitem();
            Item inputitem = randomitem;
            
            int itemID = 5;
            Item expecteditem =
                await this.sale_ApiBroker.GetItemAsync(itemID);

            //when
            Item actualitem =
                await this.sale_ApiBroker.PostItemAsync(inputitem);

            //then
            actualitem.Should().BeEquivalentTo(expecteditem);

        }*/

        //update - test
        [Fact]
        public async Task shouldPutAsync()
        {
            int itemID = 3;
            
            //give
            Item updateitem =
                await this.sale_ApiBroker.GetItemAsync(itemID);

            updateitem.I_Note = "updated " + updateitem.I_Note; //updated

            Item expecteditem = updateitem;

            //when
            Item actualitem =
                await this.sale_ApiBroker.PutItemAsync(itemID , updateitem);

            //then
            actualitem.Should().BeEquivalentTo(expecteditem);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            int itemID =3;

            //given
            Item actualitem = 
                await this.sale_ApiBroker.GetItemAsync(itemID);

            //when
            Item deleteditem = 
                await this.sale_ApiBroker.DeleteItemAsync(itemID);

            //then
            actualitem.Should().BeEquivalentTo(deleteditem);
        }

    }
}
