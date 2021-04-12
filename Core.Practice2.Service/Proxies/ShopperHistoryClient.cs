using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Proxies
{
    public class ShopperHistoryClient : IShopperHistory
    {
        private readonly HttpClient client;
        private readonly ILogger<ShopperHistoryClient> logger;

        /// <summary>
        /// This should typially be in StartUp.cs
        /// </summary>
        private string ApiKey = Environment.GetEnvironmentVariable("ApiKey");
        private const string BaseUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=={0}";

        public ShopperHistoryClient(ILogger<ShopperHistoryClient> logger, HttpClient client)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<IList<ShopperHistory>> GetBehavior()
        {
            try
            {
                using (var response = await client.GetAsync(string.Format(BaseUrl, ApiKey)))
                {
                    response.EnsureSuccessStatusCode();
                    var history = JsonConvert.DeserializeObject<IList<ShopperHistory>>(await response.Content.ReadAsStringAsync());
                    return history;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong when calling shopper history api");
                throw;
            }
        }
    }
}
