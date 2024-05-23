using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class QuestionWordDto
    {
        public int WordId { get; set; }
        public string NativeLanguageText { get; set; }
        public string SelectedLanguageText { get; set; }
        public List<string> OtherWords { get; set; }
    }
}