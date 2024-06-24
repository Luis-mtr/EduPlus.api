using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace api.Repository
{
    public class WordLanguageRepository : IWordLanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public WordLanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WordLanguage> CreateAsync(WordLanguage wordLanguage)
        {
            _context.WordLanguages.Add(wordLanguage);
            await _context.SaveChangesAsync();
            return wordLanguage;
        }

        public async Task<bool> DeleteAsync(int wordId, int languageId)
        {
            var wordLanguage = await GetByIdAsync(wordId, languageId);
            if (wordLanguage == null)
            {
                return false;
            }

            _context.WordLanguages.Remove(wordLanguage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WordLanguage>> GetAllAsync()
        {
            return await _context.WordLanguages.ToListAsync();
        }

        public async Task<WordLanguage> GetByIdAsync(int wordId, int languageId)
        {
            var wordLanguage = await _context.WordLanguages.FirstOrDefaultAsync(wl => wl.WordId == wordId && wl.LanguageId == languageId);
            if (wordLanguage == null) return null;
            return wordLanguage;
        }

        public async Task<WordLanguage> UpdateAsync(WordLanguage wordLanguage)
        {
            _context.WordLanguages.Update(wordLanguage);
            await _context.SaveChangesAsync();
            return wordLanguage;
        }

        public async Task<string> GetWordInLanguageAsync(int wordId, int languageId)
        {
            var wordLanguage = await _context.WordLanguages
                .FirstOrDefaultAsync(wl => wl.WordId == wordId && wl.LanguageId == languageId);
            return wordLanguage?.WordInLanguage;
        }
    }
}