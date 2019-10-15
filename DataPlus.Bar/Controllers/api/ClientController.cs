using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientSummation.Controllers.api
{    
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ILoggerManager _logger;
        private IClientService _clientService;

        public ClientController(ILoggerManager logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _clientService.GetAll();
                _logger.LogInfo("Returned all clients from database");
                return Ok(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientController::Get::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var client = _clientService.GetById(id);
                //var client = _clientService.GetByIdWithDetails(id);
                _logger.LogInfo($"Returned client with id:{id}");
                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientController::GetById::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST: api/Client
        [HttpPost]
        public IActionResult Post(Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"ClientController::Post::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _clientService.Create(client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientController::Post::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"ClientController::Put::ModelStateInvalid");
                    return BadRequest(ModelState);
                }
                _clientService.Update(client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientController::Put::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var client = _clientService.GetById(id);
                if (client.Id == Guid.Empty)
                {
                    _logger.LogError($"ClientController::Delete::Client with id {id} not found");
                    return NotFound();
                }
                _clientService.Delete(client);
                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientController::Delete::{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
