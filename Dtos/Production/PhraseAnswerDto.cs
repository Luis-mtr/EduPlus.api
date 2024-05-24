using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class PhraseAnswerDto
    {
        public string UserId { get; set; }
        public int SelectedLanguageId { get; set; }
        public int PhraseId { get; set; }
        public bool IsCorrect { get; set; }
    }
}