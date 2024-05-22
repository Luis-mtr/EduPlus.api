using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PhraseLanguageRepository : IPhraseLanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public PhraseLanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PhraseLanguage> CreateAsync(PhraseLanguage phraseLanguage)
        {
            _context.PhraseLanguages.Add(phraseLanguage);
            await _context.SaveChangesAsync();
            return phraseLanguage;
        }

        public async Task<bool> DeleteAsync(int phraseId, int languageId)
        {
            var phraseLanguage = await GetByIdAsync(phraseId, languageId);
            if (phraseLanguage == null)
            {
                return false;
            }

            _context.PhraseLanguages.Remove(phraseLanguage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhraseLanguage>> GetAllAsync()
        {
            return await _context.PhraseLanguages.ToListAsync();
        }

        public async Task<PhraseLanguage> GetByIdAsync(int phraseId, int languageId)
        {
            var phraseLanguage = await _context.PhraseLanguages.FirstOrDefaultAsync(pl => pl.PhraseId == phraseId && pl.LanguageId==languageId);
            if (phraseLanguage == null) return null;
            return phraseLanguage;
        }

        public async Task<PhraseLanguage> UpdateAsync(PhraseLanguage phraseLanguage)
        {
            _context.PhraseLanguages.Update(phraseLanguage);
            await _context.SaveChangesAsync();
            return phraseLanguage;
        }
    }
}