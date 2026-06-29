using GallagherAssessment.API.DomainLayer.Interfaces;

namespace GallagherAssessment.API.DomainLayer.Services
{
    public class EitherProbabilityCalculator: IProbabilityCalculator
    {
        public string Type => "Either";
        public double Calculate(double pA, double pB)
        {
            return pA + pB - (pA * pB);
        }
    }
}
