using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;

namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _ClientRep;
        public ClientController(IRepository<Client> clientRep)
        {
            this._ClientRep = (ClientRepository)clientRep;
        }

        [HttpGet]
        [Route("Clients")]
        public async Task<IEnumerable<Client>> GetClients() 
        {
            return await _ClientRep.GetAll();
        }

        [HttpGet]
        [Route("ClientById")]   
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _ClientRep.GetByIdAsync(id);
                return Ok(client);
            }
            catch(InvalidOperationException) 
            {
                return NotFound("Client does not exist");
            }
        }

        [HttpPost]
        [Route("AddClient")]
        public IActionResult AddClient(Client client)
        {
            var validationContext = new ValidationContext(client);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(client, validationContext, validationResults, true);
            if (isValid)
            {
                if (_ClientRep.AddInstance(client))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to save");
                }
            }
            else
            { 
                return BadRequest("Json is not valid");    
            }
        }

        [HttpPost]
        [Route("DeleteClient")]
        public IActionResult DeleteClient(int id)
        {
            if(_ClientRep.DeleteInstance(id))
            { 
                return Ok();
            }
            else 
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdateClient")]
        public IActionResult UpdateClient(Client client) 
        {
            var validationContext = new ValidationContext(client);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(client,validationContext, validationResults, true);
            if(isValid)
            {
                if (_ClientRep.UpdateInstance(client))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed to save");
                }
            }
            else
            {
                return BadRequest("Json is not valid");
            }
        }
    }
}