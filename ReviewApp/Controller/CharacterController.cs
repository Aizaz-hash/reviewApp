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
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRespsoitory _characterRepository;
        private readonly IMapper _mapper;
        public CharacterController(ICharacterRespsoitory characterRepository ,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]

        public IActionResult GetCharacters()
        {
            var character = _mapper.Map<List<CharacterDTO>>( _characterRepository.GetCharacters());
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            return Ok(character);


        }

        [HttpGet("{characterId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        [ProducesResponseType(400)]

        public IActionResult GetCharacter(int characterId)
        {
            if (!_characterRepository.CharacterExists(characterId))
            {
                return NotFound();
            }

            var character = _mapper.Map<CharacterDTO>(_characterRepository.GetCharacter(characterId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(character);
        }

        [HttpGet("{characterID}/rating")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        [ProducesResponseType(400)]

        public IActionResult GetCharacterRating(int characterID)
        {
            if (!_characterRepository.CharacterExists(characterID))
            {
                return NotFound();
            }

            var rating =_characterRepository.GetCharacterRating(characterID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rating);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCharacter([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] CharacterDTO characterCreate)
        {
            if (characterCreate == null)
            {
                return BadRequest();
            }

            var characters = _characterRepository.GetCharacters().Where(c =>
                c.Name.Trim().ToUpper() == characterCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (characters != null)
            {
                ModelState.AddModelError("", "Character Already Exists");

                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var characterMap = _mapper.Map<Character>(characterCreate);

            if (!_characterRepository.CreateCharacter( ownerId , categoryId ,characterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created !");

        }



    }
}
