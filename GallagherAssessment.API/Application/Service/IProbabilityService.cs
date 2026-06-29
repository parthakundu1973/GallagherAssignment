using GallagherAssessment.API.Application.DTOs;

namespace GallagherAssessment.API.Application.Service
{
    public interface IProbabilityService
    {
         ProbabilityResponse Calculate(ProbabilityRequest request);
    }
}
