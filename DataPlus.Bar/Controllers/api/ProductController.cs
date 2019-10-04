using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ProductSummation.Controllers.api
{    
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILoggerManager _logger;
        private IProductService _productService;

        public ProductController(ILoggerManager logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAll();
                _logger.LogInfo("Returned all products from database");
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductController::Get::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}/account")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);
                //var product = _productService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned product with id:{id}");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"ProductController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _productService.Create(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"ProductController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _productService.Update(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductController::Put::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product.Id == Guid.Empty)
                {
                    _logger.LogError($"ProductController::Delete::Product with id {id} not found");
                    return NotFound();
                }
                _productService.Delete(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductController::Delete::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
