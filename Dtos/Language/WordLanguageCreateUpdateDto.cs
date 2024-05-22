using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Language
{
    public class WordLanguageCreateUpdateDto
    {
        public int WordId { get; set; }
        public int LanguageId { get; set; }
        public string WordLanguage { get; set; }
    }
}