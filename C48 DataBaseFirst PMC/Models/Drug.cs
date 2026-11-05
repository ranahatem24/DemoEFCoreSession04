using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

public partial class Drug
{
    [Key]
    public int Code { get; set; }

    [StringLength(50)]
    public string? Dosage { get; set; }

    [InverseProperty("DrugCodeNavigation")]
    public virtual ICollection<DrugAdministration> DrugAdministrations { get; set; } = new List<DrugAdministration>();

    [InverseProperty("DrugCodeNavigation")]
    public virtual ICollection<DrugBrand> DrugBrands { get; set; } = new List<DrugBrand>();
}
