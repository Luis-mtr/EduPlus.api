using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class LeaderboardDto
        {
            public List<LeaderboardEntryDto> Entries { get; set; } = new List<LeaderboardEntryDto>();
        }

        public class LeaderboardEntryDto
        {
            public string UserName { get; set; }
            public long SessionPoints { get; set; }
            public int CurrentUserPosition { get; set; }
        }
}