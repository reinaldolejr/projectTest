using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectTest.Model;
using ProjectTest.Common;
using System.Threading.Tasks;

namespace ProjectTest.Database
{
    public class UserDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<UserDatabase> Instance = new AsyncLazy<UserDatabase>(async () =>
        {
            var instance = new UserDatabase();
            CreateTableResult result = await Database.CreateTableAsync<UserModel>();
            return instance;
        });

        public UserDatabase()
        {
            Database = new SQLiteAsyncConnection(AppGlobals.DatabasePath, AppGlobals.Flags);
        }

        public Task<List<UserModel>> GetItemsAsync()
        {
            return Database.Table<UserModel>().ToListAsync();
        }


        public Task<UserModel> GetItemAsync(int id)
        {
            return Database.Table<UserModel>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<UserModel> LogIn(string username, string password)
        {
            return Database.Table<UserModel>().Where(i => i.username == username && i.password == password).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserModel item)
        {
            if (item.id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(UserModel item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
