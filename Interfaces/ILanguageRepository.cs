using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Language;

namespace api.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<LanguageDto>> GetAllAsync();
        Task<LanguageDto?> GetByIdAsync(int id);
        Task<Language> CreateAsync(Language language);
        Task<Language?> UpdateAsync(int id, Language language);
        Task<Language?> DeleteAsync(int id);
        Task<bool> LanguageExists(int id);
    }
}