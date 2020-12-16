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

        public JudgeService(JudgesDbContext judgesDbContext)
        {
            _judgesDbContext = judgesDbContext ?? throw new ArgumentNullException(nameof(judgesDbContext));
        }

        public async Task<JudgeDto[]> Get(int id)
        {
            var judges = await _judgesDbContext.Judges
                .Where(x => x.SportId.HasValue)
                .ToArrayAsync();

            var judgesDtos = new List<JudgeDto>();
            foreach(var j in judges)
            {
                judgesDtos.Add(new JudgeDto
                {
                    SportName = j.Sport.Name
                });
            }

            return await _judgesDbContext.Judges
                .Where(x => x.Sport.Name == "Футбол")
                .Select(x => new JudgeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    Raiting = x.Raiting,
                    SportId = x.SportId,
                    SportName = x.Sport.Name
                })
                .ToArrayAsync();
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
