using GallagherAssessment.API.Application.DTOs;
using GallagherAssessment.API.Application.Service;

namespace GallagherAssessment.API.Application.Decorator
{
    public class LoggingProbabilityService : IProbabilityService
    {
        private readonly IProbabilityService _inner;
        private readonly ILogger<LoggingProbabilityService> _logger;

        public LoggingProbabilityService(
            IProbabilityService inner,
            ILogger<LoggingProbabilityService> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public  ProbabilityResponse Calculate(ProbabilityRequest request)
        {
            
                var result =  _inner.Calculate(request);
                if (result.Result == -1)
                {
                    _logger.LogError(
                       "Calculation Not Found for {Choice}, PA={PA}, PB={PB}",
                       request.Operation,
                       request.PA,
                       request.PB
                     );
                    return new ProbabilityResponse
                    {
                        Result = 0
                    };
                }

                _logger.LogInformation(
                                     "Calculation for {CalculationType}, PA={PA}, PB={PB}, Result={Result}",
                                     request.Operation,
                                     request.PA,
                                     request.PB,
                                     result.Result
                                   );

                return result;
           
           
        }
    }
}
