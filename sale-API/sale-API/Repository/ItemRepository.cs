using sale_API.Models;
using sale_API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository
{
    public class ItemRepository : IItemRepository
    {
        public Task<List<Item>> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> PostItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> PutItemAsync(int id, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
