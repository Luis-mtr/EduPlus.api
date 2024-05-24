using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduPlus.api.Repository
{
    public class WordAnswerRepository : IWordAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public WordAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WordAnswerDto> SubmitWordAnswer(string userId, int selectedLanguageId, int wordId, bool isCorrect)
        {
            var wordLanguageUser = await _context.WordLanguageUsers
                .FirstOrDefaultAsync(wlu => wlu.AppUserId == userId && wlu.LanguageId == selectedLanguageId && wlu.WordId == wordId);

            if (wordLanguageUser == null)
            {
                wordLanguageUser = new WordLanguageUser
                {
                    AppUserId = userId,
                    LanguageId = selectedLanguageId,
                    WordId = wordId,
                    CountAsked = 1,
                    CountRight = isCorrect ? 1 : 0,
                    Score = isCorrect ? (byte)75 : (byte)25,
                    Date = isCorrect ? DateTime.UtcNow.AddHours(20) : DateTime.UtcNow.AddMinutes(5)
                };

                _context.WordLanguageUsers.Add(wordLanguageUser);
            }
            else
            {
                wordLanguageUser.CountAsked++;
                if (isCorrect)
                {
                    wordLanguageUser.CountRight++;
                }
                wordLanguageUser.Score = isCorrect ? (byte)((float)wordLanguageUser.Score/2 + 50) : (byte)((float)wordLanguageUser.Score/2);
                wordLanguageUser.Date = isCorrect ? DateTime.UtcNow.AddHours(20) : DateTime.UtcNow.AddMinutes(5);
            }

            var answer = new WordAnswerDto{
                UserId = userId,
                WordId = wordId,
                SelectedLanguageId = selectedLanguageId,
                IsCorrect = isCorrect
            };

            await _context.SaveChangesAsync();
            return (answer);
        }
    }
}