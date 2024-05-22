using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPhraseLanguageRepository
    {
        Task<IEnumerable<PhraseLanguage>> GetAllAsync();
        Task<PhraseLanguage> GetByIdAsync(int phraseId, int languageId);
        Task<PhraseLanguage> CreateAsync(PhraseLanguage phraseLanguage);
        Task<PhraseLanguage> UpdateAsync(PhraseLanguage phraseLanguage);
        Task<bool> DeleteAsync(int phraseId, int languageId);
    }
}