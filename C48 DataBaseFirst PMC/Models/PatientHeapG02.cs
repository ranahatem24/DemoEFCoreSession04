using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
[Table("PatientHeapG02")]
public partial class PatientHeapG02
{
    public int? Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }
}
