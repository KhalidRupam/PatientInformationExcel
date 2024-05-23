using PatientInformationFrontEnd.Models.Enums;

namespace PatientInformationFrontEnd.Models
{
    public class PatientInformationView
    {
        public string Name { get; set; }
        public DiseaseInformation DiseaseInformation { get; set; }
        public List<DiseaseInformation> DiseaseInformations { get; set; }
        //public List<DiseaseInformation> SelectedDiseaseInformations { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public Ncd NCD { get; set; }
        public List<Ncd> NCDs { get; set; }
        public List<Ncd> SelectedNCDs { get; set; }
        public Allergy Allergy { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Allergy> SelectedAllergies { get; set; }=new List<Allergy>();

        public List<PatientInformation> PatientDetails { get; set; } = new List<PatientInformation>();
    }
}
