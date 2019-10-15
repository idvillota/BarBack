using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderSummation.Controllers.api
{    
    [Route("api/payment")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ILoggerManager _logger;
        private IOrderService _paymentService;

        public OrderController(ILoggerManager logger, IOrderService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var payments = _paymentService.GetAll();
                _logger.LogInfo("Returned all payments from database");
                return Ok(payments);
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
                var payment = _paymentService.GetById(id);
                //var payment = _paymentService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned payment with id:{id}");
                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post(Order payment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OrderController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _paymentService.Create(payment);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OrderController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Order payment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OrderController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _paymentService.Update(payment);
                return Ok(payment);
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
            //try
            //{
            //    var payment = _paymentService.GetById(id);
            //    if (payment.Id == Guid.Empty)
            //    {
            //        _logger.LogError($"OrderController::Delete::Order with id {id} not found");
            //        return NotFound();
            //    }
            //    _paymentService.Delete(payment);
            //    return Ok(payment);
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
