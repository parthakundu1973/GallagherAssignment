using Xunit;
using GallagherAssessment.API.DomainLayer.Services;

namespace GallagherAssessment.Tests.DomainLayer.Services
{
    public class CombinedProbabilityCalculatorTests
    {
        private readonly CombinedProbabilityCalculator _calculator;

        public CombinedProbabilityCalculatorTests()
        {
            _calculator = new CombinedProbabilityCalculator();
        }
        [Fact]
        public void Calculate_ReturnsProductOfTwoProbabilities()
        {
            
            double pA = 0.5;
            double pB = 0.4;

            
            var result = _calculator.Calculate(pA, pB);

            
            Assert.Equal(0.2, result);
        }

        [Fact]
        public void Calculate_WhenAnyInputIsZero_ReturnsZero()
        {
            var result = _calculator.Calculate(0, 0.8);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_WhenInputsAreOne_ReturnsOtherValue()
        {
            var result = _calculator.Calculate(1, 0.7);

            Assert.Equal(0.7, result);
        }

        [Fact]
        public void Calculate_IsCommutative()
        {
            var result1 = _calculator.Calculate(0.3, 0.6);
            var result2 = _calculator.Calculate(0.6, 0.3);

            Assert.Equal(result1, result2);
        }
    }
}