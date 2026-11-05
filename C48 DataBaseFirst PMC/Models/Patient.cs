using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class Patient
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("DOB")]
    public DateOnly Dob { get; set; }

    public int? WardId { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    [InverseProperty("Patient")]
    public virtual PatientConsultantAssignment? PatientConsultantAssignment { get; set; }

    [ForeignKey("WardId")]
    [InverseProperty("Patients")]
    public virtual Ward? Ward { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Patients")]
    public virtual ICollection<Consultant> Consultants { get; set; } = new List<Consultant>();
}
