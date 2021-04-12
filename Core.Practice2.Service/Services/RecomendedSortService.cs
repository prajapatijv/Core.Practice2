using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Services
{
    public class RecomendedSortService : IProductSortingService
    {
        private readonly IShopperHistoryClient shopperHistory;

        public RecomendedSortService(IShopperHistoryClient shopperHistory)
        {
            this.shopperHistory = shopperHistory;
        }

        /// <summary>
        /// Order by highest quantiy accross customers.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public async Task<IList<Product>> Sort(IList<Product> products)
        {
            var shopperHistory = await this.shopperHistory.GetShopperHistor();

            var flatProducts = new List<Product>();
            shopperHistory.ToList().ForEach(a => flatProducts.AddRange(a.Products));
            var groupedProduct = flatProducts.GroupBy(k => k.Name).Select(g => new Product { Name = g.Key, Quantity = g.Sum(p => p.Quantity) }).ToList();

            products.ToList().ForEach(q => q.Quantity = groupedProduct.FirstOrDefault(f => f.Name == q.Name)?.Quantity ?? 0);

            return products.OrderByDescending(o => o.Quantity).ToList();
        }
    }
}
