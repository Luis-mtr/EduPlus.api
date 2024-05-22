using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Language;
using api.Models;

namespace api.Mappers
{
    public static class LanguageMappers
    {
        public static Language ToLanguageFromCreateDTO(this LanguageCreateDto languageCreateDto)
        {
            return new Language
            {
                LanguageName = languageCreateDto.LanguageName,
            };
        }
    }
}