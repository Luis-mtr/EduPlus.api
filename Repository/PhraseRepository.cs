using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Phrase;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PhraseRepository : IPhraseRepository
    {
        private readonly ApplicationDbContext _context;

        public PhraseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Phrase> CreateAsync(Phrase phrase)
        {
            await _context.Phrases.AddAsync(phrase);
            await _context.SaveChangesAsync();
            return phrase;
        }

        public async Task<Phrase> CreateWithWordsAsync(Phrase phrase, List<Word> words)
        {
            foreach (var word in words)
            {
                if (!_context.Words.Any(w => w.WordText.ToLower() == word.WordText.ToLower()))
                {
                    _context.Words.Add(word);
                }
            }
            await _context.SaveChangesAsync();

            _context.Phrases.Add(phrase);
            await _context.SaveChangesAsync();

            foreach (var word in words)
            {
                var wordEntity = _context.Words.First(w => w.WordText.ToLower() == word.WordText.ToLower());
                _context.WordsPhrases.Add(new WordPhrase {WordId = wordEntity.WordId, PhraseId = phrase.PhraseId});
            }
            await _context.SaveChangesAsync();

            return phrase;
        }

        public async Task<Phrase?> DeleteAsync(int id)
        {
            var phrase = await _context.Phrases.FirstOrDefaultAsync(x => x.PhraseId == id);
            if (phrase == null)
            {
                return null;
            }
            _context.Phrases.Remove(phrase);
            await _context.SaveChangesAsync();
            return phrase;
        }

        public async Task<List<PhraseDto>> GetAllAsync()
        {
            return await _context.Phrases
                .Select( w => new PhraseDto
                {
                    PhraseId = w.PhraseId,
                    PhraseText = w.PhraseText
                })
                .ToListAsync(); 
        }

        public async Task<PhraseDto?> GetByIdAsync(int id)
        {
            return await _context.Phrases
                .Where(x => x.PhraseId == id)
                .Select(w => new PhraseDto{
                    PhraseId = w.PhraseId,
                    PhraseText = w.PhraseText
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> PhraseExits(int id)
        {
            return await _context.Phrases.AnyAsync(w => w.PhraseId == id);
        }

        public async Task<Phrase?> UpdateAsync(int id, Phrase phrase)
        {
            var existingPhrase = await _context.Phrases.FindAsync(id);
            if (existingPhrase == null)
            {
                return null;
            }
            existingPhrase.PhraseText = phrase.PhraseText;
            await _context.SaveChangesAsync();
            return existingPhrase;
        }
    }
}