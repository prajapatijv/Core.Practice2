using Core.Practice2.Domain.Enums;
using Core.Practice2.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Practice2.Controllers
{
    [Route("api/products")]
    public class ProductListingController : Controller
    {
        [HttpGet("sort/{sortOption}")]
        public IActionResult Sort(SortOption sortOption)
        {
            return Ok(new List<Product>());
        }
    }

    
}
