using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Account
{
    public class UpdateAccountDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int LanguageId { get; set; }
        public string Role { get; set; }
    }
}