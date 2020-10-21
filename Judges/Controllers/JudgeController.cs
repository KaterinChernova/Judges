using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judges.Data.Models;
using Judges.Services;
using Microsoft.AspNetCore.Mvc;

namespace Judges.Controllers
{
    [Route("Judge")]
    [ApiController]
    public class JudgeController : ControllerBase
    {
        private readonly IJudgeService judgeService;

        public JudgeController(IJudgeService judgeService)
        {
            this.judgeService = judgeService;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { Success = true });
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(Judge judge)
        {
            return Ok(new { Success = true });
        }
    }
}