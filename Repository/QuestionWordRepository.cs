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
    public class QuestionWordRepository : IQuestionWordRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionWordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<QuestionPhraseDto> GetQuestionWordAsync(string userId, int selectedLanguageId)
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionPhraseDto> GetSpecificWordAsync(string userId, int selectedLanguageId, int wordId)
        {
            // Retrieve the user's native language
            var user = await _context.Users
                .Include(u => u.NativeLanguage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var word = await _context.Words
                .Include(p => p.WordLanguages)
                .ThenInclude(pl => pl.Language)
                .FirstOrDefaultAsync(p => p.WordId == wordId);

            if (word == null)
            {
                throw new ArgumentException("Word not found");
            }

            // Retrieve other words in the selected language
            var otherWords = await _context.Words
                .Include(w => w.WordLanguages)
                .ThenInclude(wl => wl.Language)
                .Where(w => w.WordLanguages.Any(wl => wl.LanguageId == selectedLanguageId) && w.WordId != wordId)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ToListAsync();

            // Map to DTO
            var questionWordDto = new QuestionPhraseDto
            {
                PhraseId = word.WordId,
                NativeLanguageText = word.WordLanguages.FirstOrDefault(wl => wl.LanguageId == user.NativeLanguageId)?.WordInLanguage,
                SelectedLanguageText = word.WordLanguages.FirstOrDefault(wl => wl.LanguageId == selectedLanguageId)?.WordInLanguage,
                OtherPhrases = otherWords.Select(ow => ow.WordLanguages.FirstOrDefault(wl => wl.LanguageId == selectedLanguageId)?.WordInLanguage).ToList()
            };

            return questionWordDto;
        }
    }
}