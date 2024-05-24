using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;

namespace EduPlus.api.Interfaces
{
    public interface IWordAnswerRepository
    {
        Task<WordAnswerDto> SubmitWordAnswer(string userId, int selectedLanguageId, int wordId, bool isCorrect);
    }
}