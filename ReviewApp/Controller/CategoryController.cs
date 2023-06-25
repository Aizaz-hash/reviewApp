using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.DTO;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using ReviewApp.Repository;

namespace ReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoriesExists(categoryId))
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        [HttpGet("character/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        [ProducesResponseType(400)]
        public IActionResult GetCharacterByCategoryId(int categoryId)
        {
            var characters = _mapper.Map<List<CharacterDTO>>(
                _categoryRepository.GetCharacterByCategoryId(categoryId));

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            return Ok(characters);
        }





    }
}
