using LostBearcat.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostBearcat
{
    public class LocalDBService
    {
        private const string DB_Name = "lostbearcat_db.db3";
        private readonly SQLiteAsyncConnection _connection;
        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Name));
            _connection.CreateTableAsync<LostItem>();

#if DEBUG
            Task.Run(async () => await DeleteAll<LostItem>());
            // Insert sample data in debug mode
            Task.Run(async () => await InsertSampleDataAsync());
#endif
        }

        private List<LostItem> GetSampleData()
        {
            return new List<LostItem>
        {
            new LostItem
            {
                ItemName = "Wallet",
                Description = "Leather wallet",
                LocationFound = "Library",
                Category = "Accessories",
                ImagePath = "wallet.png",
                DateAdded = DateTime.Now.AddDays(-2)
            },
            new LostItem
            {
                ItemName = "Keys",
                Description = "Set of house keys",
                LocationFound = "TUC",
                Category = "Other",
                ImagePath = "keys.png",
                DateAdded = DateTime.Now.AddDays(-5)
            },
            new LostItem
            {
                ItemName = "Phone",
                Description = "iPhone 16",
                LocationFound = "Langsam",
                Category = "Electronics",
                ImagePath = "phone.png",
                DateAdded = DateTime.Now.AddDays(-1)
            }
        };
        }

        private async Task InsertSampleDataAsync()
        {
            var sampleData = GetSampleData();
            foreach (var item in sampleData)
            {
                await Create(item);
            }
        }

        //Get list of lost items
        public async Task<List<LostItem>> GetLostItems()
        {
            return await _connection.Table<LostItem>().ToListAsync();
        }

        //Get lost item by id
        public async Task<LostItem> GetById(int id)
        {
            return await _connection.Table<LostItem>().Where(x => x.ItemId == id).FirstOrDefaultAsync();
        }

        //Create item
        public async Task Create(LostItem item)
        {
            await _connection.InsertAsync(item);
        }

        //Update item
        public async Task Update(LostItem item)
        {
            await _connection.UpdateAsync(item);
        }

        //Delete item
        public async Task Delete(LostItem item)
        {
            await _connection.DeleteAsync(item);
        }

        //Delete all
        public async Task DeleteAll<T>()
        {
            await _connection.DeleteAllAsync<T>();
        }


        // Get filtered lost items based on category, location, and time period
        public async Task<List<LostItem>> GetFilteredLostItems(string category, string location, string timePeriod)
        {
            var items = await GetLostItems();

            if (!string.IsNullOrEmpty(category) && category != "All Categories")
                items = items.Where(i => i.Category == category).ToList();

            if (!string.IsNullOrEmpty(location) && location != "All Locations")
                items = items.Where(i => i.LocationFound == location).ToList();

            DateTime currentDate = DateTime.Now;
            if (timePeriod != "All Time")
            {
                switch (timePeriod)
                {
                    case "Less than 7 days":
                        items = items.Where(i => (currentDate - i.DateAdded).Days < 7).ToList();
                        break;
                    case "7-14 days":
                        items = items.Where(i => (currentDate - i.DateAdded).Days >= 7 && (currentDate - i.DateAdded).Days <= 14).ToList();
                        break;
                    case "15-30 days":
                        items = items.Where(i => (currentDate - i.DateAdded).Days >= 15 && (currentDate - i.DateAdded).Days <= 30).ToList();
                        break;
                    case "More than a month":
                        items = items.Where(i => (currentDate - i.DateAdded).Days > 30).ToList();
                        break;
                }
            }

            return items;
        }

    }
    }
