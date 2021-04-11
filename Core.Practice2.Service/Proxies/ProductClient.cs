using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace Core.Practice2.Service.Proxies
{
    public class ProductClient : IProductClient
    {
        private readonly HttpClient client;
        private readonly ILogger<ProductClient> logger;

        private const string ApiKey = "";
        private const string BaseUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token={0}";
        
        public ProductClient(ILogger<ProductClient> logger, HttpClient client)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task <IList<Product>> GetProducts()
        {
            try
            {
                using (var response = await client.GetAsync(string.Format(BaseUrl, ApiKey)))
                {
                    response.EnsureSuccessStatusCode();
                    var products = JsonConvert.DeserializeObject<IList<Product>>(await response.Content.ReadAsStringAsync());
                    return products;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong when calling products api");
                throw;
            }
        }
    }
}
