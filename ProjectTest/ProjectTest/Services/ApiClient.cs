using Microsoft.IdentityModel.JsonWebTokens;
using ProjectTest.Common;
using ProjectTest.Database;
using ProjectTest.Model;
using ProjectTest.Services.Infrastructure;
using ProjectTest.Services.Interfaces;
using Refit;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Services
{
    public class ApiClient : BaseClient
    {
        private string baseAPIUrl = AppGlobals.ApiURL;


        internal ApiClient() : base()
        {
            BaseUrl = baseAPIUrl;
        }


        public async Task<UserModel> Login(string username, string password)
        {

            UserDatabase database = await UserDatabase.Instance;
            return await database.LogIn(username, password);

        }

        public async Task<bool> Signup(string username, string password)
        {
            var user = new UserModel()
            {

                username = username,
                password = password
            };
            UserDatabase database = await UserDatabase.Instance;
            return await database.SaveItemAsync(user) > 0;

        }

        public async Task<List<ProductModel>> GetProduct()
        {
            var c = new HttpClient();
            c.BaseAddress = new System.Uri(BaseUrl);
            var api = RestService.For<IApiClient>(c);
            var list = await api.GetProduct();

            return list;
        }
    }

}
