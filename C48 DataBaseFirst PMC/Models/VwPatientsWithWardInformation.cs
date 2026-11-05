using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
public partial class VwPatientsWithWardInformation
{
    public int PatientId { get; set; }

    [StringLength(100)]
    public string PatientName { get; set; } = null!;

    [StringLength(100)]
    public string WardName { get; set; } = null!;
}
