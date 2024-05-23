using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationsAPI.Model;
using PatientInformationsAPI.Repository.PatientDetails;

namespace PatientInformationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientDetailsRepository _patientDetailsRepository;

        public PatientDetailsController(IPatientDetailsRepository patientDetailsRepository)
        {
            _patientDetailsRepository = patientDetailsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            return new OkObjectResult(_patientDetailsRepository.PatientInformationDetails());
        }
        [HttpPost("postPatientInformation")]
        public async Task<IActionResult> postPatientInformation( PatientInformationView patientInformation)
        {
            var res = await _patientDetailsRepository.PostPatientInformationDetails(patientInformation);
            return Ok();
        }

    }
}
