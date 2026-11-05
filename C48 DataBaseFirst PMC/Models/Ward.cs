using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class Ward
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("ServesInWard")]
    public virtual ICollection<Nurse> NurseServesInWards { get; set; } = new List<Nurse>();

    [InverseProperty("SupervisedWard")]
    public virtual ICollection<Nurse> NurseSupervisedWards { get; set; } = new List<Nurse>();

    [InverseProperty("Ward")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
