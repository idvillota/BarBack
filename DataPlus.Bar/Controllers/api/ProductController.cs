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
            _logger.LogInfo("Fetching all products from database");
            var products = _productService.GetAll();
            _logger.LogInfo($"Returning {products.Count} products.");
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInfo($"Filtering product with id{id}");
            var product = _productService.GetById(id);
            _logger.LogInfo($"Returned product with id:{id}");
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post(Product product)
        {
            _logger.LogInfo("Creating product");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"ProductController::Post::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _productService.Create(product);
            _logger.LogInfo($"Created product with id:{product.Id}");
            return Ok(product);

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Product product)
        {
            _logger.LogInfo($"Editing product with id {product.Id}");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"ProductController::Put::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _productService.Update(product);
            _logger.LogInfo($"Editing product with id:{product.Id}");
            return Ok(product);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInfo($"Deleting product with id {id}");
            var product = _productService.GetById(id);
            if (product.Id == Guid.Empty)
            {
                _logger.LogError($"ProductController::Delete::Product with id {id} not found");
                return NotFound();
            }
            _productService.Delete(product);
            _logger.LogInfo($"Delete product with id: {id}");
            return Ok(product);

        }
    }
}
