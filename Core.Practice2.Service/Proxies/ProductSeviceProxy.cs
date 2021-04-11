using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Proxies
{
    public class ProductSeviceProxy : IProductSeviceProxy
    {
        public Task<IList<Product>> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
