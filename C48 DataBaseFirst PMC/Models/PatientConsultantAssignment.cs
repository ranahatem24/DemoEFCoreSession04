using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class PatientConsultantAssignment
{
    [Key]
    public int PatientId { get; set; }

    public int ConsultantId { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("PatientConsultantAssignments")]
    public virtual Consultant Consultant { get; set; } = null!;

    [ForeignKey("PatientId")]
    [InverseProperty("PatientConsultantAssignment")]
    public virtual Patient Patient { get; set; } = null!;
}
