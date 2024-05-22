using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Models;
using api.Dtos.Language;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/phraselanguage")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class PhraseLanguageController : ControllerBase
    {
        private readonly IPhraseLanguageRepository _phraseLanguageRepository;

        public PhraseLanguageController(IPhraseLanguageRepository phraseLanguageRepository)
        {
            _phraseLanguageRepository = phraseLanguageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhraseLanguage>>> GetAll()
        {
            var phraseLanguages = await _phraseLanguageRepository.GetAllAsync();
            return Ok(phraseLanguages);
        }

        [HttpGet("{phraseId}/{languageId}")]
        public async Task<ActionResult<IEnumerable<PhraseLanguage>>> GetById(int phraseId, int languageId)
        {
            var phraseLanguage = await _phraseLanguageRepository.GetByIdAsync(phraseId, languageId);
            if (phraseLanguage == null) return NotFound();
            return Ok(phraseLanguage);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PhraseLanguageCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var phraseLanguage = new PhraseLanguage
            {
                PhraseId = dto.PhraseId,
                LanguageId = dto.LanguageId,
                PhraseInLanguage = dto.PhraseLanguage
            };

            var createdPhraseLanguage = await _phraseLanguageRepository.CreateAsync(phraseLanguage);

            return CreatedAtAction(nameof(GetById), new { phraseId = createdPhraseLanguage.PhraseId, languageId = createdPhraseLanguage.LanguageId }, createdPhraseLanguage);
        }

        [HttpPut("{phraseId}/{languageId}")]
        public async Task<ActionResult> Update(int phraseId, int languageId, PhraseLanguageCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPhraseLanguage = await _phraseLanguageRepository.GetByIdAsync(phraseId, languageId);
            if (existingPhraseLanguage == null) return NotFound();

            existingPhraseLanguage.PhraseInLanguage = dto.PhraseLanguage;

            var updatedPhraseLanguage = await _phraseLanguageRepository.UpdateAsync(existingPhraseLanguage);
            
            return Ok(updatedPhraseLanguage);
        }

        [HttpDelete("{phraseId}/{languageId}")]
        public async Task<ActionResult> Delete(int phraseId, int languageId)
        {
            var success = await _phraseLanguageRepository.DeleteAsync(phraseId, languageId);
            if(!success) return NotFound();

            return NoContent();
        }
    }
}