using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class WordLanguageUser
    {
        public int WordId { get; set; }
        public int LanguageId { get; set; }
        public string AppUserId { get; set; }
        public Word Word { get; set; }
        public Language Language { get; set; }
        public AppUser AppUser { get; set; }
        public byte Score { get; set; }
        public DateTime Date { get; set; }
        public int CountAsked { get; set; }
        public int CountRight { get; set; }
    }
}