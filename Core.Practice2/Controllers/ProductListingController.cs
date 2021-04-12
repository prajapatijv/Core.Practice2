using Core.Practice2.Domain.Enums;
using Core.Practice2.Domain.Models;
using Core.Practice2.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Core.Practice2.Startup;

namespace Core.Practice2.Controllers
{
    [Route("api/products")]
    public class ProductListingController : Controller
    {

        private readonly IMediator mediator;
        private readonly ServiceResolver serviceResolver;

        public ProductListingController(IMediator mediator, ServiceResolver serviceResolver)
        {
            this.mediator = mediator;
            this.serviceResolver = serviceResolver;
        }

        [HttpGet("sort/{sortOption}")]
        public async Task<IActionResult> Sort(SortOption sortOption)
        {
            var service = this.serviceResolver(sortOption);

            var sortedProducts = await this.mediator.Send(new ProductSortCommand
            {
                ProductSortingService = service
            });
            
            return Ok(sortedProducts);
        }
    }
}
