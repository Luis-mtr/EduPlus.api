using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;

namespace EduPlus.api.Interfaces
{
    public interface IQuestionPhraseRepository
    {
        Task<QuestionPhraseDto> GetQuestionPhraseAsync(string userId, int selectedLanguageId);
        Task<QuestionPhraseDto> GetSpecificPhraseAsync(string userId, int selectedLanguageId,int phraseId);
    }
}