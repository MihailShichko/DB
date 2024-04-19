using Lab6.Models;
using Lab6.Server.Services.Repository;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace Lab6.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController: ControllerBase
    {
        private readonly ReviewRepository _reviewRep;
        public ReviewController(IRepository<Review> reviewRep)
        {
            this._reviewRep = (ReviewRepository)reviewRep;
        }

        [HttpGet]
        [Route("Reviews")]
        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _reviewRep.GetAll();
        }

        [HttpGet]
        [Route("ReviewById")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewRep.GetByIdAsync(id);
                return Ok(review);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Review does not exist");
            }
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(Review review)
        {
            var validationContext = new ValidationContext(review);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(review, validationContext, validationResults, true);
            if (isValid)
            {
                if (_reviewRep.AddInstance(review))
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
        [Route("DeleteReview")]
        public IActionResult DeleteMenu(int id)
        {
            if (_reviewRep.DeleteInstance(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to delete");
            }
        }

        [HttpPost]
        [Route("UpdateReview")]
        public IActionResult UpdateReview(Review review)
        {
            var validationContext = new ValidationContext(review);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(review, validationContext, validationResults, true);
            if (isValid)
            {
                if (_reviewRep.UpdateInstance(review))
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
