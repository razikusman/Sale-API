using sale_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sale_API.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsAsync();
        Task<Item> GetItemsByIDAsync(int id);
        Task<Item> PutItemAsync(int id, Item item);
        Task<Item> PostItemAsync(Item item);
        Task<Item> DeleteItemAsync(int id);
    }
}
