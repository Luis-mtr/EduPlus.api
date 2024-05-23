using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduPlus.api.Controllers
{
    [Authorize]
    [Route("api/questionphrase")]
    [ApiController]
    public class QuestionWordController
    {
        private readonly IQuestionWordRepository _questionWordRepository;

        public QuestionWordController(IQuestionWordRepository questionWordRepository)
        {
            _questionWordRepository = questionWordRepository;
        }
    }
}