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
            try
            {
                var orders = _orderService.GetAll();
                _logger.LogInfo("Returned all orders from database");
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::Get::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var order = _orderService.GetById(id);
                //var order = _orderService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned order with id:{id}");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post(Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OrderController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _orderService.Create(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OrderController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _orderService.Update(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::Put::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var order = _orderService.GetById(id);
                if (order.Id == Guid.Empty)
                {
                    _logger.LogError($"OrderController::Delete::Order with id {id} not found");
                    return NotFound();
                }
                _orderService.Delete(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::Delete::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
