using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Word;
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
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordDto>>> GetWords()
        {   
            var words = await _wordRepository.GetAllAsync();
            return Ok(words);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WordDto>> GetWordById(int id)
        {
            var word = await _wordRepository.GetByIdAsync(id);
            if (word == null)
            {
                return null;
            }
            return Ok(word);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWord(int id, Word word)
        {
            if (id != word.WordId)
            {
                return BadRequest("");
            }

            var updatedWord = await _wordRepository.UpdateAsync(id, word);
            if (updatedWord == null)
            {
                return null;
            }
            return Ok(updatedWord);
        }

        [HttpPost]
        public async Task<ActionResult> PostWord(WordCreateDto word)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdWord = word.ToWordFromCreateDTO();
            
            await _wordRepository.CreateAsync(createdWord);

            return CreatedAtAction(nameof(GetWordById), new { id = createdWord.WordId}, createdWord);
        }

        [HttpPost("bulk-add")]
        public async Task<ActionResult> PostWords([FromBody] List<string> wordTexts)
        {
            if (wordTexts == null || wordTexts.Count == 0)
                return BadRequest("No words provided!");

            var wordsToAdd = new List<Word>();

            foreach (var wordText in wordTexts)
            {
                if (!await _wordRepository.WordExistsByText(wordText))
                {
                    wordsToAdd.Add(new Word { WordText = wordText });
                }
            }

            if (wordsToAdd.Any())
            {
                await _wordRepository.AddWordsAsync(wordsToAdd);
            }

            return Ok(wordsToAdd.Count() + " New words added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleteWord = await _wordRepository.DeleteAsync(id);
            if (deleteWord == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}