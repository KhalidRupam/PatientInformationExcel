using Newtonsoft.Json;

namespace PatientInformationFrontEnd.Models
{
    public class Allergies
    {
        [JsonProperty("result")]
        public List<Allergy> Allergy { get; set; }
    }
}
