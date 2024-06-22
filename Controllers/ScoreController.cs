using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduPlus.api.Controllers
{
    [Authorize]
    [Route("api/score")]
    [ApiController]
    public class ScoreController: ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateScore([FromBody] ScoreDto scoreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }
                await _scoreRepository.UpdateScoreAsync(userId, scoreDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ScoreDto>> GetScore()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                var scoreDto = await _scoreRepository.GetScoreAsync(userId);
                return Ok(scoreDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("statistics/{languageId}")]
        public async Task<ActionResult<StatisticsDto>> GetStatistics(int languageId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                var statisticsDto = await _scoreRepository.GetStatisticsAsync(userId, languageId);
                return Ok(statisticsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("leaderboard")]
        public async Task<ActionResult<LeaderboardDto>> GetLeaderboard()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                var leaderboardDto = await _scoreRepository.GetLeaderboardAsync(userId);
                return Ok(leaderboardDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("totalpoints/leaderboard")]
        public async Task<ActionResult<LeaderboardDto>> GetTotalPointsLeaderboard()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Unauthorized();
                }

                var leaderboardDto = await _scoreRepository.GetTotalPointsLeaderboardAsync(userId);
                return Ok(leaderboardDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}