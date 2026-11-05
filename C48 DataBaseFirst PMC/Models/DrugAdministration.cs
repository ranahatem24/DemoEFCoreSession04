using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[PrimaryKey("NurseId", "DrugCode", "PatientId", "Date", "Time")]
public partial class DrugAdministration
{
    [Key]
    public int NurseId { get; set; }

    [Key]
    public int DrugCode { get; set; }

    [Key]
    public int PatientId { get; set; }

    [StringLength(50)]
    public string? Dosage { get; set; }

    [Key]
    [Column("DATE")]
    public DateOnly Date { get; set; }

    [Key]
    public TimeOnly Time { get; set; }

    [ForeignKey("DrugCode")]
    [InverseProperty("DrugAdministrations")]
    public virtual Drug DrugCodeNavigation { get; set; } = null!;

    [ForeignKey("NurseId")]
    [InverseProperty("DrugAdministrations")]
    public virtual Nurse Nurse { get; set; } = null!;

    [ForeignKey("PatientId")]
    [InverseProperty("DrugAdministrations")]
    public virtual Patient Patient { get; set; } = null!;
}
