using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class Consultant
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Salary { get; set; }

    [InverseProperty("Consultant")]
    public virtual ICollection<PatientConsultantAssignment> PatientConsultantAssignments { get; set; } = new List<PatientConsultantAssignment>();

    [ForeignKey("ConsultantId")]
    [InverseProperty("Consultants")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
