using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;

namespace EduPlus.api.Interfaces
{
    public interface IScoreRepository
    {
        Task UpdateScoreAsync(string userId, ScoreDto scoreDto);
        Task<ScoreDto> GetScoreAsync(string userId);
        Task<StatisticsDto> GetStatisticsAsync(string userId, int languageId);
        Task<LeaderboardDto> GetLeaderboardAsync(string userId);
        Task<LeaderboardDto> GetTotalPointsLeaderboardAsync(string userId);
    }
}