using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Phrase;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class PhraseController : ControllerBase
    {
        private readonly IPhraseRepository _phraseRepository;

        public PhraseController(IPhraseRepository phraseRepository)
        {
            _phraseRepository = phraseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhraseDto>>> GetPhrases()
        {   
            var phrases = await _phraseRepository.GetAllAsync();
            return Ok(phrases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhraseDto>> GetPhraseById(int id)
        {
            var phrase = await _phraseRepository.GetByIdAsync(id);
            if (phrase == null)
            {
                return null;
            }
            return Ok(phrase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhrase(int id, Phrase phrase)
        {
            if (id != phrase.PhraseId)
            {
                return BadRequest("");
            }

            var updatedPhrase = await _phraseRepository.UpdateAsync(id, phrase);
            if (updatedPhrase == null)
            {
                return null;
            }
            return Ok(updatedPhrase);
        }

        [HttpPost]
        public async Task<ActionResult> PostPhrase(PhraseCreateDto phrase)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPhrase = phrase.ToPhraseFromCreateDTO();
            
            await _phraseRepository.CreateAsync(createdPhrase);

            return CreatedAtAction(nameof(GetPhraseById), new { id = createdPhrase.PhraseId}, createdPhrase);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletePhrase = await _phraseRepository.DeleteAsync(id);
            if (deletePhrase == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("bulk-add")]
        public async Task<ActionResult> PostPhraseWithWords([FromBody]PhraseCreateWithWordsDto phraseCreateWithWordsDto)
        {
            if (phraseCreateWithWordsDto == null || 
                string.IsNullOrWhiteSpace(phraseCreateWithWordsDto.PhraseText) || 
                phraseCreateWithWordsDto.Words == null || 
                phraseCreateWithWordsDto.Words.Count() == 0)
            {
                return BadRequest("Phrase and words are required.");
            }

            var phrase = new Phrase
            {
                PhraseText = phraseCreateWithWordsDto.PhraseText
            };

            var words = phraseCreateWithWordsDto.Words.Select(w => new Word {WordText=w}).ToList();

            var createdPhrase = await _phraseRepository.CreateWithWordsAsync(phrase, words);

            return CreatedAtAction(nameof(GetPhraseById), new { id = createdPhrase.PhraseId }, createdPhrase);
        }
    }
}