using System;
using System.Collections.Generic;
using System.Linq;
using api.Dtos.Language;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;


namespace api.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Language> CreateAsync(Language language)
        {
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public async Task<Language?> DeleteAsync(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return null;
            }
            
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return language;
        }

        public async Task<List<LanguageDto>> GetAllAsync()
        {
            return await _context.Languages
            .Select(l => new LanguageDto 
            {
                LanguageId = l.LanguageId,
                LanguageName = l.LanguageName
            })
            .ToListAsync();
        }

        public async Task<LanguageDto?> GetByIdAsync(int id)
        {
            return await _context.Languages
            .Where(l => l.LanguageId == id)
            .Select(l => new LanguageDto 
            {
                LanguageId = l.LanguageId,
                LanguageName = l.LanguageName
            })
            .FirstOrDefaultAsync();
        }

        public async Task<bool> LanguageExists(int id)
        {
            return await _context.Languages.AnyAsync(e => e.LanguageId == id);
        }

        public async Task<Language?> UpdateAsync(int id, Language language)
        {
            var existingLanguage = await _context.Languages.FindAsync(id);
            if (existingLanguage == null)
            {
                return null;
            }

            existingLanguage.LanguageName = language.LanguageName;

            await _context.SaveChangesAsync();
            return existingLanguage;
        }
    }
}