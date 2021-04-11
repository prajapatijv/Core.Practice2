using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Services
{
    public class AscendingSortService : IProductSortingService
    {
        public async Task<IList<Product>> Sort(IList<Product> products)
        {
            if (products == null) return null;

            return products.OrderBy(o => o.Name).ToList();
        }
    }
}
