using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Phrase;

namespace api.Interfaces
{
    public interface IPhraseRepository
    {
        Task<List<PhraseDto>> GetAllAsync();
        Task<PhraseDto?> GetByIdAsync(int id);
        Task<Phrase> CreateAsync(Phrase phrase);
        Task<Phrase?> UpdateAsync(int id, Phrase phrase);
        Task<Phrase?> DeleteAsync(int id);
        Task<bool> PhraseExits(int id);
        Task<Phrase> CreateWithWordsAsync (Phrase phrase, List<Word> words);
    }
}