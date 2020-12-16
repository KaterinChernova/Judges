using Judges.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public interface ISportService
    {
        Task<SportDto> Get(int id);

        Task<int> Create(SportDto judgeDto);

        Task<int> Update(SportDto judgeDto);

        Task Delete(int id);
    }
}
