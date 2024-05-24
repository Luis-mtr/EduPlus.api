using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using EduPlus.api.Interfaces;
using EduPlus.api.Dtos.Production;
using System.Security.Claims;

namespace EduPlus.api.Controllers
{        
    [Authorize]
    [Route("api/phraseLanguageUser")]
    [ApiController]
    public class PhraseAnswerController : ControllerBase
    {
        private readonly IPhraseAnswerRepository _answerRepository;

        public PhraseAnswerController( IPhraseAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpPost("update")]
        public async Task<IActionResult> SubmitPhraseAnswer(int selectedLanguageId, int phraseId, bool isCorrect)
        {   
            var userId = "";
            try
            {                    // Retrieve user id from JWT claims
               userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (userId == null)
                {
                    return Unauthorized("User ID not found in token.");
                }
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _answerRepository.SubmitPhraseAnswer(userId, selectedLanguageId, phraseId, isCorrect);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }        
    }
}