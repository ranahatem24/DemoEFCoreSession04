using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[Keyless]
public partial class DeletedPatient
{
    public int? PatientId { get; set; }

    [StringLength(100)]
    public string? PatientName { get; set; }

    [Column("DOB", TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    public int? WardId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }
}
