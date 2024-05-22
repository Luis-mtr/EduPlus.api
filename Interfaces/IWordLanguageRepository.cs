using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IWordLanguageRepository
    {
        Task<IEnumerable<WordLanguage>> GetAllAsync();
        Task<WordLanguage> GetByIdAsync(int wordId, int languageId);
        Task<WordLanguage> CreateAsync(WordLanguage wordLanguage);
        Task<WordLanguage> UpdateAsync(WordLanguage wordLanguage);
        Task<bool> DeleteAsync(int wordId, int languageId);
    }
}