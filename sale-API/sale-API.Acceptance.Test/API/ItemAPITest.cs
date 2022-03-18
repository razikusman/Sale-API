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
            //give
            Item randomitem = Createitem();
            Item inputitem = randomitem;

            await this.sale_ApiBroker.PostItemAsync(inputitem);

            Item updateitem = await this.sale_ApiBroker.GetItemAsync(inputitem.ItemID);

            updateitem.I_Note = "updated " + updateitem.I_Note;


            //when
            Item expectedItem =
                await this.sale_ApiBroker.PutItemAsync(updateitem.ItemID, updateitem);

            //then
            expectedItem.Should().BeEquivalentTo(updateitem);
        }

        //delete - test
        [Fact]
        public async Task shouldDeleteAsync()
        {
            //give
            Item randomitem = Createitem();
            Item inputitem = randomitem;
            await this.sale_ApiBroker.PostItemAsync(inputitem);

            Item expecteditem = inputitem;
            //when
            Item deleteditem =
                await this.sale_ApiBroker.DeleteItemAsync(inputitem.ItemID);

            //then
            expecteditem.Should().BeEquivalentTo(deleteditem);
        }

    }
}
