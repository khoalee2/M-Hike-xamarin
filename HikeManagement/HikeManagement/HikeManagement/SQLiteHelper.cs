using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using HikeManagement.Model;

namespace HikeManagement
{
     public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath) 
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<HikeModel>();
        }
        public Task<int> CreateHike (HikeModel hike)
        {
            return db.InsertAsync(hike);
        }
        public Task<List<HikeModel>> ReadHikes()
        {
            return db.Table<HikeModel>().ToListAsync();
        }
        public Task<int>UpdateHikes(HikeModel hike)
        {
            return db.UpdateAsync(hike);
        }
        public Task<int>DeleteHike(HikeModel hike)
        {
            return db.DeleteAsync(hike);
        }
        public Task<List<HikeModel>>Search(string search)
        {
            return db.Table<HikeModel>().Where(p=>p.Name.StartsWith(search)).ToListAsync();
        }
    }
}
