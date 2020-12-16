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
    public class SportService : ISportService
    {
        private readonly JudgesDbContext _judgesDbContext;

        public SportService(JudgesDbContext judgesDbContext)
        {
            _judgesDbContext = judgesDbContext ?? throw new ArgumentNullException(nameof(judgesDbContext));
        }

        public async Task<SportDto> Get(int id)
        {
            return await _judgesDbContext.Sports
                .Where(x => x.Id == id)
                .Select(x => new SportDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> Create(SportDto judgeDto)
        {
            Sport judge = new Sport();

            AplyDtoToEntity(judge, judgeDto);

            _judgesDbContext.Sports.Add(judge);
            await _judgesDbContext.SaveChangesAsync();

            return judge.Id;
        }

        public async Task<int> Update(SportDto judgeDto)
        {
            Sport judge = _judgesDbContext.Sports.Find(judgeDto.Id);

            AplyDtoToEntity(judge, judgeDto);

            await _judgesDbContext.SaveChangesAsync();

            return judge.Id;
        }

        public async Task Delete(int id)
        {
            Sport sport = _judgesDbContext.Sports.Find(id);

            _judgesDbContext.Sports.Remove(sport);
            await _judgesDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Sport sport, SportDto sportDto)
        {
            sport.Name = sportDto.Name;
            sport.Description = sportDto.Description;
        }
    }
}
