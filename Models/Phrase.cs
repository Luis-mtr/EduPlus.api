using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Phrase
    {
        public int PhraseId { get; set; }
        [Required]
        public string PhraseText { get; set; }
        public List<PhraseLanguageUser> PhraseLanguageUser { get; set; } = new List<PhraseLanguageUser>();
        public ICollection<WordPhrase> WordPhrases { get; set; } = new List<WordPhrase>();
        public List<PhraseLanguage> PhraseLanguages { get; set; } = new List<PhraseLanguage>();
    }
}