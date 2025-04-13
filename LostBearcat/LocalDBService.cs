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
    }
}
