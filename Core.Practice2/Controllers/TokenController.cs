using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Core.Practice2.Domain.Models;
using MediatR;
using Core.Practice2.Service.Commands;

namespace Core.Practice2.Controllers
{
    [Route("api/answers")]
    public class TokenController : Controller
    {

        private readonly IMediator mediator;

        public TokenController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetToken()
        {
            var token = await this.mediator.Send(new UserTokenCommand());
            return Ok(token);
        }
    }
}
