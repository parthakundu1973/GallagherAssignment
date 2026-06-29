
using System.ComponentModel.DataAnnotations;

namespace GallagherAssessment.API.Application.DTOs
{
    public class ProbabilityRequest
    {
        [Required]
        public double PA { get; set; }

        [Required]
        public double PB { get; set; }

        [Required]
        public string Operation { get; set; }  // I could  have  use Enum instead of string  but After anlysing I found that will reduce the felexibity of the Product . 
    }
}
