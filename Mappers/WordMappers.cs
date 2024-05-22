using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Word;
using api.Models;


namespace api.Mappers
{
    public static class WordMappers
    {
        public static Word ToWordFromCreateDTO(this WordCreateDto wordCreateDto)
        {
            return new Word
            {
                WordText = wordCreateDto.WordText,
            };
        }
    }
}