using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.Interfaces;
using api.Dtos.Language;
using api.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguagesController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguages()
        {
            var languages = await _languageRepository.GetAllAsync();
            return Ok(languages);
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDto>> GetLanguage(int id)
        {
            var language = await _languageRepository.GetByIdAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, Language language)
        {
            if (id != language.LanguageId)
            {
                return BadRequest("Language not found.");
            }

            var updatedLanguage = await _languageRepository.UpdateAsync(id, language);
            if (updatedLanguage == null)
            {
                return NotFound();
            }

            return Ok(updatedLanguage);
        }

        // POST: api/Languages
        [HttpPost]
        public async Task<ActionResult> PostLanguage(LanguageCreateDto language)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdLanguage = language.ToLanguageFromCreateDTO();

            await _languageRepository.CreateAsync(createdLanguage);

            return CreatedAtAction(nameof(GetLanguage), new { id = createdLanguage.LanguageId }, createdLanguage);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var deleteLanguage = await _languageRepository.DeleteAsync(id);

            if (deleteLanguage == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}