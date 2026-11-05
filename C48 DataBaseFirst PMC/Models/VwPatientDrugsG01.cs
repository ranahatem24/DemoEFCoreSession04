using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
public partial class VwPatientDrugsG01
{
    public int PatientId { get; set; }

    public int? CountOfDrugs { get; set; }
}
