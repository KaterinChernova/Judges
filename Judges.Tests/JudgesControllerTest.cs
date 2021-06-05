using Judges.Controllers;
using Judges.Data.Models;
using Judges.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Judges.Tests
{
    [TestFixture]
    public class JudgesControllerTest
    {
        private JudgeController judgesController;

        [SetUp]
        public void SetUp()
        {
            var mockJudgeService = new Mock<IJudgeService>();
            mockJudgeService
                .Setup(a => a.Get(2))
                .Returns(Task.FromResult(new[] { new JudgeDto { Id = 2, Name = "Test", Age = 20 } }));

            judgesController = new JudgeController(mockJudgeService.Object);
        }

        [Test]
        public void CheckGetNotNull()
        {
            var result = judgesController.Get(2);

            Assert.IsNotNull(result, "Судья не может быть null");
        }
    }
}
