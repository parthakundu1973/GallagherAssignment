using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using GallagherAssessment.API.Application.Service;
using GallagherAssessment.API.Application.DTOs;
using GallagherAssessment.API.DomainLayer.Interfaces;

namespace GallagherAssessment.Tests.Application.Service
{
    public class ProbabilityServiceTests
    {

        private IProbabilityCalculator CreateCalculator(string type, double returnValue)
        {
            var mock = new Mock<IProbabilityCalculator>();

            mock.Setup(x => x.Type).Returns(type);
            mock.Setup(x => x.Calculate(It.IsAny<double>(), It.IsAny<double>()))
                .Returns(returnValue);

            return mock.Object;
        }

        [Fact]
        public void Calculate_ValidOperation_ReturnsRoundedResult()
        {
            
            var calculators = new List<IProbabilityCalculator>
            {
                CreateCalculator("Either", 0.123456)
            };

            var service = new ProbabilityService(calculators);

            var request = new ProbabilityRequest
            {
                Operation = "Either",
                PA = 0.5,
                PB = 0.5
            };

            
            var result = service.Calculate(request);

            
            Assert.Equal(0.1235, result.Result); // rounded to 4 decimals
        }

        [Fact]
        public void Calculate_InvalidOperation_ReturnsMinusOne()
        {
            
            var calculators = new List<IProbabilityCalculator>
            {
                CreateCalculator("Either", 0.2)
            };

            var service = new ProbabilityService(calculators);

            var request = new ProbabilityRequest
            {
                Operation = "Unknown",
                PA = 0.5,
                PB = 0.5
            };

            
            var result = service.Calculate(request);

            
            Assert.Equal(-1, result.Result);
        }

        [Fact]
        public void Calculate_SelectsCorrectCalculator()
        {
            
            var eitherMock = new Mock<IProbabilityCalculator>();
            eitherMock.Setup(x => x.Type).Returns("Either");
            eitherMock.Setup(x => x.Calculate(0.5, 0.5)).Returns(0.7);

            var combinedMock = new Mock<IProbabilityCalculator>();
            combinedMock.Setup(x => x.Type).Returns("Combined");
            combinedMock.Setup(x => x.Calculate(It.IsAny<double>(), It.IsAny<double>()))
                        .Returns(0.25);

            var service = new ProbabilityService(new[]
            {
                eitherMock.Object,
                combinedMock.Object
            });

            var request = new ProbabilityRequest
            {
                Operation = "Either",
                PA = 0.5,
                PB = 0.5
            };

            
            var result = service.Calculate(request);

            
            Assert.Equal(0.7, result.Result);

            eitherMock.Verify(x => x.Calculate(0.5, 0.5), Times.Once);
            combinedMock.Verify(x => x.Calculate(It.IsAny<double>(), It.IsAny<double>()), Times.Never);
        }

        [Fact]
        public void Calculate_RoundsToFourDecimalPlaces()
        {
            var calculators = new List<IProbabilityCalculator>
            {
                CreateCalculator("Either", 0.123456789)
            };

            var service = new ProbabilityService(calculators);

            var request = new ProbabilityRequest
            {
                Operation = "Either",
                PA = 0,
                PB = 0
            };

            var result = service.Calculate(request);

            Assert.Equal(0.1235, result.Result);
        }
    }
}
