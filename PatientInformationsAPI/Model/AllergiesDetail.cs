using System;
using System.Collections.Generic;

namespace PatientInformationsAPI.Model;

public partial class AllergiesDetail
{
    public string Id { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string AllergieId { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime ModifierDate { get; set; }

    public virtual Allergy Allergie { get; set; } = null!;

    public virtual PatientInformation Patient { get; set; } = null!;
}
