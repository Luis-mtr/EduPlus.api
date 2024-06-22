using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlus.api.Dtos.Production
{
    public class StatisticsDto
    {
        public int TotalCountAsked { get; set; }
        public int TotalCountRight { get; set; }
        public double AverageScore { get; set; }
    }
}