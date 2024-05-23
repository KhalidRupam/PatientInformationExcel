using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.NCD
{
    public interface INCDRepository
    {
        public Task<List<Ncd>> getAllNcd();
    }
}
