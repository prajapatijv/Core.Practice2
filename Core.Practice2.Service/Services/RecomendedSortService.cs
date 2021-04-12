using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Services
{
    public class RecomendedSortService : IProductSortingService
    {
        private readonly IShopperHistory shopperHistory;

        public RecomendedSortService(IShopperHistory shopperHistory)
        {
            this.shopperHistory = shopperHistory;
        }

        public async Task<IList<Product>> Sort(IList<Product> products)
        {
            //var shopperHistory = await this.shopperHistory.GetBehavior();
            //var products = shopperHistory.Select(s => s.Products);
            //products.GroupBy(x => x.)
            return null;
        }
    }
}
