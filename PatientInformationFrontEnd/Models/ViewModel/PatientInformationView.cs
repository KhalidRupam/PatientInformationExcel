using PatientInformationFrontEnd.Models.Enums;

namespace PatientInformationFrontEnd.Models.ViewModel
{
    public class PatientInformationView
    {
        public string Name { get; set; }
        public DiseaseInformationView DiseaseInformation { get; set; }=new DiseaseInformationView();
        public Epilepsy Epilepsy { get; set; }
        public List<NcdView> SelectedNCDs { get; set; }=new List<NcdView>();
        public List<AllergyView> SelectedAllergies { get; set; } = new List<AllergyView>();
    }
}
