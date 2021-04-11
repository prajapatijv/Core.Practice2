using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Practice2.Domain.Interfaces
{
    public interface IProductSortingService
    {
        Task<IList<Product>> Sort(IList<Product> products);
    }
}
