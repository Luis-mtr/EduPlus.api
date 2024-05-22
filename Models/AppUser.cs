using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {   
    public int NativeLanguageId { get; set; }
    public Language NativeLanguage { get; set; } 
    public ICollection<PhraseLanguageUser> PhraseLanguageUser { get; set; } = new List<PhraseLanguageUser>();
    public ICollection<WordLanguageUser> WordLanguageUser { get; set; } = new List<WordLanguageUser>();
    }
}