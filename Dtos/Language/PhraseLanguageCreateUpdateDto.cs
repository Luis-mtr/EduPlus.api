using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Language
{
    public class PhraseLanguageCreateUpdateDto
    {
        public int PhraseId {get; set;}
        public int LanguageId {get; set;}
        public string PhraseLanguage {get; set;} 
    }
}