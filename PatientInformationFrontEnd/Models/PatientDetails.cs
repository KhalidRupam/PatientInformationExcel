using Newtonsoft.Json;

namespace PatientInformationFrontEnd.Models
{
    public class PatientDetails
    {
        [JsonProperty("result")]
        public List<PatientInformation> PatientInformations { get; set; }
    }
}
