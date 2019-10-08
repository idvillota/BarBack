using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IngredientSummation.Controllers.api
{    
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private ILoggerManager _logger;
        private IIngredientService _ingredientService;

        public IngredientController(ILoggerManager logger, IIngredientService ingredientService)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        // GET: api/Ingredient
        [HttpGet]
        public IActionResult GetAllIngredients()
        {
            try
            {
                var ingredients = _ingredientService.GetAll();
                _logger.LogInfo("Returned all ingredients from database");
                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IngredientController::Get::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var ingredient = _ingredientService.GetById(id);
                //var ingredient = _ingredientService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned ingredient with id:{id}");
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IngredientController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Ingredient
        [HttpPost]
        public IActionResult Post(Ingredient ingredient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"IngredientController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _ingredientService.Create(ingredient);
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IngredientController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Ingredient/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Ingredient ingredient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"IngredientController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _ingredientService.Update(ingredient);
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IngredientController::Put::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var ingredient = _ingredientService.GetById(id);
                if (ingredient.Id == Guid.Empty)
                {
                    _logger.LogError($"IngredientController::Delete::Ingredient with id {id} not found");
                    return NotFound();
                }
                _ingredientService.Delete(ingredient);
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IngredientController::Delete::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
