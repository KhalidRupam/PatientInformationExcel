using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.DiseaseDetails
{
    public interface IDiseaseDetailsRepository
    {
        public Task<List<DiseaseInformation>> getAllDiseaseInformations();
    }
}
