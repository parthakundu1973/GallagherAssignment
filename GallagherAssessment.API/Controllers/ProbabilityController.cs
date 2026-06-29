using GallagherAssessment.API.Application.DTOs;
using GallagherAssessment.API.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GallagherAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbabilityController : ControllerBase{
        private readonly IProbabilityService _service;
        private readonly ProbabilityOperationChoiceItems _probabilityOperationChoiceItems;
        public ProbabilityController(IProbabilityService service, 
                                    IOptions<ProbabilityOperationChoiceItems> options )
        {
            _service = service;
            _probabilityOperationChoiceItems = options.Value;
        }


       
        [HttpPost("calculate")]
        public  ActionResult<ProbabilityResponse> CalculateProbability(ProbabilityRequest request)
        {
            
            if (request.PA < 0 || request.PA > 1 )
            { 
                return BadRequest("Probability A must be between 0 and 1.");
            }
            if (request.PB < 0 || request.PB > 1 )
            {
                return BadRequest("Probability B must be between 0 and 1.");
            }
            var result =  _service.Calculate(request);

            return Ok(result);
        }

        [HttpGet("operations")]
        public  ActionResult<ProbabilityOperationChoiceItem> GetOperations()
        {
            return Ok(_probabilityOperationChoiceItems.Operations);
        }
    }
}
