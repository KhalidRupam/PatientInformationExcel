using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.Allergy
{
    public class AllergyRepository:IAllergyRepository
    {
        private readonly PatientInformationContext _patientInformationContext;

        public AllergyRepository(PatientInformationContext patientInformationContext)
        {
            _patientInformationContext = patientInformationContext;
        }

        public async Task<List<Model.Allergy>> getAllAllergies()
        {
            return _patientInformationContext.Allergies.ToList();
        }
    }
}
