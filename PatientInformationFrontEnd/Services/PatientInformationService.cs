using Newtonsoft.Json;
using PatientInformationFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PatientInformationFrontEnd.Services
{
    public class PatientInformationService:IPatientInformationService
    {
        private readonly HttpClient _httpClient;

        public PatientInformationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PatientInformation>> getAllPatientDetails()
        {
            var res = await _httpClient.GetAsync("/api/PatientDetails");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<PatientDetails>(jsonString);
            
            return deserializedJson.PatientInformations;
        }
        public async Task<List<DiseaseInformation>> getAllDiseases()
        {
            var res = await _httpClient.GetAsync("/api/DiseaseDetails");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<Diseases>(jsonString);

            return deserializedJson.DiseaseInformation;
        }

        public async Task<List<Ncd>> getAllNCDs()
        {
            var res = await _httpClient.GetAsync("/api/NCD");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<NCDs>(jsonString);

            return deserializedJson.Ncd;
        }

        public async Task<List<Allergy>> getAllAllergies()
        {
            var res = await _httpClient.GetAsync("/api/Allergy");
            if (res.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            res.EnsureSuccessStatusCode();

            var jsonString = await res.Content.ReadAsStringAsync();

            var deserializedJson = JsonConvert.DeserializeObject<Allergies>(jsonString);

            return deserializedJson.Allergy;
        }

        public async Task<string> postPatientInformation(PatientInformationView patientInformation)
        {
            try
            {

                PatientInformationFrontEnd.Models.ViewModel.PatientInformationView patientInformationView = new PatientInformationFrontEnd.Models.ViewModel.PatientInformationView();
                patientInformationView.Epilepsy = patientInformation.Epilepsy;

                if (patientInformation.SelectedNCDs is not null)
                {
                    foreach (var item in patientInformation.SelectedNCDs)
                    {
                        PatientInformationFrontEnd.Models.ViewModel.NcdView ncdView = new PatientInformationFrontEnd.Models.ViewModel.NcdView() { Id = item.Id, Details = item.Details };
                        patientInformationView.SelectedNCDs.Add(ncdView);
                    }
                }

                foreach (var item in patientInformation.SelectedAllergies)
                {
                    PatientInformationFrontEnd.Models.ViewModel.AllergyView allergyView = new PatientInformationFrontEnd.Models.ViewModel.AllergyView() { Id = item.Id, Details = item.Details };
                    patientInformationView.SelectedAllergies.Add(allergyView);
                }
                patientInformationView.DiseaseInformation.Id = patientInformation.DiseaseInformation.Id;
                patientInformationView.DiseaseInformation.Details = patientInformation.DiseaseInformation.Details;
                patientInformationView.Name=patientInformation.Name;


                HttpContent body = new StringContent(JsonConvert.SerializeObject(patientInformationView), Encoding.UTF8, "application/json");
                
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7020/api/PatientDetails/postPatientInformation";

                    string json = JsonConvert.SerializeObject(patientInformationView);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                    }
                }


                return "OK";
            }
            catch (TaskCanceledException ex)
            {

                throw;
            }
           
        }
    }
}
