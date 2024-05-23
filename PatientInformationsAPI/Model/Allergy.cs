using System;
using System.Collections.Generic;

namespace PatientInformationsAPI.Model;

public partial class Allergy
{
    public string Id { get; set; } = null!;

    public string Details { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModifierDate { get; set; }

    public virtual ICollection<AllergiesDetail> AllergiesDetails { get; set; } = new List<AllergiesDetail>();
}
