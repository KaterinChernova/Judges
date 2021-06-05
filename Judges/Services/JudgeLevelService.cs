using Judges.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Services
{
    public class JudgeLevelService
    {
        public JudgeLevel GetJudgeLevel(double raiting)
        {
            if (raiting >= 80)
            {
                return JudgeLevel.Profi;
            }

            if (raiting >= 20)
            {
                return JudgeLevel.Middle;
            }

            return JudgeLevel.Junior;
        }
    }
}
