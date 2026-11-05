using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class Nurse
{
    [Key]
    public int Number { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string? Address { get; set; }

    public int? SupervisedWardId { get; set; }

    public int? ServesInWardId { get; set; }

    [InverseProperty("Nurse")]
    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    [ForeignKey("ServesInWardId")]
    [InverseProperty("NurseServesInWards")]
    public virtual Ward? ServesInWard { get; set; }

    [ForeignKey("SupervisedWardId")]
    [InverseProperty("NurseSupervisedWards")]
    public virtual Ward? SupervisedWard { get; set; }
}
