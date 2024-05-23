namespace PatientInformationFrontEnd.Models
{
    public class PatientInformation
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public bool IsActve { get; set; }

        public string DiseaseId { get; set; } = null!;

        public bool Epliepsy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifierDate { get; set; }

        public string Allergies { get; set; }
        public string Diseases { get; set; }

        public virtual ICollection<AllergiesDetail> AllergiesDetails { get; set; } = new List<AllergiesDetail>();

        public virtual DiseaseInformation Disease { get; set; } = null!;

        public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
    }
}
