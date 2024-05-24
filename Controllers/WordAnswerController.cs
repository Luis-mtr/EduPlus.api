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
    [Route("api/wordLanguageUser")]
    [ApiController]
    public class WordAnswerController : ControllerBase
    {
        private readonly IWordAnswerRepository _answerRepository;

        public WordAnswerController( IWordAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpPost("update")]
        public async Task<IActionResult> SubmitWordAnswer(int selectedLanguageId, int wordId, bool isCorrect)
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
                await _answerRepository.SubmitWordAnswer(userId, selectedLanguageId, wordId, isCorrect);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}