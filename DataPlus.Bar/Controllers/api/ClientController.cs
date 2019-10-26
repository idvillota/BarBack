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
            _logger.LogInfo("Fetching all clients from database");
            var clients = _clientService.GetAll();
            _logger.LogInfo($"Returning {clients.Count} clients.");
            return Ok(clients);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInfo($"Filtering client with id{id}");
            var client = _clientService.GetById(id);
            _logger.LogInfo($"Returned client with id:{id}");
            return Ok(client);
        }

        // POST: api/Client
        [HttpPost]
        public IActionResult Post(Client client)
        {
            _logger.LogInfo("Creating client");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"ClientController::Post::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _clientService.Create(client);
            _logger.LogInfo($"Created client with id:{client.Id}");
            return Ok(client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Client client)
        {
            _logger.LogInfo($"Editing client with id {client.Id}");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"ClientController::Put::ModelStateInvalid");
                return BadRequest(ModelState);
            }
            _clientService.Update(client);
            _logger.LogInfo($"Editing client with id:{client.Id}");
            return Ok(client);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInfo($"Deleting client with id {id}");
            var client = _clientService.GetById(id);
            if (client.Id == Guid.Empty)
            {
                _logger.LogError($"ClientController::Delete::Client with id {id} not found");
                return NotFound();
            }
            _clientService.Delete(client);
            _logger.LogInfo($"Delete client with id: {client.Id}");
            return Ok(client);
        }
    }
}
