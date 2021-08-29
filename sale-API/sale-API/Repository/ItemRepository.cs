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
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return null;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            var items = await _context.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetItemsByIDAsync(int id)
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

        public async Task<Item> PostItemAsync(Item item)
        {
            Item item1 = new Item();

            //calculation
            int excl, tax, incl;

            excl = item1.I_qty * item1.I_Price;
            tax = excl * item1.I_Tax;
            incl = excl + tax;

            //asigning
            item1.I_ExclAmount = excl;
            item1.I_Tax = tax;
            item1.I_InclAmount = incl;

            //create item
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> PutItemAsync(int id, Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
