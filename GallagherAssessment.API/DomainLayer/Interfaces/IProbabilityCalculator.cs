
namespace GallagherAssessment.API.DomainLayer.Interfaces
{
    public interface IProbabilityCalculator
    {
     
        string Type { get; }
        public double Calculate(double a, double b);
    }
}
