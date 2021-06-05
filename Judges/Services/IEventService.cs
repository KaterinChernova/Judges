using Judges.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public interface IEventService
    {
        Task<EventDto[]> GetEventsForJudge();
    }
}
