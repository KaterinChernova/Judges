using Judges.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public class JudgeService : IJudgeService
    {
        public Judge Get(int id)
        {
            return new Judge
            {
                Id = id,
                Name = "Иванов Иван Иванович",
                Age = 40
            };
        }

        public int Create(Judge judge)
        {
            return judge.Id;
        }
    }
}
