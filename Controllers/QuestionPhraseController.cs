using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduPlus.api.Controllers
{

    [Authorize]
    [Route("api/questionphrase")]
    [ApiController]
    public class QuestionPhraseController : ControllerBase
    {
        private readonly IQuestionPhraseRepository _questionPhraseRepository;

        public QuestionPhraseController(IQuestionPhraseRepository questionPhraseRepository)
        {
            _questionPhraseRepository = questionPhraseRepository;
        }

        [HttpGet("{selectedLanguageId}/{phraseId}")]
        public async Task<ActionResult<QuestionPhraseDto>> GetQuestionPhrase(int selectedLanguageId, int phraseId)
        {
            try
            {                    // Retrieve user id from JWT claims
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (userId == null)
                {
                    return Unauthorized("User ID not found in token.");
                }

                var questionPhraseDto = await _questionPhraseRepository.GetSpecificPhraseAsync(userId, selectedLanguageId, phraseId);
                return Ok(questionPhraseDto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }    
}    
