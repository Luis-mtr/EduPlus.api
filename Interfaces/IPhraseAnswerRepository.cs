using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;

namespace EduPlus.api.Interfaces
{
    public interface IPhraseAnswerRepository
    {
        Task<PhraseAnswerDto> SubmitPhraseAnswer(string userId, int selectedLanguageId, int phraseId, bool isCorrect);
    }
}