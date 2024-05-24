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
    public class PhraseAnswerRepository : IPhraseAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public PhraseAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PhraseAnswerDto> SubmitPhraseAnswer(string userId, int selectedLanguageId, int phraseId, bool isCorrect)
        {
            var phraseLanguageUser = await _context.PhraseLanguageUsers
                .FirstOrDefaultAsync(plu => plu.AppUserId == userId && plu.LanguageId == selectedLanguageId && plu.PhraseId == phraseId);

            if (phraseLanguageUser == null)
            {
                phraseLanguageUser = new PhraseLanguageUser
                {
                    AppUserId = userId,
                    LanguageId = selectedLanguageId,
                    PhraseId = phraseId,
                    CountAsked = 1,
                    CountRight = isCorrect ? 1 : 0,
                    Score = isCorrect ? (byte)75 : (byte)25,
                    Date = isCorrect ? DateTime.UtcNow.AddHours(20) : DateTime.UtcNow.AddMinutes(5)
                };

                _context.PhraseLanguageUsers.Add(phraseLanguageUser);
            }
            else
            {
                phraseLanguageUser.CountAsked++;
                if (isCorrect)
                {
                    phraseLanguageUser.CountRight++;
                }
                phraseLanguageUser.Score = isCorrect ? (byte)((float)phraseLanguageUser.Score/2 + 50) : (byte)((float)phraseLanguageUser.Score/2);
                phraseLanguageUser.Date = isCorrect ? DateTime.UtcNow.AddHours(20) : DateTime.UtcNow.AddMinutes(5);
            }

            var answer = new PhraseAnswerDto{
                UserId = userId,
                PhraseId = phraseId,
                SelectedLanguageId = selectedLanguageId,
                IsCorrect = isCorrect
            };

            await _context.SaveChangesAsync();
            return (answer);
        }
    }
}