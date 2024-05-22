using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Word;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly ApplicationDbContext _context;

        public WordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddWordsAsync(IEnumerable<Word> words)
        {
            _context.Words.AddRange(words);
            await _context.SaveChangesAsync();
        }

        public async Task<Word> CreateAsync(Word Word)
        {
            await _context.Words.AddAsync(Word);
            await _context.SaveChangesAsync();
            return Word;
        }

        public async Task<Word?> DeleteAsync(int id)
        {
            var word = await _context.Words.FirstOrDefaultAsync(x => x.WordId == id);
            if (word == null)
            {
                return null;
            }
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
            return word;
        }

        public async Task<List<WordDto>> GetAllAsync()
        {
            return await _context.Words
                .Select( w => new WordDto
                {
                    WordId = w.WordId,
                    WordText = w.WordText
                })
                .ToListAsync();                
        }

        public async Task<WordDto?> GetByIdAsync(int id)
        {
            return await _context.Words
                .Where(x => x.WordId == id)
                .Select(w => new WordDto{
                    WordId = w.WordId,
                    WordText = w.WordText
                }).FirstOrDefaultAsync();
        }

        public async Task<Word?> UpdateAsync(int id, Word Word)
        {
            var existingWord = await _context.Words.FindAsync(id);
            if (existingWord == null)
            {
                return null;
            }
            existingWord.WordText = Word.WordText;
            await _context.SaveChangesAsync();
            return existingWord;
        }

        public async Task<bool> WordExitsById(int id)
        {
            return await _context.Words.AnyAsync(w => w.WordId == id);
        }

        public async Task<bool> WordExistsByText(string wordText)
        {
            return await _context.Words.AnyAsync(w => w.WordText == wordText);
        }
    }
}