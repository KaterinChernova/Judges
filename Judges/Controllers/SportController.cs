using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judges.Data.Models;
using Judges.Services;
using Microsoft.AspNetCore.Mvc;

namespace Judges.Controllers
{
    [Route("Sport")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            _sportService = sportService;
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
            var SportDto = await _sportService.Get(id);
            return Ok(new { Success = true, Sport = SportDto });
        }

        /// <summary>
        /// Добавление судьи.
        /// </summary>
        /// <param name="SportDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного судьи.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(SportDto SportDto)
        {
            return Ok(new { Success = true, SportId = await _sportService.Create(SportDto) });
        }

        /// <summary>
        /// Обновление судьи.
        /// </summary>
        /// <param name="SportDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленной судьи.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(SportDto SportDto)
        {
            return Ok(new { Success = true, SportId = await _sportService.Update(SportDto) });
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
            await _sportService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}