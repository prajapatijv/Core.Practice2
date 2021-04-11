using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Services
{
    public class DescendingPriceSortService : IProductSortingService
    {
        public async Task<IList<Product>> Sort(IList<Product> products)
        {
            if (products == null) return null;

            return products.OrderByDescending(o => o.Price).ToList();
        }
    }
}
