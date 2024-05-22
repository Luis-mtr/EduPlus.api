using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Language
    {
            public int LanguageId { get; set; }
            [Required]
            public string LanguageName { get; set; }
            public List<PhraseLanguageUser> PhraseLanguageUser { get; set; } = new List<PhraseLanguageUser>();
            public List<WordLanguageUser> WordLanguageUser { get; set; } = new List<WordLanguageUser>();
            public List<WordLanguage> WordLanguages { get; set; } = new List<WordLanguage>();
            public List<PhraseLanguage> PhraseLanguages { get; set; } = new List<PhraseLanguage>();
    }
}