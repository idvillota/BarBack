//using DataPlus.Bar.Contracts.Logger;
//using DataPlus.Bar.Contracts.Services;
//using DataPlus.Bar.Entities.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;

//namespace PaymentSummation.Controllers.api
//{    
//    [Route("api/payment")]
//    [ApiController]
//    public class PaymentController : ControllerBase
//    {
//        private ILoggerManager _logger;
//        private IPaymentService _paymentService;

//        public PaymentController(ILoggerManager logger, IPaymentService paymentService)
//        {
//            _logger = logger;
//            _paymentService = paymentService;
//        }

//        // GET: api/Payment
//        [HttpGet]
//        public IActionResult GetAllPayments()
//        {
//            try
//            {
//                var payments = _paymentService.GetAll();
//                _logger.LogInfo("Returned all payments from database");
//                return Ok(payments);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"PaymentController::Get::{ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }
//        }

//        // GET: api/Payment/5
//        [HttpGet("{id}")]
//        public IActionResult Get(Guid id)
//        {
//            try
//            {
//                var payment = _paymentService.GetById(id);
//                //var payment = _paymentService.GetByIdWithDetails(id);
//                _logger.LogInfo($"Returned payment with id:{id}");
//                return Ok(payment);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"PaymentController::GetById::{ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }

//        }

//        // POST: api/Payment
//        [HttpPost]
//        public IActionResult Post(Payment payment)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    _logger.LogError($"PaymentController::Post::ModelStateInvalid");
//                    return BadRequest(ModelState);
//                }
//                _paymentService.Create(payment);
//                return Ok(payment);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"PaymentController::Post::{ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }
//        }

//        // PUT: api/Payment/5
//        [HttpPut("{id}")]
//        public IActionResult Put(Guid id, Payment payment)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    _logger.LogError($"PaymentController::Put::ModelStateInvalid");
//                    return BadRequest(ModelState);
//                }
//                _paymentService.Update(payment);
//                return Ok(payment);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"PaymentController::Put::{ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id)
//        {
//            try
//            {
//                var payment = _paymentService.GetById(id);
//                if (payment.Id == Guid.Empty)
//                {
//                    _logger.LogError($"PaymentController::Delete::Payment with id {id} not found");
//                    return NotFound();
//                }
//                _paymentService.Delete(payment);
//                return Ok(payment);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"PaymentController::Delete::{ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }
//        }
//    }
//}
