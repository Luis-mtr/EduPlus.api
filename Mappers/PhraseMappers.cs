using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Phrase;

namespace api.Mappers
{
    public static class PhraseMappers
    {
        public static Phrase ToPhraseFromCreateDTO(this PhraseCreateDto phraseCreateDto)
        {
            return new Phrase
            {
                PhraseText = phraseCreateDto.PhraseText,
            };
        }
    }
}