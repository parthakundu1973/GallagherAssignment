using GallagherAssessment.API.Application.DTOs;
using GallagherAssessment.API.DomainLayer.Interfaces;
using Serilog;
using Serilog.Core;

namespace GallagherAssessment.API.Application.Service
{
    public class ProbabilityService : IProbabilityService
    {
        private readonly Dictionary<string, IProbabilityCalculator> _calculations;
        public ProbabilityService(IEnumerable<IProbabilityCalculator> calculations )
        {
            _calculations = calculations.ToDictionary(c => c.Type);
        }


        public  ProbabilityResponse Calculate(ProbabilityRequest request)
        {
            if (!_calculations.TryGetValue(request.Operation, out var Calculator))
            {
                return new ProbabilityResponse
                {
                    Result = -1
                };
            }

            var result =  Calculator.Calculate(request.PA, request.PB);

            return new ProbabilityResponse
            {
                Result = Math.Round(result,4)
            };
        }

    }
}
