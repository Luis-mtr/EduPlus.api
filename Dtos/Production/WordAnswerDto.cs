using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class WordAnswerDto
    {
        public string UserId { get; set; }
        public int SelectedLanguageId { get; set; }
        public int WordId { get; set; }
        public bool IsCorrect { get; set; }
    }
}