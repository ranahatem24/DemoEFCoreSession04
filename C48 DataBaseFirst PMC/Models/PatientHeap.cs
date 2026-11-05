using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
[Table("PatientHeap")]
public partial class PatientHeap
{
    public int? Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }
}
