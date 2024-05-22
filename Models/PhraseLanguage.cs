using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PhraseLanguage
    {
        public int PhraseId { get; set; }
        public int LanguageId { get; set; }
        [Required]
        public string PhraseInLanguage { get; set; }
        public Phrase Phrase { get; set; }
        public Language Language { get; set; }
    }
}