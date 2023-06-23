using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interfaces;
using ReviewApp.Models;

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


    }
}
