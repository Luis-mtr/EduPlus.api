using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class WordLanguage
    {
        public int WordId { get; set; }
        public int LanguageId { get; set; }
        public string WordInLanguage { get; set; }
        public Word Word { get; set; }
        public Language Language { get; set; }
    }
}