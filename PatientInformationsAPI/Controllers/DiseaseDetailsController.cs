using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationsAPI.Repository.DiseaseDetails;
using PatientInformationsAPI.Repository.PatientDetails;

namespace PatientInformationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseDetailsController : ControllerBase
    {
        private readonly IDiseaseDetailsRepository _diseaseDetails;

        public DiseaseDetailsController(IDiseaseDetailsRepository diseaseDetails)
        {
            _diseaseDetails = diseaseDetails;
        }

        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            return new OkObjectResult(_diseaseDetails.getAllDiseaseInformations());
        }
    }
}
