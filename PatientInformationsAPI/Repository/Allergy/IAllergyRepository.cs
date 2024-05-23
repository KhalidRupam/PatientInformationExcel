using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.Allergy
{
    public interface IAllergyRepository
    {
        public Task<List<PatientInformationsAPI.Model.Allergy>> getAllAllergies();
    }
}
