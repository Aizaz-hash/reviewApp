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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRespository _ownerRespository;
        private readonly IMapper _mapper;
        private readonly ICountryRespository _countryRepository;

        public OwnerController(IOwnerRespository ownerRespository , 
            ICountryRespository countryRespository,IMapper mapper)
        {
            _ownerRespository = ownerRespository;
            _countryRepository = countryRespository;
            _mapper = mapper;
           
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDTO>>(_ownerRespository.GetOwners());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRespository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var category = _mapper.Map<OwnerDTO>(_ownerRespository.GetOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetCharacterByOwner(int ownerId)
        {
            if (!_ownerRespository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var owner = _mapper.Map<List<CharacterDTO>>(
                _ownerRespository.GetCharacterByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDTO ownerCreate)
        {
            if (ownerCreate == null)
            {
                return BadRequest();
            }

            var owner = _ownerRespository.GetOwners().Where(c =>
                c.lastName.Trim().ToUpper() == ownerCreate.lastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "Owner Already Exists");

                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var onwerMap = _mapper.Map<Owner>(ownerCreate);
            onwerMap.country = _countryRepository.GetCountry(countryId);

            if (!_ownerRespository.CreateOwner(onwerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created !");

        }

        [HttpPut("{ownerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult updateOwner(int ownerId, [FromBody] OwnerDTO ownerUpdate)
        {
            if (updateOwner == null)
            {
                return BadRequest(ModelState);
            }

            if (ownerId != ownerUpdate.Id)
            {
                return BadRequest(ModelState);

            }

            if (!_ownerRespository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var ownerMap = _mapper.Map<Owner>(ownerUpdate);

            if (!_ownerRespository.UpdateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating Owner");
                return StatusCode(500, ModelState);

            }


            return Ok("successfullt updated !");

        }


        [HttpDelete("{ownerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteOwner (int ownerId)
        {
            if (!_ownerRespository.OwnerExists(ownerId))
            {
                return BadRequest(ModelState);
            }

            var owner = _ownerRespository.GetOwner(ownerId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!_ownerRespository.DeleteOwner(owner))
            {
                ModelState.AddModelError("", "Somethign went wrong while deleting Owner");

                return StatusCode(500, ModelState);
            }


            return Ok("Successfully Deleted !");
        }






    }
}
