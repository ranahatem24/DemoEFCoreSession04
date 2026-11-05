using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C48_DatabaseFirst_PMC.Models;

[PrimaryKey("DrugCode", "Brand")]
public partial class DrugBrand
{
    [Key]
    public int DrugCode { get; set; }

    [Key]
    [StringLength(100)]
    public string Brand { get; set; } = null!;

    [ForeignKey("DrugCode")]
    [InverseProperty("DrugBrands")]
    public virtual Drug DrugCodeNavigation { get; set; } = null!;
}
