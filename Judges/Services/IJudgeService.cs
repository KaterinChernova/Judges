using Judges.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public interface IJudgeService
    {
        Task<JudgeDto> Get(int id);

        Task<int> Create(JudgeDto judgeDto);

        Task<int> Update(JudgeDto judgeDto);

        Task Delete(int id);
    }
}
