using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;


namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoockController: ControllerBase 
    {
        private readonly CoockRepository _coockRep;
        public CoockController(IRepository<Coock> coockRep)
        {
            this._coockRep = (CoockRepository)coockRep;
        }

        [HttpGet]
        [Route("Coocks")]
        public async Task<IEnumerable<Coock>> GetCoock()
        {
            return await _coockRep.GetAll();
        }

        [HttpGet]
        [Route("CoockById")]
        public async Task<IActionResult> GetCoockById(int id)
        {
            try
            {
                var coock = await _coockRep.GetByIdAsync(id);
                return Ok(coock);
            }
            catch(InvalidOperationException)
            {
                return NotFound("Coock does not exist");
            }
        }

        [HttpPost]
        [Route("AddCoock")]
        public IActionResult AddCoock(Coock coock)
        {
            var validationContext = new ValidationContext(coock);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(coock, validationContext, validationResults, true);
            if (isValid)
            {
                if (_coockRep.AddInstance(coock))
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
        [Route("DeleteCoock")]
        public IActionResult DeleteCoock(int id)
        {
            if (_coockRep.DeleteInstance(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdateCoock")]
        public IActionResult UpdateCoock(Coock coock)
        {
            var validationContext = new ValidationContext(coock);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(coock, validationContext, validationResults, true);
            if (isValid)
            {
                if (_coockRep.UpdateInstance(coock))
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
