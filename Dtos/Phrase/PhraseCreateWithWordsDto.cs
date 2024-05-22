using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Phrase
{
    public class PhraseCreateWithWordsDto
    {
        public string PhraseText { get; set; }
        public List<string> Words { get; set; }
    }
}