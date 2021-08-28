using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    interface IItemRepository
    {
        Task<List<Item>> GetItemsAsync();
        Task<List<Item>> GetItemsByIDAsync(int id);
        Task<List<Item>> PutItemAsync(int id, Item item);
        Task<List<Item>> PostItemAsync(Item item);
        Task<List<Item>> DeleteItemAsync(int id);
    }
}
