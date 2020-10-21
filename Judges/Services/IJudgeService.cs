using Judges.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public interface IJudgeService
    {
        Judge Get(int id);

        int Create(Judge judge);
    }
}
