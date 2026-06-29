
using GallagherAssessment.API.DomainLayer.Interfaces;

namespace GallagherAssessment.API.DomainLayer.Services
{
    public class CombinedProbabilityCalculator : IProbabilityCalculator
    {
        public string Type => "CombinedWith";

        public double Calculate(double pA, double pB)
        {
            return pA * pB;
        }
    }
}
