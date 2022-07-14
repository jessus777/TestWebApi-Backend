﻿using Application.Features.Order.Commands.AddOrder;
using Application.Features.Order.Commands.CreateOrder;
using Application.Features.Order.Commands.CreateOrderAndDetail;
using Application.Features.Order.Commands.UpdateOrderStatus;
using Application.Features.Order.Queries.GetAllByOrderStatus;
using Application.Features.Order.Queries.GetAllOrders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiTest.Controllers
{
    public class OrderController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }

        [HttpGet("GetAllOrdersByStatus")]
        public async Task<IActionResult> GetAllOrdersByStatus(int statusType)
        {
            return Ok(await Mediator.Send(new GetAllOrdersByStatusQuery { StatusType = statusType}));
        }

        [HttpGet("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok(await Mediator.Send(new CreateOrderCommand()));
        }

        [HttpPut("UpdateOrderByStatusType")]
        public async Task<IActionResult> UpdateOrderByStatusType(UpdateOrderStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> Post(AddOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("AddOrderAndDetails")]
        public async Task<IActionResult> AddOrderAndDetails(CreateOrderAndDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
