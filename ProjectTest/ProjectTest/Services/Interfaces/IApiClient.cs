using ProjectTest.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Services.Interfaces
{
    [Headers("Accept: application/json", "Content-Type: application/json")]
    public interface IApiClient
    {
        [Get("/products")]
        Task<List<ProductModel>> GetProduct();
    }
}
