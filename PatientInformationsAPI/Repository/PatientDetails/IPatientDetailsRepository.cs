using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.PatientDetails
{
    public interface IPatientDetailsRepository
    {
        public  Task<List<PatientInformation>> PatientInformationDetails();
        public Task<string> PostPatientInformationDetails(PatientInformationView patientInformation);
    }
}
