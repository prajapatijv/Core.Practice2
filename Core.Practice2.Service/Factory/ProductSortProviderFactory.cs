using Core.Practice2.Domain.Enums;
using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Service.Services;
using System;

namespace Core.Practice2.Service.Factory
{
    public static class ProductSortProviderFactory
    {
        public static IProductSortingService GetInstance(SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return new AscendingPriceSortService();
                case SortOption.High:
                    return new DescendingPriceSortService();
                case SortOption.Ascending:
                    return new AscendingSortService();
                case SortOption.Decending:
                    return new DescendingSortService();
                case SortOption.Recommended:
                    return new RecomendedSortService();
                default:
                    throw new InvalidOperationException("Not supported sort option");
            }
        }
    }
}
