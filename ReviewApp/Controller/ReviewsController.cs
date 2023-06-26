using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using ReviewApp.Repository;

namespace ReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRespository _reviewRespository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRespository reviewRespository , IMapper mapper)
        {
            _reviewRespository = reviewRespository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetReviews()
        {
            var reviwes = _mapper.Map<List<ReviewsDTO>>(_reviewRespository.GetReviews());
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            return Ok(reviwes);


        }

        [HttpGet("{reviewID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviews>))]
        [ProducesResponseType(400)]

        public IActionResult GetReview(int reviewID)
        {
            if (!_reviewRespository.ReviewExists(reviewID))
            {
                return NotFound();
            }

            var character = _mapper.Map<ReviewsDTO>(_reviewRespository.GetReview(reviewID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(character);
        }


        [HttpGet("character/{characterID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviews>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewsOfCharacter( int characterID)
        {
            var review = _mapper.Map<List<ReviewsDTO>>(_reviewRespository.GetReviewsOfCharacter(characterID));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(review);



        }



    }
}
