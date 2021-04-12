﻿using Core.Practice2.Domain.Enums;
using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Commands
{
    public class ProductSortCommand : IRequest<IList<Product>>
    {
        public IProductSortingService ProductSortingService { get; set; }
    }

    public class ProductSortCommandHandler : IRequestHandler<ProductSortCommand, IList<Product>>
    {
        private readonly IProductClient productSeviceProxy;

        public ProductSortCommandHandler(IProductClient productSeviceProxy)
        {
            this.productSeviceProxy = productSeviceProxy;
        }

        public async Task<IList<Product>> Handle(ProductSortCommand request, CancellationToken cancellationToken)
        {
            var products = await this.productSeviceProxy.GetProducts();
            return await request.ProductSortingService.Sort(products);
        }
    }
}
