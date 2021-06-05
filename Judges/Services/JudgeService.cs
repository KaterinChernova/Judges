using Judges.Data;
using Judges.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Judges.Services
{
    public class JudgeService : IJudgeService
    {
        private readonly JudgesDbContext _judgesDbContext;
        private readonly IEventService _eventService;

        public JudgeService(JudgesDbContext judgesDbContext, IEventService eventService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _judgesDbContext = judgesDbContext ?? throw new ArgumentNullException(nameof(judgesDbContext));
        }

        public async Task<JudgeDto> Get(int id)
        {
            var judge = await _judgesDbContext.Judges
                .Where(x => x.Id == id)
                .Select(x => new JudgeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    Raiting = x.Raiting,
                    SportId = x.SportId,
                    SportName = x.Sport.Name
                })
                .FirstOrDefaultAsync();

            if (judge != null)
            {
                judge.Events = await _eventService.GetEventsForJudge();
            }

            return judge;
        }

        public async Task<int> Create(JudgeDto judgeDto)
        {
            Judge judge = new Judge();

            AplyDtoToEntity(judge, judgeDto);

            _judgesDbContext.Judges.Add(judge);
            await _judgesDbContext.SaveChangesAsync();

            return judge.Id;
        }

        public async Task<int> Update(JudgeDto judgeDto)
        {
            Judge judge = _judgesDbContext.Judges.Find(judgeDto.Id);

            AplyDtoToEntity(judge, judgeDto);

            await _judgesDbContext.SaveChangesAsync();

            return judge.Id;
        }

        public async Task Delete(int id)
        {
            Judge judge = _judgesDbContext.Judges.Find(id);

            _judgesDbContext.Judges.Remove(judge);
            await _judgesDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Judge judge, JudgeDto judgeDto)
        {
            judge.Name = judgeDto.Name;
            judge.Age = judgeDto.Age;
            judge.Raiting = judgeDto.Raiting;
            judge.SportId = judgeDto.SportId;
        }
    }
}
