using Newtonsoft.Json;

namespace PatientInformationFrontEnd.Models
{
    public class NCDs
    {
        [JsonProperty("result")]
        public List<Ncd> Ncd { get; set; }
    }
}
