using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderSummation.Controllers.api
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ILoggerManager _logger;
        private IOrderService _orderService;

        public OrderController(ILoggerManager logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            _logger.LogInfo("Fetching all orders from database");
            var orders = _orderService.GetAll();
            _logger.LogInfo($"Returning {orders.Count} orders.");
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInfo($"Filtering order with id{id}");
            var order = _orderService.GetById(id);
            _logger.LogInfo($"Returned order with id:{id}");
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post(Order order)
        {
            _logger.LogInfo("Creating order");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"OrderController::Post::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _orderService.Create(order);
            _logger.LogInfo($"Created client with id:{order.Id}");
            return Ok(order);

        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Order order)
        {
            _logger.LogInfo($"Editing order with id {order.Id}");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"OrderController::Put::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _orderService.Update(order);
            _logger.LogInfo($"Editing order with id:{order.Id}");
            return Ok(order);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //try
            //{
            //    var order = _orderService.GetById(id);
            //    if (order.Id == Guid.Empty)
            //    {
            //        _logger.LogError($"OrderController::Delete::Order with id {id} not found");
            //        return NotFound();
            //    }
            //    _orderService.Delete(order);
            //    return Ok(order);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"OrderController::Delete::{ex.Message}");
            //    return StatusCode(500, "Internal Server Error");
            //}

            return null;
        }
    }
}
