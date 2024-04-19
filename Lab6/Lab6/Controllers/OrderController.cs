using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly OrderRepository _orderRep;
        public OrderController(IRepository<Order> orederRep)
        {
            this._orderRep = (OrderRepository)orederRep;
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRep.GetAll();
        }

        [HttpGet]
        [Route("OrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderRep.GetByIdAsync(id);
                return Ok(order);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Order does not exist");
            }
        }

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            var validationContext = new ValidationContext(order);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(order, validationContext, validationResults, true);
            if (isValid)
            {
                if (_orderRep.AddInstance(order))
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
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            if (_orderRep.DeleteInstance(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder(Order order)
        {
            var validationContext = new ValidationContext(order);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(order, validationContext, validationResults, true);
            if (isValid)
            {
                if (_orderRep.UpdateInstance(order))
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
