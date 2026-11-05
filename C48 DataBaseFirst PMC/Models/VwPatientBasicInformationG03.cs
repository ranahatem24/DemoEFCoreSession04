using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
public partial class VwPatientBasicInformationG03
{
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("DOB")]
    public DateOnly Dob { get; set; }
}
