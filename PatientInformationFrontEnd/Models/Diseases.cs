using Newtonsoft.Json;

namespace PatientInformationFrontEnd.Models
{
    public class Diseases
    {
        [JsonProperty("result")]
        public List<DiseaseInformation> DiseaseInformation { get; set; }
    }
}
