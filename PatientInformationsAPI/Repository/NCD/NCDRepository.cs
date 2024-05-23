using PatientInformationsAPI.Model;

namespace PatientInformationsAPI.Repository.NCD
{
    public class NCDRepository:INCDRepository
    {
        private readonly PatientInformationContext _patientInformationContext;

        public NCDRepository(PatientInformationContext patientInformationContext)
        {
            _patientInformationContext = patientInformationContext;
        }

        public async Task<List<Ncd>> getAllNcd()
        {
            return _patientInformationContext.Ncds.ToList();
            //throw new NotImplementedException();
        }
    }
}
