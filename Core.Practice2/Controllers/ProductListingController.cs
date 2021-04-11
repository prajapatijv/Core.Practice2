using Core.Practice2.Domain.Enums;
using Core.Practice2.Domain.Models;
using Core.Practice2.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Practice2.Controllers
{
    [Route("api/products")]
    public class ProductListingController : Controller
    {

        private readonly IMediator mediator;

        public ProductListingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("sort/{sortOption}")]
        public IActionResult Sort(SortOption sortOption)
        {
            var sortedProducts = this.mediator.Send(new ProductSortCommand { SortOption = sortOption });
            return Ok(sortedProducts);
        }
    }
}
