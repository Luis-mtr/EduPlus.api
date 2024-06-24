using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Language;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{   
    [Route("api/wordlanguage")]
    [ApiController]

    public class WordLanguageController : ControllerBase
    {
        private readonly IWordLanguageRepository _wordLanguageRepository;

        public WordLanguageController(IWordLanguageRepository wordLanguageRepository)
        {
            _wordLanguageRepository = wordLanguageRepository;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<WordLanguage>>> GetAll()
        {
            var wordLanguages = await _wordLanguageRepository.GetAllAsync();
            return Ok(wordLanguages);
        }

        [HttpGet("{wordId}/{languageId}")]
        [AllowAnonymous]
         public async Task<ActionResult<string>> GetById(int wordId, int languageId)
        {
            var wordInLanguage = await _wordLanguageRepository.GetWordInLanguageAsync(wordId, languageId);
            if (wordInLanguage == null) 
            {
                return NotFound();
            }
            return Ok(wordInLanguage);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> Create (WordLanguageCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var wordLanguage = new WordLanguage{
                WordId = dto.WordId,
                LanguageId = dto.LanguageId,
                WordInLanguage = dto.WordLanguage
            };

            var createdWordLanguage = await _wordLanguageRepository.CreateAsync(wordLanguage);
            
            return CreatedAtAction(nameof(GetById), new { wordId = createdWordLanguage.WordId, languageId = createdWordLanguage.LanguageId }, createdWordLanguage);
        }

        [HttpPut("{wordId}/{languaeId}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> Update(int wordId, int languaeId, WordLanguageCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingWordLanguage = await _wordLanguageRepository.GetByIdAsync(wordId, languaeId);
            if (existingWordLanguage == null) 
                return NotFound();

            existingWordLanguage.WordInLanguage = dto.WordLanguage;

            var updatedWordLanguage = await _wordLanguageRepository.UpdateAsync(existingWordLanguage);

            return Ok(updatedWordLanguage);
        }

        [HttpDelete("{wordId}/{languaeId}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> Delete(int wordId, int languaeId)
        {
            var success = await _wordLanguageRepository.DeleteAsync(wordId, languaeId);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}