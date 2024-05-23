using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationsAPI.Repository.Allergy;

namespace PatientInformationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyRepository _allergyRepository;

        public AllergyController(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            return new OkObjectResult(_allergyRepository.getAllAllergies());
        }
    }
}
