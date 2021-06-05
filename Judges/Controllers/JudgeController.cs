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
        private readonly IJudgeService _judgeService;

        public JudgeController(IJudgeService judgeService)
        {
            _judgeService = judgeService;
        }

        /// <summary>
        /// Получение судьи по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор судьи.</param>
        /// <returns>Модель судьи.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var judgeDto = await _judgeService.Get(id);

            return Ok(new { Success = true, Judge = judgeDto});
        }

        /// <summary>
        /// Добавление судьи.
        /// </summary>
        /// <param name="judgeDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного судьи.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(JudgeDto judgeDto)
        {
            return Ok(new { Success = true, JudgeId = await _judgeService.Create(judgeDto) });
        }

        /// <summary>
        /// Обновление судьи.
        /// </summary>
        /// <param name="judgeDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленной судьи.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(JudgeDto judgeDto)
        {
            return Ok(new { Success = true, JudgeId = await _judgeService.Update(judgeDto) });
        }

        /// <summary>
        /// Удаление судьи.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленной судьи.</returns>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _judgeService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}