using Xunit;
using GallagherAssessment.API.DomainLayer.Services;

namespace GallagherAssessment.Tests.DomainLayer.Services
{
    public class EitherProbabilityCalculatorTests
    {
        private readonly EitherProbabilityCalculator _calculator;

        public EitherProbabilityCalculatorTests()
        {
            _calculator = new EitherProbabilityCalculator();
        }
        [Fact]
        public void Calculate_ReturnsCorrectEitherProbability()
        {
            
            double pA = 0.5;
            double pB = 0.4;

            
            var result = _calculator.Calculate(pA, pB);

            // Expected: 0.5 + 0.4 - (0.5 * 0.4) = 0.7
            var expected = 0.7;

            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_WhenBothZero_ReturnsZero()
        {
            var result = _calculator.Calculate(0, 0);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Calculate_WhenOneValueIsZero_ReturnsOtherValue()
        {
            var result = _calculator.Calculate(0, 0.8);

            Assert.Equal(0.8, result);
        }

        [Fact]
        public void Calculate_WhenBothAreOne_ReturnsOne()
        {
            var result = _calculator.Calculate(1, 1);

            Assert.Equal(1, result);
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
