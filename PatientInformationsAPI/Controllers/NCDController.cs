using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationsAPI.Repository.NCD;

namespace PatientInformationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly INCDRepository _nCDRepository;

        public NCDController(INCDRepository nCDRepository)
        {
            _nCDRepository = nCDRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getDetails()
        {
            try
            {
                return new OkObjectResult(_nCDRepository.getAllNcd());
            }
            catch (Exception ex) 
            {

                throw;
            }
           
        }
    }
}
