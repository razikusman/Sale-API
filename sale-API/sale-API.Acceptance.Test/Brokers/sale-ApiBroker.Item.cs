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
        private readonly string ItemRelativeURL = "Items";

        //create
        public async ValueTask<Item> PostItemAsync(Item item) =>
            await this.apiFactoryClient.PostContentAsync(ItemRelativeURL, item);

        //retrive
        public async ValueTask<Item> GetItemAsync(int itemID) =>
            await this.apiFactoryClient.GetContentAsync<Item>($"{ItemRelativeURL}/{itemID}");

        //update
        public async ValueTask<Item> PutItemAsync(int itemID, Item item) =>
            await this.apiFactoryClient.PutContentAsync<Item>($"{ItemRelativeURL}/{itemID}", item);

        //delete
        public async ValueTask<Item> DeleteItemAsync(int itemID) =>
            await this.apiFactoryClient.DeleteContentAsync<Item>($"{ItemRelativeURL}/{itemID}");

    }
}
