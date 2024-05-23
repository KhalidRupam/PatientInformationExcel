using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.DiseaseDetails
{
    public class DiseaseDetailsRepository:IDiseaseDetailsRepository
    {
        private readonly PatientInformationContext _patientInformationContext;

        public DiseaseDetailsRepository(PatientInformationContext patientInformationContext)
        {
            _patientInformationContext = patientInformationContext;
        }

        public async Task<List<DiseaseInformation>> getAllDiseaseInformations()
        {
            var list = _patientInformationContext.DiseaseInformations.ToList();
            return list;
        }
    }
}
