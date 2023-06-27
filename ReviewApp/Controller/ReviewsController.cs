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
        private readonly ICharacterRespsoitory _characterRespsoitory;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRespository reviewRespository,ICharacterRespsoitory characterRespsoitory
            ,IReviewerRepository reviewerRepository,IMapper mapper)
        {
            _reviewRespository = reviewRespository;
            _characterRespsoitory = characterRespsoitory;
            _reviewerRepository = reviewerRepository;
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

        public IActionResult GetReviewsOfCharacter(int characterID)
        {
            var review = _mapper.Map<List<ReviewsDTO>>(_reviewRespository.GetReviewsOfCharacter(characterID));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(review);



        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateReview([FromQuery] int reviewerId , [FromQuery] int characterId ,[FromBody] ReviewsDTO reviewCreate)
        {
            if (reviewCreate == null)
            {
                return BadRequest();
            }

            var reviews = _reviewRespository.GetReviews().Where(c =>
                c.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (reviews != null)
            {
                ModelState.AddModelError("", "Review Already Exists");

                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var reviewMap = _mapper.Map<Reviews>(reviewCreate);

            reviewMap.character = _characterRespsoitory.GetCharacter(characterId);
            reviewMap.reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!_reviewRespository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created !");



        }



        [HttpPut("{reviewID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReview(int reviewID, [FromBody] ReviewsDTO reviewUpdate)
        {
            if (UpdateReview == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewID != reviewUpdate.Id)
            {
                return BadRequest(ModelState);

            }

            if (!_reviewerRepository.ReviewerExists(reviewID))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var reviewMap = _mapper.Map<Reviews>(reviewUpdate);

            if (!_reviewRespository.UpdateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Reviews");
                return StatusCode(500, ModelState);

            }


            return Ok("successfullt updated !");

        }
    }
}
