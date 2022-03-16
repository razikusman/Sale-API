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
        private readonly string OrderRelativeURl = "Orders";

        //create
        public async ValueTask<Order> PostOrderAsync(Order order) =>
            await this.apiFactoryClient.PostContentAsync(OrderRelativeURl, order);

        //retrive
        public async ValueTask<Order> GetOrderAsync(int orderID) =>
            await this.apiFactoryClient.GetContentAsync<Order>($"{OrderRelativeURl}/{orderID}");

        //update
        public async ValueTask<Order> PutOrderAsync(int orderID, Order order) =>
            await this.apiFactoryClient.PutContentAsync<Order>($"{OrderRelativeURl}/{orderID}", order);

        //delete
        public async ValueTask<Order> DeleteOrderAsync(int orderID) =>
            await this.apiFactoryClient.DeleteContentAsync<Order>($"{OrderRelativeURl}/{orderID}");
    }
}
