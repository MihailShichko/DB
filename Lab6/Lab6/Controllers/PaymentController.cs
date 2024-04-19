using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentRepository _paymentRep;
        public PaymentController(IRepository<Payment> paymentRep)
        {
            this._paymentRep = (PaymentRepository)paymentRep;
        }

        [HttpGet]
        [Route("Payments")]
        public async Task<IEnumerable<Payment>> GetPaymnets()
        {
            return await _paymentRep.GetAll();
        }

        [HttpGet]
        [Route("PaymnetById")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var paymnet = await _paymentRep.GetByIdAsync(id);
                return Ok(paymnet);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Paymnet does not exist");
            }
        }

        [HttpPost]
        [Route("AddPayment")]
        public IActionResult AddReview(Payment payment)
        {
            var validationContext = new ValidationContext(payment);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(payment, validationContext, validationResults, true);
            if (isValid)
            {
                if (_paymentRep.AddInstance(payment))
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
        [Route("DeletePayment")]
        public IActionResult DeletePayment(int id)
        {
            if (_paymentRep.DeleteInstance(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdatePayment")]
        public IActionResult UpdatePayment(Payment payment)
        {
            var validationContext = new ValidationContext(payment);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(payment, validationContext, validationResults, true);
            if (isValid)
            {
                if (_paymentRep.UpdateInstance(payment))
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
