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
    public class CountryController : ControllerBase
    {

        private readonly ICountryRespository _countryRespository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRespository countryRespositor, IMapper mapper)
        {
            _countryRespository = countryRespositor;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCategories()
        {
            var countries = _mapper.Map<List<CountryDTO>>(_countryRespository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryID}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryID)
        {
            if (!_countryRespository.CountryExists(countryID))
            {
                return NotFound();
            }

            var country = _mapper.Map<CountryDTO>(_countryRespository.GetCountry(countryID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(country);
        }


        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var Country = _mapper.Map<CountryDTO>(_countryRespository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Country);


        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCountry([FromBody] CountryDTO countryCreate)
        {
            if (countryCreate == null)
            {
                return BadRequest();
            }

            var country = _countryRespository.GetCountries().Where(c =>
                c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "country Already Exists");

                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryRespository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created !");

        }



        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDTO countryUpdate)
        {
            if (UpdateCountry == null)
            {
                return BadRequest(ModelState);
            }

            if (countryId != countryUpdate.Id)
            {
                return BadRequest(ModelState);

            }

            if (!_countryRespository.CountryExists(countryId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var countryMap = _mapper.Map<Country>(countryUpdate);

            if (!_countryRespository.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Country");
                return StatusCode(500, ModelState);

            }


            return Ok("successfullt updated !");

        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRespository.CountryExists(countryId))
            {
                return BadRequest(ModelState);
            }

            var country = _countryRespository.GetCountry(countryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!_countryRespository.DeleteCountry(country))
            {
                ModelState.AddModelError("", "Somethign went wrong while deleting Country");

                return StatusCode(500, ModelState);
            }


            return Ok("Successfully Deleted !");
        }
    }
}
