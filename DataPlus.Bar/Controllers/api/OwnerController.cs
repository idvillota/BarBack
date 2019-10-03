using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OwnerSummation.Controllers.api
{    
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IOwnerService _ownerService;

        public OwnerController(ILoggerManager logger, IOwnerService ownerService)
        {
            _logger = logger;
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                //var owners = _ownerService.GetAll();
                var owners = _ownerService.GetAllWithAccounts();
                _logger.LogInfo("Returned all owners from database");
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerController::Get::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Owner/5
        [HttpGet("{id}/account")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //var owner = _ownerService.GetById(id);
                var owner = _ownerService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned owner with id:{id}");
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Owner
        [HttpPost]
        public IActionResult Post(Owner owner)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OwnerController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _ownerService.Create(owner);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Owner owner)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"OwnerController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _ownerService.Update(owner);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerController::Put::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var owner = _ownerService.GetById(id);
                if (owner.Id == Guid.Empty)
                {
                    _logger.LogError($"OwnerController::Delete::Owner with id {id} not found");
                    return NotFound();
                }
                _ownerService.Delete(owner);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"OwnerController::Delete::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
