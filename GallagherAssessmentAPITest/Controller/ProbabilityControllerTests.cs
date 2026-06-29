using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using GallagherAssessment.API.Controllers;
using GallagherAssessment.API.Application.Service;
using GallagherAssessment.API.Application.DTOs;
using System.Collections.Generic;

namespace GallagherAssessmentAPITest.Controller
{

    public class ProbabilityControllerTests
    {
        private readonly Mock<IProbabilityService> _serviceMock;
        private readonly ProbabilityController _controller;

        public ProbabilityControllerTests()
        {
            _serviceMock = new Mock<IProbabilityService>();

            var options = Options.Create(new ProbabilityOperationChoiceItems
            {
                Operations = new List<ProbabilityOperationChoiceItem>
            {
                new ProbabilityOperationChoiceItem { Key = "Either" },
                new ProbabilityOperationChoiceItem { Key = "CombinedWith" }
            }
            });

            _controller = new ProbabilityController(_serviceMock.Object, options);
        }

        [Fact]
        public void CalculateProbability_ValidRequest_ReturnsOk()
        {
            
            var request = new ProbabilityRequest
            {
                PA = 0.5,
                PB = 0.5
            };

            var expectedResponse = new ProbabilityResponse();

            _serviceMock
                .Setup(s => s.Calculate(request))
                .Returns(expectedResponse);

            
            var result = _controller.CalculateProbability(request);

            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public void CalculateProbability_InvalidPA_ReturnsBadRequest()
        {
            
            var request = new ProbabilityRequest
            {
                PA = -1,
                PB = 0.5
            };

            
            var result = _controller.CalculateProbability(request);

            
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Probability A must be between 0 and 1.", badRequest.Value);
        }

        [Fact]
        public void CalculateProbability_InvalidPB_ReturnsBadRequest()
        {
            var request = new ProbabilityRequest
            {
                PA = 0.5,
                PB = 2
            };

            var result = _controller.CalculateProbability(request);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Probability B must be between 0 and 1.", badRequest.Value);
        }

        [Fact]
        public void GetOperations_ReturnsOkResult()
        {
            
            var result = _controller.GetOperations();

            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(okResult.Value);
        }

    }
}
