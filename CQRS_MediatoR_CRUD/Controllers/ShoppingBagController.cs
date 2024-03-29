﻿using CQRS_MediatorR_Library.Commands;
using CQRS_MediatorR_Library.DTOs;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatoR_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingBagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingBagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingBag>>> Get()
        {
            var shoppingBags = await _mediator.Send(new GetShoppingBagListQuery());
            return Ok(shoppingBags);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingBag>> Post([FromBody] ShoppingBag value)
        {
            var command = new InsertShoppingBagCommand(value.Name);
            var createdShoppingBag = await _mediator.Send(command);
            return Ok(createdShoppingBag);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingBagById(int id)
        {
            var query = new GetShoppingBagByIdQuery(id);
            var shoppingBag = await _mediator.Send(query);

            return Ok(shoppingBag);
        }
        [HttpGet("Get-Meats-Only")]
        public async Task<ActionResult<List<ShoppingBagDTO>>> GetShoppingBagWith2OrMoreMeatsOnly([FromQuery] Types productType, [FromQuery] int minItemCount)
        {
            var query = new GetAllMeatItemsQuery(productType, minItemCount);
            var shoppingBag = await _mediator.Send(query);

            return Ok(shoppingBag);
        }
    }
}
