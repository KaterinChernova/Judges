using Judges.Enums;
using Judges.Services;
using NUnit.Framework;
using System;

namespace Judges.Tests
{
    [TestFixture]
    public class JudgeLevelServiceTest
    {
        private JudgeLevelService judgeLevelService;

        [SetUp]
        public void SetUp()
        {
            judgeLevelService = new JudgeLevelService();
        }

        [TestCase(80, ExpectedResult = JudgeLevel.Profi)]
        [TestCase(50, ExpectedResult = JudgeLevel.Middle)]
        [TestCase(30, ExpectedResult = JudgeLevel.Middle)]
        [TestCase(10, ExpectedResult = JudgeLevel.Junior)]
        public JudgeLevel CheckJudgeLevel(double raiting)
        {
            return judgeLevelService.GetJudgeLevel(raiting);
        }
    }
}
