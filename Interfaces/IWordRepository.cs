using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Word;
using api.Models;

namespace api.Interfaces
{
    public interface IWordRepository
    {
        Task<List<WordDto>> GetAllAsync();
        Task<WordDto?> GetByIdAsync(int id);
        Task<Word> CreateAsync(Word Word);
        Task<Word?> UpdateAsync(int id, Word Word);
        Task<Word?> DeleteAsync(int id);
        Task<bool> WordExitsById(int id);
        Task<bool> WordExistsByText(string Text);
        Task AddWordsAsync(IEnumerable<Word> words);
    }
}