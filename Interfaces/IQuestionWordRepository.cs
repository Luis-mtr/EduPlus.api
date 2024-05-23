using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;

namespace EduPlus.api.Interfaces
{
    public interface IQuestionWordRepository
    {
        Task<QuestionPhraseDto> GetQuestionWordAsync(string userId, int selectedLanguageId);
        Task<QuestionPhraseDto> GetSpecificWordAsync(string userId, int selectedLanguageId, int wordId);
    }
}