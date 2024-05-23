using PatientInformationFrontEnd.Models;

namespace PatientInformationFrontEnd.Services
{
    public interface IPatientInformationService
    {
        Task<List<PatientInformation>> getAllPatientDetails();
        Task<List<DiseaseInformation>> getAllDiseases();
        Task<List<Ncd>> getAllNCDs();
        Task<List<Allergy>> getAllAllergies();
        Task<string> postPatientInformation(PatientInformationView patientInformation);
    }
}
