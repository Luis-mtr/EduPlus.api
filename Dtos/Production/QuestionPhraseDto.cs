using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class QuestionPhraseDto
    {
        public int PhraseId { get; set; }
        public string NativeLanguageText { get; set; }
        public string SelectedLanguageText { get; set; }
        public List<string> OtherPhrases { get; set; }
    }
}