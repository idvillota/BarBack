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
            _logger.LogInfo("Fetching all ingredients from database");
            var ingredients = _ingredientService.GetAll();
            _logger.LogInfo($"Returning {ingredients.Count} ingredients.");
            return Ok(ingredients);
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInfo($"Filtering ingredient with id{id}");
            var ingredient = _ingredientService.GetById(id);
            _logger.LogInfo($"Returned ingredient with id:{id}");
            return Ok(ingredient);
        }

        // POST: api/Ingredient
        [HttpPost]
        public IActionResult Post(Ingredient ingredient)
        {
            _logger.LogInfo("Creating ingredient");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"IngredientController::Post::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _ingredientService.Create(ingredient);
            _logger.LogInfo($"Created ingredient with id:{ingredient.Id}");
            return Ok(ingredient);
        }

        // PUT: api/Ingredient/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Ingredient ingredient)
        {
            _logger.LogInfo($"Editing ingredient with id {ingredient.Id}");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"IngredientController::Put::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _ingredientService.Update(ingredient);
            _logger.LogInfo($"Editing ingredient with id:{ingredient.Id}");
            return Ok(ingredient);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInfo($"Deleting ingredient with id {id}");
            var ingredient = _ingredientService.GetById(id);
            if (ingredient.Id == Guid.Empty)
            {
                _logger.LogError($"IngredientController::Delete::Ingredient with id {id} not found");
                return NotFound();
            }
            _ingredientService.Delete(ingredient);
            _logger.LogInfo($"Delete ingredient with id: {id}");
            return Ok(ingredient);
        }
    }
}
