using System;
using System.Collections.Generic;

namespace PatientInformationsAPI.Model;

public partial class NcdDetail
{
    public string Id { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string Ncdid { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime ModifierDate { get; set; }

    public virtual Ncd Ncd { get; set; } = null!;

    public virtual PatientInformation Patient { get; set; } = null!;
}
