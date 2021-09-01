using Microsoft.EntityFrameworkCore;
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
        private readonly SalesDBContext _context;

        public ItemRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<Item> DeleteItemAsync(int id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);
                if (item == null)
                {
                    return null;
                }

                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            try
            {
                var items = await _context.Items.ToListAsync();
                return items;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<Item> GetItemsByIDAsync(int id)
        {
            try
            {
                var item = await _context.Items
                                             .Where(itm => itm.ItemID == id)
                                             .FirstOrDefaultAsync();
                if (item == null)
                {
                    return null;
                }

                return item;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Item> PostItemAsync(Item item)
        {
            try
            {
                //create item
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<Item> PutItemAsync(int id, Item item)
        {
            try
            {
                if (id != item.ItemID)
                {
                    throw new Exception();
                }

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
