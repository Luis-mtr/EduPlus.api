using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduPlus.api.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ApplicationDbContext _context;
        public ScoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScoreDto> GetScoreAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            return new ScoreDto
            {
                SessionPoints = user.SessionPoints,
                AddPoints = user.TotalPoints
            };
        }

        public async Task UpdateScoreAsync(string userId, ScoreDto scoreDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (scoreDto.SessionPoints > user.SessionPoints)
            {
                user.SessionPoints = scoreDto.SessionPoints;
            }

            user.TotalPoints += scoreDto.AddPoints;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<StatisticsDto> GetStatisticsAsync(string userId, int languageId)
        {
            var totalCountAsked = await _context.WordLanguageUsers
                .Where(wlu => wlu.AppUserId == userId && wlu.LanguageId == languageId)
                .SumAsync(wlu => wlu.CountAsked);

            totalCountAsked += await _context.PhraseLanguageUsers
                .Where(plu => plu.AppUserId == userId && plu.LanguageId == languageId)
                .SumAsync(plu => plu.CountAsked);

            var totalCountRight = await _context.WordLanguageUsers
                .Where(wlu => wlu.AppUserId == userId && wlu.LanguageId == languageId)
                .SumAsync(wlu => wlu.CountRight);

            totalCountRight += await _context.PhraseLanguageUsers
                .Where(plu => plu.AppUserId == userId && plu.LanguageId == languageId)
                .SumAsync(plu => plu.CountRight);

            var wordLanguageUsers = await _context.WordLanguageUsers
                .Where(wlu => wlu.AppUserId == userId && wlu.LanguageId == languageId)
                .ToListAsync();

            var phraseLanguageUsers = await _context.PhraseLanguageUsers
                .Where(plu => plu.AppUserId == userId && plu.LanguageId == languageId)
                .ToListAsync();

            var allScores = wordLanguageUsers.Select(wlu => (int)wlu.Score)
                .Concat(phraseLanguageUsers.Select(plu => (int)plu.Score))
                .ToList();

            var averageScore = allScores.Any() ? allScores.Average() : 0;

            return new StatisticsDto
            {
                TotalCountAsked = totalCountAsked,
                TotalCountRight = totalCountRight,
                AverageScore = averageScore
            };

            
        }

        public async Task<LeaderboardDto> GetLeaderboardAsync(string userId)
        {
            var users = await _context.Users
                .OrderByDescending(u => u.SessionPoints)
                .ToListAsync();

            var currentUserIndex = users.FindIndex(u => u.Id == userId);

            var start = Math.Max(0, currentUserIndex - 4);
            var end = Math.Min(users.Count - 1, currentUserIndex + 4);

            var leaderboardEntries = users.Skip(start).Take(end - start + 1)
                .Select((u, index) => new LeaderboardEntryDto
                {
                    UserName = u.UserName,
                    SessionPoints = u.SessionPoints,
                    CurrentUserPosition = start + index + 1 // 1-based index
                }).ToList();

            return new LeaderboardDto 
            { 
                Entries = leaderboardEntries 
            };
        }

        public async Task<LeaderboardDto> GetTotalPointsLeaderboardAsync(string userId)
        {
            var users = await _context.Users
                .OrderByDescending(u => u.TotalPoints)
                .ToListAsync();

            var currentUserIndex = users.FindIndex(u => u.Id == userId);

            var start = Math.Max(0, currentUserIndex - 4);
            var end = Math.Min(users.Count - 1, currentUserIndex + 4);

            var leaderboardEntries = users.Skip(start).Take(end - start + 1)
                .Select((u, index) => new LeaderboardEntryDto
                {
                    UserName = u.UserName,
                    SessionPoints = u.TotalPoints,
                    CurrentUserPosition = start + index + 1 // 1-based index
                }).ToList();

            return new LeaderboardDto 
            { 
                Entries = leaderboardEntries 
            };
        }
    }
}