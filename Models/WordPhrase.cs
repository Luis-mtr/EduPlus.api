using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class WordPhrase
    {
        public int WordId { get; set; }
        public Word Word{ get; set; }
        public int PhraseId { get; set; }
        public Phrase Phrase{ get; set; }
    }
}