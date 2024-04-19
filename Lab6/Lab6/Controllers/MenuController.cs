using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController: ControllerBase
    {
        private readonly MenuRepository _menuRep;
        public MenuController(IRepository<Menu> menuRep)
        {
            this._menuRep = (MenuRepository)menuRep;
        }

        [HttpGet]
        [Route("Menu")]
        public async Task<IEnumerable<Menu>> GetMenu()
        {
            return await _menuRep.GetAll();
        }

        [HttpGet]
        [Route("MenuById")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            try
            {
                var menu = await _menuRep.GetByIdAsync(id);
                return Ok(menu);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Menu does not exist");
            }
        }

        [HttpPost]
        [Route("AddMenu")]
        public IActionResult AddClient(Menu menu)
        {
            var validationContext = new ValidationContext(menu);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(menu, validationContext, validationResults, true);
            if (isValid)
            {
                if (_menuRep.AddInstance(menu))
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
        [Route("DeleteMenu")]
        public IActionResult DeleteMenu(int id)
        {
            if (_menuRep.DeleteInstance(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdateMenu")]
        public IActionResult UpdateClient(Menu menu)
        {
            var validationContext = new ValidationContext(menu);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(menu, validationContext, validationResults, true);
            if (isValid)
            {
                if (_menuRep.UpdateInstance(menu))
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
