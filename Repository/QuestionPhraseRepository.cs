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
    public class QuestionPhraseRepository : IQuestionPhraseRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionPhraseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<QuestionPhraseDto> GetQuestionPhraseAsync(string userId, int selectedLanguageId)
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionPhraseDto> GetSpecificPhraseAsync(string userId, int selectedLanguageId, int phraseId)
        {
            // Retrieve the user's native language
            var user = await _context.Users
                .Include(u => u.NativeLanguage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Retrieve the phrase
            var phrase = await _context.Phrases
                .Include(p => p.PhraseLanguages)
                .ThenInclude(pl => pl.Language)
                .FirstOrDefaultAsync(p => p.PhraseId == phraseId);

            if (phrase == null)
            {
                throw new ArgumentException("Phrase not found");
            }

            // Retrieve the native language text and the selected language text
            var nativeLanguageText = phrase.PhraseLanguages
                .FirstOrDefault(pl => pl.LanguageId == user.NativeLanguageId)?.PhraseInLanguage;

            var selectedLanguageText = phrase.PhraseLanguages
                .FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage;

            // Retrieve other phrases in the selected language
            var otherPhrases = await _context.Phrases
                .Include(p => p.PhraseLanguages)
                .ThenInclude(pl => pl.Language)
                .Where(p => p.PhraseLanguages.Any(pl => pl.LanguageId == selectedLanguageId) && p.PhraseId != phraseId)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ToListAsync();

            // Map to DTO
            var questionPhraseDto = new QuestionPhraseDto
            {
                PhraseId = phrase.PhraseId,
                NativeLanguageText = phrase.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == user.NativeLanguageId)?.PhraseInLanguage,
                SelectedLanguageText = phrase.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage,
                OtherPhrases = otherPhrases.Select(op => op.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage).ToList()
            };

            return questionPhraseDto;
        }
    }
}