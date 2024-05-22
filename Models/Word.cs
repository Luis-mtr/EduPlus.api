using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string WordText { get; set; }
        public List<WordLanguageUser> WordLanguageUser { get; set; } = new List<WordLanguageUser>();
        public ICollection<WordPhrase> WordPhrases { get; set; } = new List<WordPhrase>();
        public List<WordLanguage> WordLanguages { get; set; } = new List<WordLanguage>();
    }
}