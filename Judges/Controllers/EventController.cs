using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judges.Data.Models;
using Judges.Mongo;
using Judges.Mongo.Model;
using Judges.Services;
using Microsoft.AspNetCore.Mvc;

namespace Judges.Controllers
{
    [Route("Events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventsService _eventService;

        public EventController(EventsService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Получение судьи по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор судьи.</param>
        /// <returns>Модель судьи.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(string id)
        {
            var judgeDto = await _eventService.Get(id);
            return Ok(new { Success = true, Event = judgeDto });
        }

        /// <summary>
        /// Добавление судьи.
        /// </summary>
        /// <param name="judgeDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного судьи.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(Event judgeDto)
        {
            return Ok(new { Success = true, EventId = await _eventService.Create(judgeDto) });
        }

        /// <summary>
        /// Обновление судьи.
        /// </summary>
        /// <param name="judgeDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленной судьи.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(Event judgeDto)
        {
            await _eventService.Update(judgeDto);

            return Ok(new { Success = true });
        }

        /// <summary>
        /// Удаление судьи.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленной судьи.</returns>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}