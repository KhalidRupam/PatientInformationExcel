using System;
using System.Collections.Generic;

namespace PatientInformationsAPI.Model;

public partial class Ncd
{
    public string Id { get; set; } = null!;

    public string Details { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModifierDate { get; set; }

    public virtual ICollection<NcdDetail> NcdDetails { get; set; } = new List<NcdDetail>();
}
